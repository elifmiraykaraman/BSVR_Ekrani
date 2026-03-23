using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace BankingSystem.Presentation
{
    public partial class FormNewApplication : Form
    {
        private int selectedCustomerId;
        private int currentProductId;
        private bool _applicationCreated = false;
        private readonly List<CheckBox> _redCheckboxes = new List<CheckBox>();
        private string _applicationStatus = string.Empty;
        private string _rejectionReason   = string.Empty;
        private string connString = @"Server=.\SQLEXPRESS; Database=CoreBankingSystem; Integrated Security=True; TrustServerCertificate=True;";
        private const string SenderEmail = "elifmiraykaraman@gmail.com";
        // Gmail: Ayarlar > Güvenlik > 2 Adımlı Doğrulama açık olmalı; oradan Uygulama Şifresi üretin.
        private const string SenderPassword = "##";
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsReadOnly { get; set; } = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BasvuruReferansNo { get; set; }
        public FormNewApplication(int custId, string custNum, string phone)
        {
            InitializeComponent();
            EnsureEmailColumnExists();
            this.FormClosing += FormNewApplication_FormClosing;
            this.selectedCustomerId = custId;

            txtCustNumber.Text = custNum;
            txtPhone.Text = phone;
            txtAppDate.Text = DateTime.Now.ToShortDateString();
            txtRefNo.Text = GenerateReferenceNumber();

            txtCreditAmount.TextChanged += (s, e) => HesaplaTaksit();
            txtMaturity.TextChanged += (s, e) => HesaplaTaksit();

            GetCustomerDetails(custId);
            txtEmail.Clear();
        }

        private void FormNewApplication_Load_1(object sender, EventArgs e)
        {
            if (this.IsReadOnly)
            {
                SetAllControlsReadOnly(this);
                VerileriDoldur(this.BasvuruReferansNo);

                if (_applicationStatus == "İptal")
                    CustomerDetails.TabPages.Remove(tabOnayRed);
                else
                    BuildOnayRedTab();
            }
            else
            {
                CustomerDetails.TabPages.Remove(tabOnayRed);
            }
        }

        private void SetAllControlsReadOnly(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                switch (ctrl)
                {
                    case TextBoxBase tb:
                        tb.ReadOnly = true;
                        break;
                    case ButtonBase btn:
                        btn.Enabled = false;
                        break;
                    case ComboBox cmb:
                        cmb.Enabled = false;
                        break;
                    case NumericUpDown num:
                        num.Enabled = false;
                        break;
                }

                if (ctrl.HasChildren)
                    SetAllControlsReadOnly(ctrl);
            }
        }

        private void EnsureEmailColumnExists()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string sql = @"IF NOT EXISTS (
                            SELECT 1 FROM sys.columns
                            WHERE object_id = OBJECT_ID('Customers') AND name = 'Email'
                        )
                        ALTER TABLE Customers ADD Email NVARCHAR(254) NULL;";
                    new SqlCommand(sql, conn).ExecuteNonQuery();
                }
            }
            catch { }
        }

        private string GenerateReferenceNumber()
        {
            Random res = new Random();
            string str = "";
            for (int i = 0; i < 10; i++) str += res.Next(0, 10).ToString();
            return str;
        }

        private void HesaplaTaksit()
        {
            if (decimal.TryParse(txtCreditAmount.Text, out decimal tutar) &&
                int.TryParse(txtMaturity.Text, out int vade) && vade > 0)
            {
                decimal taksit = tutar / vade;
                txtInstallmentAmount.Text = taksit.ToString("N2");
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO Applications 
                                (CustomerID, ProductID, ReferenceNumber, TransactionDate, Status, Amount, Installments, IncomeType, IncomeAmount) 
                             VALUES 
                                (@custId, @prodId, @ref, GETDATE(), 'Beklemede', @amt, @inst, @incomeType, @incomeAmt)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@custId", this.selectedCustomerId);
                cmd.Parameters.AddWithValue("@prodId", this.currentProductId);
                cmd.Parameters.AddWithValue("@ref", txtRefNo.Text);
                cmd.Parameters.AddWithValue("@amt", decimal.Parse(txtCreditAmount.Text));
                cmd.Parameters.AddWithValue("@inst", int.Parse(txtMaturity.Text));
                cmd.Parameters.AddWithValue("@incomeType", string.IsNullOrEmpty(cmbIncomeType.Text) ? (object)DBNull.Value : cmbIncomeType.Text);
                cmd.Parameters.AddWithValue("@incomeAmt", decimal.TryParse(txtIncomeAmount.Text, out decimal incAmt) ? incAmt : (object)DBNull.Value);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    _applicationCreated = true;
                    MessageBox.Show("Başvuru taslağı oluşturuldu. Şimdi kişisel bilgileri tamamlayalım.");

                    this.CustomerDetails.SelectedIndex = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE Applications SET 
                             HouseStatus=@house, Address=@address,
                             ResidenceDuration=@residenceY,
                             JobDurationYear=@jobY, JobDurationMonth=@jobM,
                             FirmActivityYear=@firmY, FirmActivityMonth=@firmM,
                             TotalWorkDuration=@totalWork, EmployeeCount=@empCount
                             WHERE ReferenceNumber=@ref";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@house",      cmbHouseStatus.Text);
                cmd.Parameters.AddWithValue("@address",    txtAddress.Text);
                cmd.Parameters.AddWithValue("@residenceY", (int)nmResidenceYear.Value);
                cmd.Parameters.AddWithValue("@jobY",       (int)nmJobYear.Value);
                cmd.Parameters.AddWithValue("@jobM",       (int)nmJobMonth.Value);
                cmd.Parameters.AddWithValue("@firmY",      (int)nmFirmYear.Value);
                cmd.Parameters.AddWithValue("@firmM",      (int)nmFirmMonth.Value);
                cmd.Parameters.AddWithValue("@totalWork",  (int)nmTotalWork.Value);
                cmd.Parameters.AddWithValue("@empCount",   string.IsNullOrEmpty(txtEmployeeCount.Text) ? (object)DBNull.Value : txtEmployeeCount.Text);
                cmd.Parameters.AddWithValue("@ref",        txtRefNo.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kişisel bilgiler güncellendi. Değerlendirme aşamasına geçiliyor.");

                    this.CustomerDetails.SelectedIndex = 2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt Hatası: " + ex.Message);
                }
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Müşteri mail adresi boş olamaz!");
                return;
            }

            try
            {
                using (SqlConnection emailConn = new SqlConnection(connString))
                {
                    SqlCommand emailCmd = new SqlCommand(
                        "UPDATE Customers SET Email = @email WHERE CustomerID = @custId",
                        emailConn);
                    emailCmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    emailCmd.Parameters.AddWithValue("@custId", this.selectedCustomerId);
                    emailConn.Open();
                    emailCmd.ExecuteNonQuery();
                }
            }
            catch { /* Email kolonu henüz yoksa sessizce geç */ }
        }
        

        private void btnSelectProduct_Click(object sender, EventArgs e)
        {
            using (FormProductSelection selectionForm = new FormProductSelection())
            {
                if (selectionForm.ShowDialog() == DialogResult.OK)
                {
                    textBox3.Text         = selectionForm.SelectedProductCode;
                    txtProduct.Text       = selectionForm.SelectedProductName;
                    this.currentProductId = selectionForm.SelectedProductId;
                }
            }
        }

        private void GetCustomerDetails(int custId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT CustomerNumber, FirstName, LastName, BirthDate, PhoneNumber FROM Customers WHERE CustomerID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", custId);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtCustNoPersonal.Text = dr["CustomerNumber"].ToString();
                        txtFirstName.Text      = dr["FirstName"].ToString();
                        txtLastName.Text       = dr["LastName"].ToString();
                        if (dr["BirthDate"] != DBNull.Value)
                            txtBirthDate.Text = Convert.ToDateTime(dr["BirthDate"]).ToShortDateString();
                        if (dr["PhoneNumber"] != DBNull.Value)
                            txtPhone.Text = dr["PhoneNumber"].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }

            // E-posta alanı yeni başvuruda boş bırakılır.
        }

        private void btnOnay1_Click(object sender, EventArgs e)
        {
            // Dahili süreç adımı — DB statüsü değişmez, uygulama 'Beklemede' kalır.
            // Nihai karar Detay modundaki Onay/Red sekmesinden verilir.
            _applicationCreated = false;
            label29.Text = "DURUM: 1. ONAY VERİLDİ — Nihai karar bekliyor";
            label29.ForeColor = Color.DarkGreen;
        }

        private void btnIptalRed_Click(object sender, EventArgs e)
        {
            UpdateApplicationStatus(txtRefNo.Text, "İptal");
            _applicationCreated = false;
            label29.Text = "İŞLEM DURUMU: BAŞVURU İPTAL EDİLDİ";
            label29.ForeColor = Color.Red;
        }

        private void UpdateApplicationStatus(string refNo, string newStatus)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE Applications SET Status = @status WHERE ReferenceNumber = @ref";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@ref", refNo);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Başvuru durumu '{newStatus}' olarak güncellendi.");
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }
        }

        private void btnExit_Click(object sender, EventArgs e) { this.Close(); }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtCreditAmount.Clear();
            txtMaturity.Clear();
            txtProduct.Clear();
            txtInstallmentAmount.Clear();
            txtRefNo.Text = GenerateReferenceNumber();
        }

        private void btnMinimumWage_Click_1(object sender, EventArgs e)
        {
            txtIncomeAmount.Text = "28075";
        }


        private void VerileriDoldur(string gelenRefNo)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                // --- Temel sorgu: orijinal şemada kesin olan sütunlar ---
                string baseQuery = @"
                    SELECT a.ReferenceNumber, a.Amount, a.Installments, a.Status, a.TransactionDate,
                           a.RejectionReason,
                           p.ProductCode, p.ProductName,
                           a.HouseStatus, a.Address,
                           a.ResidenceDuration,
                           a.JobDurationYear, a.JobDurationMonth,
                           a.FirmActivityYear, a.FirmActivityMonth,
                           a.TotalWorkDuration, a.EmployeeCount
                    FROM Applications a
                    INNER JOIN Customers c ON a.CustomerID = c.CustomerID
                    INNER JOIN Products  p ON a.ProductID  = p.ProductID
                    WHERE a.ReferenceNumber = @ref";

                try
                {
                    SqlCommand cmd = new SqlCommand(baseQuery, conn);
                    cmd.Parameters.AddWithValue("@ref", gelenRefNo);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtRefNo.Text        = dr["ReferenceNumber"].ToString();
                        txtCreditAmount.Text = dr["Amount"].ToString();
                        txtMaturity.Text     = dr["Installments"].ToString();
                        _applicationStatus   = dr["Status"].ToString();
                        label29.Text         = "MEVCUT DURUM: " + _applicationStatus;
                        if (dr["RejectionReason"] != DBNull.Value)
                            _rejectionReason = dr["RejectionReason"].ToString();

                        if (dr["TransactionDate"] != DBNull.Value)
                            txtAppDate.Text = Convert.ToDateTime(dr["TransactionDate"]).ToShortDateString();

                        txtProduct.Text = dr["ProductName"].ToString();
                        textBox3.Text   = dr["ProductCode"].ToString();

                        if (dr["HouseStatus"] != DBNull.Value)
                            cmbHouseStatus.Text = dr["HouseStatus"].ToString();

                        if (dr["Address"] != DBNull.Value)
                            txtAddress.Text = dr["Address"].ToString();

                        SetNumeric(nmResidenceYear, dr["ResidenceDuration"]);
                        SetNumeric(nmJobYear,       dr["JobDurationYear"]);
                        SetNumeric(nmJobMonth,      dr["JobDurationMonth"]);
                        SetNumeric(nmFirmYear,      dr["FirmActivityYear"]);
                        SetNumeric(nmFirmMonth,     dr["FirmActivityMonth"]);
                        SetNumeric(nmTotalWork,     dr["TotalWorkDuration"]);

                        if (dr["EmployeeCount"] != DBNull.Value)
                            txtEmployeeCount.Text = dr["EmployeeCount"].ToString();
                    }
                    dr.Close();
                }
                catch (Exception ex) { MessageBox.Show("Veri yükleme hatası: " + ex.Message); return; }

                // --- Genişletilmiş sorgu: migration ile eklenen sütunlar ---
                // Migration SQL henüz çalıştırılmamışsa sessizce geçilir.
                try
                {
                    string extQuery = @"
                        SELECT a.IncomeType, a.IncomeAmount, c.PhoneNumber
                        FROM Applications a
                        INNER JOIN Customers c ON a.CustomerID = c.CustomerID
                        WHERE a.ReferenceNumber = @ref";

                    SqlCommand cmd2 = new SqlCommand(extQuery, conn);
                    cmd2.Parameters.AddWithValue("@ref", gelenRefNo);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        if (dr2["IncomeType"]   != DBNull.Value) cmbIncomeType.Text   = dr2["IncomeType"].ToString();
                        if (dr2["IncomeAmount"] != DBNull.Value) txtIncomeAmount.Text = dr2["IncomeAmount"].ToString();
                        if (dr2["PhoneNumber"]  != DBNull.Value) txtPhone.Text        = dr2["PhoneNumber"].ToString();
                    }
                    dr2.Close();
                }
                catch { /* Migration henüz uygulanmamış, sessizce geç */ }

                try
                {
                    string emailQuery = @"
                        SELECT c.Email FROM Applications a
                        INNER JOIN Customers c ON a.CustomerID = c.CustomerID
                        WHERE a.ReferenceNumber = @ref";

                    SqlCommand cmdEmail = new SqlCommand(emailQuery, conn);
                    cmdEmail.Parameters.AddWithValue("@ref", gelenRefNo);
                    SqlDataReader drEmail = cmdEmail.ExecuteReader();
                    if (drEmail.Read() && drEmail["Email"] != DBNull.Value)
                        txtEmail.Text = drEmail["Email"].ToString();
                    drEmail.Close();
                }
                catch { /* Email kolonu henüz yoksa sessizce geç */ }
            }
        }

        private static void SetNumeric(NumericUpDown control, object dbValue)
        {
            if (dbValue == DBNull.Value) return;
            decimal v = Convert.ToDecimal(dbValue);
            control.Value = Math.Max(control.Minimum, Math.Min(control.Maximum, v));
        }

            private void BuildOnayRedTab()
            {
                _redCheckboxes.Clear();
                tabOnayRed.Controls.Clear();

                GroupBox CreateGroup(string title, Point loc, Size sz, string[] items)
                {
                    var gb = new GroupBox { Text = title, Location = loc, Size = sz };
                    int y = 22;
                    foreach (var item in items)
                    {
                        var cb = new CheckBox { Text = item, Location = new Point(8, y), AutoSize = true };
                        gb.Controls.Add(cb);
                        _redCheckboxes.Add(cb);
                        y += 27;
                    }
                    return gb;
                }

                var gb1 = CreateGroup("Kredi Notu ve Ödeme Geçmişi Sorunları",
                    new Point(8, 10), new Size(265, 115),
                    new[] { "Düşük Kredi Notu", "Geçmiş Takip Kayıtları", "Düzensiz Ödemeler" });

                var gb2 = CreateGroup("Gelir ve Borçluluk Oranı (Limit Yetersizliği)",
                    new Point(283, 10), new Size(265, 115),
                    new[] { "Yetersiz Gelir", "Yüksek Borçluluk Oranı", "Gelirin Belgelenememesi" });

                var gb3 = CreateGroup("Çalışma Hayatı ve Sosyal Güvenlik",
                    new Point(558, 10), new Size(292, 115),
                    new[] { "Yetersiz Çalışma Süresi", "Meslek Riski" });

                var gb4 = CreateGroup("İstihbarat ve Kimlik Sorunları",
                    new Point(8, 135), new Size(265, 115),
                    new[] { "Olumsuz Banka İstihbaratı", "Adres ve İletişim Teyit Edilememesi", "Yaş Sınırı" });

                var gb5 = CreateGroup("Teminat ve Başvuru Özelindeki Sorunlar",
                    new Point(283, 135), new Size(265, 115),
                    new[] { "Yetersiz Teminat", "Hatalı/Eksik Bilgi" });

                var lblDurum = new Label
                {
                    Text = "",
                    Location = new Point(8, 295),
                    Size = new Size(580, 25),
                    Font = new Font("Georgia", 10F, FontStyle.Bold)
                };

                var btnOnayla = new Button
                {
                    Text = "✓ ONAYLA",
                    Location = new Point(600, 270),
                    Size = new Size(120, 45),
                    BackColor = Color.DarkGreen,
                    ForeColor = Color.White,
                    Font = new Font("Georgia", 9F, FontStyle.Bold)
                };
                btnOnayla.Click += (s, e) =>
                {
                    UpdateApplicationStatus(this.BasvuruReferansNo, "Onaylandı");
                    lblDurum.Text = "İŞLEM DURUMU: BAŞVURU ONAYLANDI";
                    lblDurum.ForeColor = Color.DarkGreen;
                    label29.Text = "MEVCUT DURUM: Onaylandı";
                    label29.ForeColor = Color.DarkGreen;
                    SendApplicationResultEmail(
                        txtEmail.Text.Trim(),
                        $"Ba\u015fvurunuz Onayland\u0131 \u2013 Ref: {this.BasvuruReferansNo}",
                        $"Say\u0131n {txtFirstName.Text} {txtLastName.Text},\n\n" +
                        $"{this.BasvuruReferansNo} referans numaral\u0131 ba\u015fvurunuz onaylanm\u0131\u015ft\u0131r.\n\n" +
                        $"Ba\u015fvuru Tarihi : {txtAppDate.Text}\n" +
                        $"\u00dcr\u00fcn          : {txtProduct.Text}\n" +
                        $"Kredi Tutar\u0131  : {txtCreditAmount.Text} TL\n" +
                        $"Vade          : {txtMaturity.Text} ay\n\n" +
                        "Sayg\u0131lar\u0131m\u0131zla,\nBankac\u0131l\u0131k Sistemi");
                };

                var btnReddet = new Button
                {
                    Text = "✗ REDDET",
                    Location = new Point(730, 270),
                    Size = new Size(120, 45),
                    BackColor = Color.DarkRed,
                    ForeColor = Color.White,
                    Font = new Font("Georgia", 9F, FontStyle.Bold)
                };
                btnReddet.Click += (s, e) =>
                {
                    var secilenSebepler = _redCheckboxes
                        .Where(c => c.Checked)
                        .Select(c => c.Text)
                        .ToList();

                    if (secilenSebepler.Count == 0)
                    {
                        MessageBox.Show("Lütfen en az bir red sebebi seçiniz.");
                        return;
                    }

                    string sebep = string.Join("; ", secilenSebepler);
                    SaveRejectionReason(this.BasvuruReferansNo, sebep);
                    UpdateApplicationStatus(this.BasvuruReferansNo, "Reddedildi");
                    lblDurum.Text = "İŞLEM DURUMU: BAŞVURU REDDEDİLDİ";
                    lblDurum.ForeColor = Color.Red;
                    label29.Text = "MEVCUT DURUM: Reddedildi";
                    label29.ForeColor = Color.Red;
                    string sebepListesi = string.Join("\n", secilenSebepler.Select(r => "- " + r));
                    SendApplicationResultEmail(
                        txtEmail.Text.Trim(),
                        $"Ba\u015fvurunuz Reddedildi \u2013 Ref: {this.BasvuruReferansNo}",
                        $"Say\u0131n {txtFirstName.Text} {txtLastName.Text},\n\n" +
                        $"{this.BasvuruReferansNo} referans numaral\u0131 ba\u015fvurunuz reddedilmi\u015ftir.\n\n" +
                        $"Red Sebebi/Sebepleri:\n{sebepListesi}\n\n" +
                        $"Ba\u015fvuru Tarihi : {txtAppDate.Text}\n\n" +
                        "Sayg\u0131lar\u0131m\u0131zla,\nBankac\u0131l\u0131k Sistemi");
                };

                // --- Karar verilmişse: butonları pasifleştir, sonuçu göster ---
                bool kararVerildi = _applicationStatus is "Onaylandı" or "Reddedildi";

                if (kararVerildi)
                {
                    btnOnayla.Enabled = false;
                    btnReddet.Enabled = false;
                    lblDurum.ForeColor = _applicationStatus == "Onaylandı" ? Color.DarkGreen : Color.Red;
                }

                if (_applicationStatus == "Reddedildi" && !string.IsNullOrEmpty(_rejectionReason))
                {
                    var sebepler = _rejectionReason.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var cb in _redCheckboxes)
                    {
                        cb.Checked = sebepler.Contains(cb.Text);
                        cb.Enabled = false;
                    }
                }

                var kontrolListesi = new List<Control> { gb1, gb2, gb3, gb4, gb5, lblDurum, btnOnayla, btnReddet };

                if (kararVerildi)
                {
                    var lblSonuc = new Label
                    {
                        Text      = _applicationStatus == "Onaylandı"
                                      ? "✔  BAŞVURU ONAYLANMIŞTIR"
                                      : "✘  BAŞVURU REDDEDİLMİŞTİR",
                        Location  = new Point(8, 335),
                        Size      = new Size(840, 35),
                        Font      = new Font("Georgia", 13F, FontStyle.Bold),
                        ForeColor = _applicationStatus == "Onaylandı" ? Color.DarkGreen : Color.DarkRed,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    kontrolListesi.Add(lblSonuc);
                }

                tabOnayRed.Controls.AddRange(kontrolListesi.ToArray());
            }

            private void SaveRejectionReason(string refNo, string reason)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "UPDATE Applications SET RejectionReason = @reason WHERE ReferenceNumber = @ref";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@reason", reason);
                    cmd.Parameters.AddWithValue("@ref", refNo);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) { MessageBox.Show("Red sebebi kaydedilemedi: " + ex.Message); }
                }
            }

        private void SendApplicationResultEmail(string toEmail, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(toEmail))
            {
                MessageBox.Show("Müşteriye ait e-posta adresi girilmemiş; mail gönderilemedi.");
                return;
            }
            try
            {
                using var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(SenderEmail, SenderPassword)
                };
                var mail = new MailMessage
                {
                    From = new MailAddress(SenderEmail, "Bankacılık Sistemi", Encoding.UTF8),
                    Subject = subject,
                    SubjectEncoding = Encoding.UTF8,
                    Body = body,
                    BodyEncoding = Encoding.UTF8,
                    IsBodyHtml = false
                };
                mail.To.Add(toEmail);
                client.Send(mail);
                MessageBox.Show("Bilgilendirme maili müşteriye gönderildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderilemedi: " + ex.Message);
            }
        }

        private void FormNewApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.IsReadOnly || !_applicationCreated) return;

            var sonuc = MessageBox.Show(
                "Başvuru tamamlanmadan kapatılıyor.\n\n" +
                "EVET  → Taslak silinir, hiç kaydedilmemiş sayılır.\n" +
                "HAYIR → Taslak korunur, daha sonra tamamlanabilir.",
                "Dikkat",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (sonuc == DialogResult.Yes)
                DeleteDraftApplication(txtRefNo.Text);
        }

        private void DeleteDraftApplication(string refNo)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "DELETE FROM Applications WHERE ReferenceNumber = @ref";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ref", refNo);
                try { conn.Open(); cmd.ExecuteNonQuery(); }
                catch { /* silently ignore */ }
            }
        }


    }
}