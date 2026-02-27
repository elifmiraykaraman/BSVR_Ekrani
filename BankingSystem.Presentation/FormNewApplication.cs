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

        public FormNewApplication(int custId, string custNum, string phone)
        {
            InitializeComponent(); // Bu en üstte kalmalı!

            this.selectedCustomerId = custId;

            txtCustNumber.Text = custNum;
            txtPhone.Text = phone;
            txtAppDate.Text = DateTime.Now.ToShortDateString();
            txtRefNo.Text = GenerateReferenceNumber();
        }

        private void btnMinimumWage_Click(object sender, EventArgs e)
        {
            txtIncomeAmount.Text = "22104";
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
            if (string.IsNullOrEmpty(txtCreditAmount.Text) || string.IsNullOrEmpty(txtProduct.Text))
            {
                MessageBox.Show("Lütfen ürün seçin ve kredi tutarını girin!");
                return;
            }

            string connString = @"Server=.\SQLEXPRESS; Database=CoreBankingSystem; Integrated Security=True; TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"INSERT INTO Applications 
            (CustomerID, ProductID, ReferenceNumber, TransactionDate, Status, Amount, Installments, IncomeType, IncomeAmount) 
            VALUES (@custId, @prodId, @refNo, @tDate, @status, @amount, @inst, @incType, @incAmount)";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Formdaki verileri parametre olarak ekliyoruz
                cmd.Parameters.AddWithValue("@custId", this.selectedCustomerId); // Arama sonucunda gelen ID
                cmd.Parameters.AddWithValue("@prodId", 1); // Şimdilik 1 veriyoruz, Seç butonuyla güncelleyeceğiz
                cmd.Parameters.AddWithValue("@refNo", txtRefNo.Text);
                cmd.Parameters.AddWithValue("@tDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@status", "Beklemede");
                cmd.Parameters.AddWithValue("@amount", decimal.Parse(txtCreditAmount.Text));
                cmd.Parameters.AddWithValue("@inst", int.Parse(txtMaturity.Text));
                cmd.Parameters.AddWithValue("@incType", cmbIncomeType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@incAmount", decimal.Parse(txtIncomeAmount.Text));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Başvuru başarıyla kaydedildi! \nReferans No: " + txtRefNo.Text);
                    this.Close(); // Kayıttan sonra formu kapat
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt hatası: " + ex.Message);
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
    }
}
