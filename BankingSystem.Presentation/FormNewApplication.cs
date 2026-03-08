using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BankingSystem.Presentation
{
    public partial class FormNewApplication : Form
    {
        private int selectedCustomerId;
        private int currentProductId;
        private string connString = @"Server=.\SQLEXPRESS; Database=CoreBankingSystem; Integrated Security=True; TrustServerCertificate=True;";
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsReadOnly { get; set; } = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BasvuruReferansNo { get; set; }
        public FormNewApplication(int custId, string custNum, string phone)
        {
            InitializeComponent();
            this.selectedCustomerId = custId;

            txtCustNumber.Text = custNum;
            txtPhone.Text = phone;
            txtAppDate.Text = DateTime.Now.ToShortDateString();
            txtRefNo.Text = GenerateReferenceNumber();

            txtCreditAmount.TextChanged += (s, e) => HesaplaTaksit();
            txtMaturity.TextChanged += (s, e) => HesaplaTaksit();

            GetCustomerDetails(custId);
        }

        private void FormNewApplication_Load_1(object sender, EventArgs e)
        {
            if (this.IsReadOnly)
            {
                SetAllControlsReadOnly(this);
                VerileriDoldur(this.BasvuruReferansNo);
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
            string query = @"INSERT INTO Applications (CustomerID, ProductID, ReferenceNumber, TransactionDate, Status, Amount, Installments) 
                             VALUES (@custId, @prodId, @ref, GETDATE(), 'Beklemede', @amt, @inst)";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@custId", this.selectedCustomerId);
                cmd.Parameters.AddWithValue("@prodId", this.currentProductId);
                cmd.Parameters.AddWithValue("@ref", txtRefNo.Text);
                cmd.Parameters.AddWithValue("@amt", decimal.Parse(txtCreditAmount.Text));
                cmd.Parameters.AddWithValue("@inst", int.Parse(txtMaturity.Text));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
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
            string query = @"UPDATE Customers SET HouseStatus=@house, Address=@address, 
                             JobDurationYear=@jobY, TotalWorkDuration=@totalWork 
                             WHERE CustomerID=@id";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@house", cmbHouseStatus.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@jobY", (int)nmJobYear.Value);
                cmd.Parameters.AddWithValue("@totalWork", (int)nmTotalWork.Value);
                cmd.Parameters.AddWithValue("@id", this.selectedCustomerId);

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
        }

        private void btnSelectProduct_Click(object sender, EventArgs e)
        {
            using (FormProductSelection selectionForm = new FormProductSelection())
            {
                if (selectionForm.ShowDialog() == DialogResult.OK)
                {
                    txtProduct.Text = selectionForm.SelectedProductName;
                    this.currentProductId = selectionForm.SelectedProductId;
                }
            }
        }

        private void GetCustomerDetails(int custId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT CustomerNumber, FirstName, LastName, BirthDate FROM Customers WHERE CustomerID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", custId);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtCustNoPersonal.Text = dr["CustomerNumber"].ToString();
                        txtFirstName.Text = dr["FirstName"].ToString();
                        txtLastName.Text = dr["LastName"].ToString();
                        if (dr["BirthDate"] != DBNull.Value)
                            txtBirthDate.Text = Convert.ToDateTime(dr["BirthDate"]).ToShortDateString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }
        }

        private void btnOnay1_Click(object sender, EventArgs e)
        {
            UpdateApplicationStatus(txtRefNo.Text, "Onaylandı");
            label29.Text = "İŞLEM DURUMU: BAŞVURU ONAYLANDI";
            label29.ForeColor = Color.DarkGreen;
        }

        private void btnIptalRed_Click(object sender, EventArgs e)
        {
            UpdateApplicationStatus(txtRefNo.Text, "Reddedildi");
            label29.Text = "İŞLEM DURUMU: BAŞVURU REDDEDİLDİ";
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
            txtIncomeAmount.Text = "22104";
        }


        private void VerileriDoldur(string gelenRefNo)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"
                    SELECT a.ReferenceNumber, a.Amount, a.Installments, a.Status, a.TransactionDate,
                           p.ProductName,
                           c.HouseStatus, c.Address, c.JobDurationYear, c.TotalWorkDuration
                    FROM Applications a
                    INNER JOIN Customers c ON a.CustomerID = c.CustomerID
                    INNER JOIN Products p ON a.ProductID = p.ProductID
                    WHERE a.ReferenceNumber = @ref";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ref", gelenRefNo);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtRefNo.Text        = dr["ReferenceNumber"].ToString();
                        txtCreditAmount.Text = dr["Amount"].ToString();
                        txtMaturity.Text     = dr["Installments"].ToString();
                        label29.Text         = "MEVCUT DURUM: " + dr["Status"].ToString();

                        if (dr["TransactionDate"] != DBNull.Value)
                            txtAppDate.Text = Convert.ToDateTime(dr["TransactionDate"]).ToShortDateString();

                        txtProduct.Text = dr["ProductName"].ToString();

                        if (dr["HouseStatus"] != DBNull.Value)
                            cmbHouseStatus.Text = dr["HouseStatus"].ToString();

                        if (dr["Address"] != DBNull.Value)
                            txtAddress.Text = dr["Address"].ToString();

                        if (dr["JobDurationYear"] != DBNull.Value)
                        {
                            decimal v = Convert.ToDecimal(dr["JobDurationYear"]);
                            nmJobYear.Value = Math.Max(nmJobYear.Minimum, Math.Min(nmJobYear.Maximum, v));
                        }

                        if (dr["TotalWorkDuration"] != DBNull.Value)
                        {
                            decimal v = Convert.ToDecimal(dr["TotalWorkDuration"]);
                            nmTotalWork.Value = Math.Max(nmTotalWork.Minimum, Math.Min(nmTotalWork.Maximum, v));
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Veri yükleme hatası: " + ex.Message); }
            }
        }

        
    }
}