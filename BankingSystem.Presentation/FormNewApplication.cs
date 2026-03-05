using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BankingSystem.Presentation
{
    public partial class FormNewApplication : Form
    {
        private int selectedCustomerId;
        private int currentSelectedProductId;

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



        private string GenerateReferenceNumber()
        {
            Random res = new Random();
            string str = "";
            for (int i = 0; i < 10; i++)
            {
                str += res.Next(0, 10).ToString();
            }
            return str;
        }

        private void ApplicationEntryForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string connString = @"Server=.\SQLEXPRESS; Database=CoreBankingSystem; Integrated Security=True; TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"INSERT INTO Applications 
            (CustomerID, ProductID, ReferenceNumber, TransactionDate, Status, Amount, Installments) 
            VALUES (@custId, @prodId, @ref, GETDATE(), 'Beklemede', @amt, @inst)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@custId", this.selectedCustomerId);
                cmd.Parameters.AddWithValue("@prodId", this.currentProductId); // Değişken adını buna çevir
                cmd.Parameters.AddWithValue("@ref", txtRefNo.Text);
                cmd.Parameters.AddWithValue("@amt", decimal.Parse(txtCreditAmount.Text));
                cmd.Parameters.AddWithValue("@inst", int.Parse(txtMaturity.Text));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Başvuru başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    btnKaydet.Enabled = false;
                    this.tabControl1.SelectedIndex = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt Hatası: " + ex.Message);
                }
            }
        }


        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtCreditAmount.Clear();
            txtMaturity.Clear();
            txtIncomeAmount.Clear();
            txtProduct.Clear();
            txtInstallmentAmount.Clear();

            txtRefNo.Text = GenerateReferenceNumber();

            cmbIncomeType.SelectedIndex = 0;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void HesaplaTaksit()
        {
            if (decimal.TryParse(txtCreditAmount.Text, out decimal tutar) &&
                int.TryParse(txtMaturity.Text, out int vade) && vade > 0)
            {
                decimal taksit = tutar / vade;
                txtInstallmentAmount.Text = taksit.ToString("N2"); // İki ondalık basamakla göster
            }
        }

        private int currentProductId;

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
            string connString = @"Server=.\SQLEXPRESS; Database=CoreBankingSystem; Integrated Security=True; TrustServerCertificate=True;";
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
                        // Tasarımdaki ReadOnly TextBox isimlerinle eşleştir
                        txtCustNoPersonal.Text = dr["CustomerNumber"].ToString();
                        txtFirstName.Text = dr["FirstName"].ToString();
                        txtLastName.Text = dr["LastName"].ToString();
                        if (dr["BirthDate"] != DBNull.Value)
                            txtBirthDate.Text = Convert.ToDateTime(dr["BirthDate"]).ToShortDateString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            string connString = @"Server=.\SQLEXPRESS; Database=CoreBankingSystem; Integrated Security=True; TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"UPDATE Customers SET 
                        HouseStatus = @house, 
                        Address = @address, 
                        ResidenceDuration = @resDur, 
                        JobDurationYear = @jobY, 
                        JobDurationMonth = @jobM, 
                        FirmActivityYear = @firmY,
                        FirmActivityMonth = @firmM,
                        TotalWorkDuration = @totalWork,
                        EmployeeCount = @empCount
                        WHERE CustomerID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@house", cmbHouseStatus.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@resDur", (int)nmResidenceYear.Value);
                cmd.Parameters.AddWithValue("@jobY", (int)nmJobYear.Value);
                cmd.Parameters.AddWithValue("@jobM", (int)nmJobMonth.Value);
                cmd.Parameters.AddWithValue("@firmY", (int)nmFirmYear.Value);
                cmd.Parameters.AddWithValue("@firmM", (int)nmFirmMonth.Value);
                cmd.Parameters.AddWithValue("@totalWork", (int)nmTotalWork.Value);
                cmd.Parameters.AddWithValue("@empCount", txtEmployeeCount.Text);
                cmd.Parameters.AddWithValue("@id", this.selectedCustomerId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kişisel ve Mesleki bilgiler başarıyla kaydedildi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt Hatası: " + ex.Message);
                }
            }
        }

        private void btnOnay1_Click(object sender, EventArgs e)
        {
            string refNo = txtRefNo.Text;
            UpdateApplicationStatus(refNo, "Onaylandı");

            label29.Text = "İŞLEM DURUMU: BAŞVURU ONAYLANDI";
            label29.ForeColor = Color.DarkGreen;
        }

        private void btnIptalRed_Click(object sender, EventArgs e)
        {
            string refNo = txtRefNo.Text;
            UpdateApplicationStatus(refNo, "Reddedildi");

            label29.Text = "İŞLEM DURUMU: BAŞVURU REDDEDİLDİ";
            label29.ForeColor = Color.Red;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateApplicationStatus(string refNo, string newStatus)
        {
            string connString = @"Server=.\SQLEXPRESS; Database=CoreBankingSystem; Integrated Security=True; TrustServerCertificate=True;";

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
                    MessageBox.Show($"Başvuru durumu başarıyla '{newStatus}' olarak güncellendi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Durum Güncelleme Hatası: " + ex.Message);
                }
            }
        }

        private void btnMinimumWage_Click_1(object sender, EventArgs e)
        {
            txtIncomeAmount.Text = "22104";
        }

       
    }
}
