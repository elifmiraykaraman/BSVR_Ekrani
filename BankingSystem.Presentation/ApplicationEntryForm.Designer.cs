namespace BankingSystem.Presentation
{
    partial class ApplicationEntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSearch = new Button();
            lblSearchTitle = new Label();
            txtSearchCustomerNumber = new TextBox();
            dgvApplications = new DataGridView();
            colTransactionDate = new DataGridViewTextBoxColumn();
            colReferenceNo = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colProductCode = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            calAmount = new DataGridViewTextBoxColumn();
            colInstallments = new DataGridViewTextBoxColumn();
            btnNewApplication = new Button();
            btnDetails = new Button();
            btnClear = new Button();
            btnExit = new Button();
            label1 = new Label();
            lblIdentityValue = new Label();
            label2 = new Label();
            label3 = new Label();
            lblFirstNameValue = new Label();
            lblLastNameValue = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.MenuHighlight;
            btnSearch.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnSearch.ForeColor = SystemColors.ControlLightLight;
            btnSearch.Location = new Point(237, 30);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(96, 50);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "🔍 ARA";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.BackColorChanged += button1_BackColorChanged;
            btnSearch.ForeColorChanged += button1_ForeColorChanged;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.Location = new Point(12, 33);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(64, 15);
            lblSearchTitle.TabIndex = 1;
            lblSearchTitle.Text = "Müşteri no";
            // 
            // txtSearchCustomerNumber
            // 
            txtSearchCustomerNumber.Location = new Point(122, 30);
            txtSearchCustomerNumber.MaxLength = 8;
            txtSearchCustomerNumber.Name = "txtSearchCustomerNumber";
            txtSearchCustomerNumber.Size = new Size(100, 23);
            txtSearchCustomerNumber.TabIndex = 2;
            // 
            // dgvApplications
            // 
            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToOrderColumns = true;
            dgvApplications.BackgroundColor = SystemColors.Control;
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplications.Columns.AddRange(new DataGridViewColumn[] { colTransactionDate, colReferenceNo, colStatus, colCategory, colProductCode, colProductName, calAmount, colInstallments });
            dgvApplications.Location = new Point(12, 100);
            dgvApplications.MultiSelect = false;
            dgvApplications.Name = "dgvApplications";
            dgvApplications.ReadOnly = true;
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplications.Size = new Size(834, 341);
            dgvApplications.TabIndex = 3;
            // 
            // colTransactionDate
            // 
            colTransactionDate.DataPropertyName = "TransactionDate";
            colTransactionDate.HeaderText = "Başvuru Tarih/Zaman";
            colTransactionDate.Name = "colTransactionDate";
            colTransactionDate.ReadOnly = true;
            // 
            // colReferenceNo
            // 
            colReferenceNo.DataPropertyName = "ReferenceNumber";
            colReferenceNo.HeaderText = "Referans No";
            colReferenceNo.Name = "colReferenceNo";
            colReferenceNo.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Durum";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colCategory
            // 
            colCategory.DataPropertyName = "ProductCategory";
            colCategory.HeaderText = "Ürün Tipi";
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            // 
            // colProductCode
            // 
            colProductCode.DataPropertyName = "ProductCode";
            colProductCode.HeaderText = "Ürün Kodu";
            colProductCode.Name = "colProductCode";
            colProductCode.ReadOnly = true;
            // 
            // colProductName
            // 
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Ürün Adı";
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            // 
            // calAmount
            // 
            calAmount.DataPropertyName = "Amount";
            calAmount.HeaderText = "Tutar";
            calAmount.Name = "calAmount";
            calAmount.ReadOnly = true;
            // 
            // colInstallments
            // 
            colInstallments.DataPropertyName = "Installments";
            colInstallments.HeaderText = "Taksit";
            colInstallments.Name = "colInstallments";
            colInstallments.ReadOnly = true;
            // 
            // btnNewApplication
            // 
            btnNewApplication.BackColor = SystemColors.Highlight;
            btnNewApplication.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnNewApplication.ForeColor = SystemColors.ControlLightLight;
            btnNewApplication.Location = new Point(31, 447);
            btnNewApplication.Name = "btnNewApplication";
            btnNewApplication.Size = new Size(122, 23);
            btnNewApplication.TabIndex = 4;
            btnNewApplication.Text = "Yeni Başvuru";
            btnNewApplication.UseVisualStyleBackColor = false;
            btnNewApplication.Click += btnNewApplication_Click;
            // 
            // btnDetails
            // 
            btnDetails.BackColor = SystemColors.Highlight;
            btnDetails.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnDetails.ForeColor = SystemColors.ControlLightLight;
            btnDetails.Location = new Point(207, 447);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(75, 23);
            btnDetails.TabIndex = 5;
            btnDetails.Text = "Detay";
            btnDetails.UseVisualStyleBackColor = false;
            btnDetails.Click += btnDetails_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.Highlight;
            btnClear.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnClear.ForeColor = SystemColors.ControlLightLight;
            btnClear.Location = new Point(345, 447);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 6;
            btnClear.Text = "Temizle";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClearForm;
            // 
            // btnExit
            // 
            btnExit.BackColor = SystemColors.Highlight;
            btnExit.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnExit.ForeColor = SystemColors.ControlLightLight;
            btnExit.Location = new Point(466, 447);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 7;
            btnExit.Text = "Çıkış  ➔ ";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 69);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 8;
            label1.Text = "TC Kimlik no";
            // 
            // lblIdentityValue
            // 
            lblIdentityValue.AutoSize = true;
            lblIdentityValue.Location = new Point(122, 69);
            lblIdentityValue.Name = "lblIdentityValue";
            lblIdentityValue.Size = new Size(0, 15);
            lblIdentityValue.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(382, 33);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 10;
            label2.Text = "İsim";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(382, 69);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 11;
            label3.Text = "Soyisim";
            // 
            // lblFirstNameValue
            // 
            lblFirstNameValue.AutoSize = true;
            lblFirstNameValue.Location = new Point(455, 32);
            lblFirstNameValue.Name = "lblFirstNameValue";
            lblFirstNameValue.Size = new Size(0, 15);
            lblFirstNameValue.TabIndex = 12;
            // 
            // lblLastNameValue
            // 
            lblLastNameValue.AutoSize = true;
            lblLastNameValue.Location = new Point(455, 69);
            lblLastNameValue.Name = "lblLastNameValue";
            lblLastNameValue.Size = new Size(0, 15);
            lblLastNameValue.TabIndex = 13;
            // 
            // ApplicationEntryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 479);
            Controls.Add(lblLastNameValue);
            Controls.Add(lblFirstNameValue);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblIdentityValue);
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(btnClear);
            Controls.Add(btnDetails);
            Controls.Add(btnNewApplication);
            Controls.Add(dgvApplications);
            Controls.Add(txtSearchCustomerNumber);
            Controls.Add(lblSearchTitle);
            Controls.Add(btnSearch);
            Name = "ApplicationEntryForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button btnSearch;
        private Label lblSearchTitle;
        private TextBox txtSearchCustomerNumber;
        private DataGridView dgvApplications;
        private Button btnNewApplication;
        private Button btnDetails;
        private Button btnClear;
        private Button btnExit;
        private Label label1;
        private Label lblIdentityValue;
        private DataGridViewTextBoxColumn colTransactionDate;
        private DataGridViewTextBoxColumn colReferenceNo;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colProductCode;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn calAmount;
        private DataGridViewTextBoxColumn colInstallments;
        private Label label2;
        private Label label3;
        private Label lblFirstNameValue;
        private Label lblLastNameValue;
        private EventHandler ApplicationEntryForm_Load;
    }
}