using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace BankingSystem.Presentation
{
    public partial class FormProductSelection : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedProductId { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedProductName { get; set; } = string.Empty;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedProductCode { get; set; } = string.Empty;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedCategory { get; set; } = string.Empty;

        private string connString = @"Server=.\SQLEXPRESS; Database=CoreBankingSystem; Integrated Security=True; TrustServerCertificate=True;";

        public FormProductSelection()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "SELECT ProductID, ProductCode, ProductName FROM Products WHERE IsActive = 1";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProductList.DataSource = dt;

                    if (dgvProductList.Columns["ProductID"] != null)
                        dgvProductList.Columns["ProductID"].Visible = false;

                    dgvProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT ProductID, ProductCode, ProductName FROM Products WHERE IsActive = 1 AND ProductName LIKE @name";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@name", "%" + txtProductNameSearch.Text + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProductList.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama hatası: " + ex.Message);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (txtProductNameSearch != null) txtProductNameSearch.Clear();
            foreach (Control c in groupBox1.Controls)
            {
                if (c is CheckBox cb) cb.Checked = false;
            }
            LoadProducts();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (dgvProductList.CurrentRow != null)
            {
                SelectedProductId = Convert.ToInt32(dgvProductList.CurrentRow.Cells["ProductID"].Value);
                SelectedProductCode = dgvProductList.CurrentRow.Cells["ProductCode"].Value?.ToString() ?? "";
                SelectedProductName = dgvProductList.CurrentRow.Cells["ProductName"].Value?.ToString() ?? "";

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen listeden bir ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
