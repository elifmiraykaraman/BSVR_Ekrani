namespace BankingSystem.Presentation
{
    partial class FormNewApplication
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
            txtCustNumber = new TextBox();
            musterino = new Label();
            phone = new Label();
            txtPhone = new TextBox();
            label3 = new Label();
            txtAppDate = new TextBox();
            groupBox1 = new GroupBox();
            txtRefNo = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            txtInstallmentAmount = new MaskedTextBox();
            label6 = new Label();
            txtMaturity = new TextBox();
            label5 = new Label();
            txtCreditAmount = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label1 = new Label();
            btnSelectProduct = new Button();
            txtProduct = new TextBox();
            groupBox3 = new GroupBox();
            btnMinimumWage = new Button();
            txtIncomeAmount = new TextBox();
            label7 = new Label();
            cmbIncomeType = new ComboBox();
            btnKaydet = new Button();
            btnTemizle = new Button();
            btnCikis = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // txtCustNumber
            // 
            txtCustNumber.Location = new Point(88, 25);
            txtCustNumber.Name = "txtCustNumber";
            txtCustNumber.ReadOnly = true;
            txtCustNumber.Size = new Size(100, 23);
            txtCustNumber.TabIndex = 0;
            // 
            // musterino
            // 
            musterino.AutoSize = true;
            musterino.Location = new Point(6, 30);
            musterino.Name = "musterino";
            musterino.Size = new Size(66, 15);
            musterino.TabIndex = 1;
            musterino.Text = "Müşteri No";
            // 
            // phone
            // 
            phone.AutoSize = true;
            phone.Location = new Point(26, 73);
            phone.Name = "phone";
            phone.Size = new Size(46, 15);
            phone.TabIndex = 2;
            phone.Text = "Cep Tel";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(88, 70);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(100, 23);
            txtPhone.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(217, 30);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 4;
            label3.Text = "Başvuru Tarihi";
            // 
            // txtAppDate
            // 
            txtAppDate.Location = new Point(317, 22);
            txtAppDate.Name = "txtAppDate";
            txtAppDate.ReadOnly = true;
            txtAppDate.Size = new Size(100, 23);
            txtAppDate.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtRefNo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtAppDate);
            groupBox1.Controls.Add(phone);
            groupBox1.Controls.Add(txtCustNumber);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(musterino);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 110);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Başvuru Bilgileri";
            // 
            // txtRefNo
            // 
            txtRefNo.Location = new Point(317, 70);
            txtRefNo.Name = "txtRefNo";
            txtRefNo.ReadOnly = true;
            txtRefNo.Size = new Size(100, 23);
            txtRefNo.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(255, 73);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 6;
            label2.Text = "Ref No";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtInstallmentAmount);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtMaturity);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtCreditAmount);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(btnSelectProduct);
            groupBox2.Controls.Add(txtProduct);
            groupBox2.Location = new Point(12, 147);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(776, 150);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ürün/Gelir/teminat Bilgileri";
            // 
            // txtInstallmentAmount
            // 
            txtInstallmentAmount.Location = new Point(329, 85);
            txtInstallmentAmount.Name = "txtInstallmentAmount";
            txtInstallmentAmount.ReadOnly = true;
            txtInstallmentAmount.Size = new Size(100, 23);
            txtInstallmentAmount.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(240, 88);
            label6.Name = "label6";
            label6.Size = new Size(71, 15);
            label6.TabIndex = 8;
            label6.Text = "Taksit Tutarı";
            // 
            // txtMaturity
            // 
            txtMaturity.Location = new Point(109, 106);
            txtMaturity.Name = "txtMaturity";
            txtMaturity.Size = new Size(100, 23);
            txtMaturity.TabIndex = 7;
            txtMaturity.TextChanged += textBox5_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 109);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 6;
            label5.Text = "Kredi Vadesi";
            // 
            // txtCreditAmount
            // 
            txtCreditAmount.Location = new Point(109, 63);
            txtCreditAmount.Name = "txtCreditAmount";
            txtCreditAmount.Size = new Size(100, 23);
            txtCreditAmount.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 71);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 4;
            label4.Text = "Kredi Tutarı";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(110, 28);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(75, 23);
            textBox3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 30);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 2;
            label1.Text = "Başvurulan Ürün";
            // 
            // btnSelectProduct
            // 
            btnSelectProduct.BackColor = SystemColors.Highlight;
            btnSelectProduct.ForeColor = SystemColors.ControlLightLight;
            btnSelectProduct.Location = new Point(191, 14);
            btnSelectProduct.Name = "btnSelectProduct";
            btnSelectProduct.Size = new Size(59, 43);
            btnSelectProduct.TabIndex = 1;
            btnSelectProduct.Text = "SEÇ";
            btnSelectProduct.UseVisualStyleBackColor = false;
            // 
            // txtProduct
            // 
            txtProduct.Location = new Point(256, 28);
            txtProduct.Multiline = true;
            txtProduct.Name = "txtProduct";
            txtProduct.ReadOnly = true;
            txtProduct.Size = new Size(235, 23);
            txtProduct.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnMinimumWage);
            groupBox3.Controls.Add(txtIncomeAmount);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(cmbIncomeType);
            groupBox3.Location = new Point(12, 313);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(776, 100);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            // 
            // btnMinimumWage
            // 
            btnMinimumWage.BackColor = SystemColors.Highlight;
            btnMinimumWage.ForeColor = SystemColors.ControlLightLight;
            btnMinimumWage.Location = new Point(448, 28);
            btnMinimumWage.Name = "btnMinimumWage";
            btnMinimumWage.Size = new Size(92, 36);
            btnMinimumWage.TabIndex = 3;
            btnMinimumWage.Text = "Asgari Ücret";
            btnMinimumWage.UseVisualStyleBackColor = false;
            btnMinimumWage.Click += btnMinimumWage_Click;
            // 
            // txtIncomeAmount
            // 
            txtIncomeAmount.Location = new Point(295, 25);
            txtIncomeAmount.Name = "txtIncomeAmount";
            txtIncomeAmount.Size = new Size(100, 23);
            txtIncomeAmount.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 28);
            label7.Name = "label7";
            label7.Size = new Size(121, 15);
            label7.TabIndex = 1;
            label7.Text = "Gelir Tip / Beyan Gelir";
            // 
            // cmbIncomeType
            // 
            cmbIncomeType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIncomeType.FormattingEnabled = true;
            cmbIncomeType.Items.AddRange(new object[] { "Serbest", "Ücretli", "Emekli" });
            cmbIncomeType.Location = new Point(140, 25);
            cmbIncomeType.Name = "cmbIncomeType";
            cmbIncomeType.Size = new Size(121, 23);
            cmbIncomeType.TabIndex = 0;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = SystemColors.Highlight;
            btnKaydet.ForeColor = SystemColors.ControlLightLight;
            btnKaydet.Location = new Point(477, 440);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(75, 23);
            btnKaydet.TabIndex = 10;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = SystemColors.Highlight;
            btnTemizle.ForeColor = SystemColors.ControlLightLight;
            btnTemizle.Location = new Point(587, 440);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(75, 23);
            btnTemizle.TabIndex = 11;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnCikis
            // 
            btnCikis.BackColor = SystemColors.Highlight;
            btnCikis.ForeColor = SystemColors.ControlLightLight;
            btnCikis.Location = new Point(691, 440);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(75, 23);
            btnCikis.TabIndex = 12;
            btnCikis.Text = "Çıkış";
            btnCikis.UseVisualStyleBackColor = false;
            // 
            // FormNewApplication
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 486);
            Controls.Add(btnCikis);
            Controls.Add(btnTemizle);
            Controls.Add(btnKaydet);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormNewApplication";
            Text = "FormNewApllication";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtCustNumber;
        private Label musterino;
        private Label phone;
        private TextBox txtPhone;
        private Label label3;
        private TextBox txtAppDate;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtProduct;
        private Label label1;
        private Button btnSelectProduct;
        private TextBox txtMaturity;
        private Label label5;
        private TextBox txtCreditAmount;
        private Label label4;
        private TextBox textBox3;
        private MaskedTextBox txtInstallmentAmount;
        private Label label6;
        private GroupBox groupBox3;
        private Label label7;
        private ComboBox cmbIncomeType;
        private Button btnMinimumWage;
        private TextBox txtIncomeAmount;
        private EventHandler FormNewApplication_Load;
        private TextBox txtRefNo;
        private Label label2;
        private Button btnKaydet;
        private Button btnTemizle;
        private Button btnCikis;
    }
}