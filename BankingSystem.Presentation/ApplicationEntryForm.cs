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
    public partial class ApplicationEntryForm : Form
    {
        private int currentCustomerId;
        public ApplicationEntryForm()
        {
            InitializeComponent();
        }

        private void button1_ForeColorChanged(object sender, EventArgs e)
        {

        }

        private void button1_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtSearchCustomerNumber.Text.Length != 8)
            {
                MessageBox.Show("Lütfen 8 haneli müşteri numarasını tam giriniz.");
                return;
            }

            string connString = @"Server=.\SQLEXPRESS; Database=CoreBankingSystem; Integrated Security=True; TrustServerCertificate=True;"; using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string customerQuery = "SELECT CustomerID, IdentityNumber, FirstName, LastName FROM Customers WHERE CustomerNumber = @custNum";
                    SqlCommand cmd = new SqlCommand(customerQuery, conn);

                    cmd.Parameters.Add("@custNum", SqlDbType.Int).Value = int.Parse(txtSearchCustomerNumber.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        this.currentCustomerId = (int)reader["CustomerID"];
                        lblIdentityValue.Text = reader["IdentityNumber"].ToString();
                        lblFirstNameValue.Text = reader["FirstName"].ToString();
                        lblLastNameValue.Text = reader["LastName"].ToString();

                        reader.Close();

                        string appQuery = @"
                            SELECT 
                             a.TransactionDate AS [TransactionDate], -- DataPropertyName ile aynı olmalı
                             a.ReferenceNumber AS [ReferenceNumber],
                             a.Status AS [Status],
                             p.ProductCategory AS [ProductCategory],
                             p.ProductCode AS [ProductCode],
                             p.ProductName AS [ProductName],
                             a.Amount AS [Amount],
                             a.Installments AS [Installments]
                                FROM Applications a
                                INNER JOIN Products p ON a.ProductID = p.ProductID
                                INNER JOIN Customers c ON a.CustomerID = c.CustomerID
                                WHERE c.CustomerNumber = @custNum";

                        SqlDataAdapter da = new SqlDataAdapter(appQuery, conn);
                        da.SelectCommand.Parameters.AddWithValue("@custNum", int.Parse(txtSearchCustomerNumber.Text));

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dgvApplications.DataSource = null;
                            dgvApplications.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Müşteri bulundu fakat bu müşteriye ait hiçbir işlem (Application) kaydı yok!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }


        private void btnClearForm(object sender, EventArgs e)
        {
            txtSearchCustomerNumber.Clear();

            lblIdentityValue.Text = "---";
            lblFirstNameValue.Text = "---";
            lblLastNameValue.Text = "---";

            dgvApplications.DataSource = null;

            txtSearchCustomerNumber.Focus();
        }

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            if (lblFirstNameValue.Text == "label4" || string.IsNullOrEmpty(txtSearchCustomerNumber.Text))
            {
                MessageBox.Show("Lütfen önce bir müşteri aratın!");
                return;
            }

            FormNewApplication frm = new FormNewApplication(this.currentCustomerId, txtSearchCustomerNumber.Text, "05XXXXXXXXX");
            frm.ShowDialog();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvApplications.CurrentRow != null)
            {
                string refNo = dgvApplications.CurrentRow.Cells["colReferenceNo"].Value.ToString();
                FormNewApplication detayFormu = new FormNewApplication(this.currentCustomerId, txtSearchCustomerNumber.Text, "");
                detayFormu.IsReadOnly = true;
                detayFormu.BasvuruReferansNo = refNo;
                detayFormu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen listeden bir başvuru seçin.");
            }
        }
    }
}

