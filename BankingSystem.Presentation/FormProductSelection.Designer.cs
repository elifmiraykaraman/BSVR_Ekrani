namespace BankingSystem.Presentation
{
    partial class FormProductSelection
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
            groupBox2 = new GroupBox();
            btnTemizle = new Button();
            btnAra = new Button();
            txtProductNameSearch = new TextBox();
            label1 = new Label();
            dgvProductList = new DataGridView();
            btnSec = new Button();
            btnExit = new Button();
            cbIhtiyac = new CheckBox();
            cbKonut = new CheckBox();
            cbTasit = new CheckBox();
            cbBonus = new CheckBox();
            cbPlatinum = new CheckBox();
            cbMaas = new CheckBox();
            cbParaf = new CheckBox();
            cbParafly = new CheckBox();
            cbParafGenc = new CheckBox();
            cbDijitalKart = new CheckBox();
            cbDijitalKartTroy = new CheckBox();
            cbDijitalGencKart = new CheckBox();
            cbHalkCard = new CheckBox();
            cbLogolu = new CheckBox();
            cbİpotekli = new CheckBox();
            groupBox1 = new GroupBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductList).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnTemizle);
            groupBox2.Controls.Add(btnAra);
            groupBox2.Controls.Add(txtProductNameSearch);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(15, 219);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(773, 47);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = SystemColors.Highlight;
            btnTemizle.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnTemizle.ForeColor = SystemColors.ControlLightLight;
            btnTemizle.Location = new Point(599, 15);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(75, 23);
            btnTemizle.TabIndex = 3;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnAra
            // 
            btnAra.BackColor = SystemColors.Highlight;
            btnAra.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnAra.ForeColor = SystemColors.ControlLightLight;
            btnAra.Location = new Point(505, 15);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(75, 23);
            btnAra.TabIndex = 2;
            btnAra.Text = "ARA";
            btnAra.UseVisualStyleBackColor = false;
            btnAra.Click += btnAra_Click;
            // 
            // txtProductNameSearch
            // 
            txtProductNameSearch.Location = new Point(74, 15);
            txtProductNameSearch.Name = "txtProductNameSearch";
            txtProductNameSearch.Size = new Size(414, 23);
            txtProductNameSearch.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 18);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Ürün Adı :";
            // 
            // dgvProductList
            // 
            dgvProductList.AllowUserToAddRows = false;
            dgvProductList.AllowUserToDeleteRows = false;
            dgvProductList.BackgroundColor = SystemColors.ControlLightLight;
            dgvProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductList.GridColor = SystemColors.ScrollBar;
            dgvProductList.Location = new Point(15, 291);
            dgvProductList.Name = "dgvProductList";
            dgvProductList.ReadOnly = true;
            dgvProductList.Size = new Size(773, 404);
            dgvProductList.TabIndex = 2;
            dgvProductList.DoubleClick += btnSec_Click;
            // 
            // btnSec
            // 
            btnSec.BackColor = SystemColors.Highlight;
            btnSec.ForeColor = SystemColors.ControlLightLight;
            btnSec.Location = new Point(520, 718);
            btnSec.Name = "btnSec";
            btnSec.Size = new Size(75, 23);
            btnSec.TabIndex = 4;
            btnSec.Text = "Seç";
            btnSec.UseVisualStyleBackColor = false;
            btnSec.Click += btnSec_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = SystemColors.Highlight;
            btnExit.ForeColor = SystemColors.ControlLightLight;
            btnExit.Location = new Point(614, 718);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 8;
            btnExit.Text = "Çıkış  ➔ ";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // cbIhtiyac
            // 
            cbIhtiyac.AutoSize = true;
            cbIhtiyac.Location = new Point(13, 40);
            cbIhtiyac.Name = "cbIhtiyac";
            cbIhtiyac.Size = new Size(99, 19);
            cbIhtiyac.TabIndex = 0;
            cbIhtiyac.Text = "İhtiyaç Kredisi";
            cbIhtiyac.UseVisualStyleBackColor = true;
            // 
            // cbKonut
            // 
            cbKonut.AutoSize = true;
            cbKonut.Location = new Point(13, 88);
            cbKonut.Name = "cbKonut";
            cbKonut.Size = new Size(96, 19);
            cbKonut.TabIndex = 1;
            cbKonut.Text = "Konut Kredisi";
            cbKonut.UseVisualStyleBackColor = true;
            // 
            // cbTasit
            // 
            cbTasit.AutoSize = true;
            cbTasit.Location = new Point(13, 136);
            cbTasit.Name = "cbTasit";
            cbTasit.Size = new Size(88, 19);
            cbTasit.TabIndex = 2;
            cbTasit.Text = "Taşıt Kredisi";
            cbTasit.UseVisualStyleBackColor = true;
            // 
            // cbBonus
            // 
            cbBonus.AutoSize = true;
            cbBonus.Location = new Point(161, 40);
            cbBonus.Name = "cbBonus";
            cbBonus.Size = new Size(116, 19);
            cbBonus.TabIndex = 3;
            cbBonus.Text = "Bonus Kredi Kartı";
            cbBonus.UseVisualStyleBackColor = true;
            // 
            // cbPlatinum
            // 
            cbPlatinum.AutoSize = true;
            cbPlatinum.Location = new Point(161, 88);
            cbPlatinum.Name = "cbPlatinum";
            cbPlatinum.Size = new Size(98, 19);
            cbPlatinum.TabIndex = 4;
            cbPlatinum.Text = "Platinum Kart";
            cbPlatinum.UseVisualStyleBackColor = true;
            // 
            // cbMaas
            // 
            cbMaas.AutoSize = true;
            cbMaas.Location = new Point(161, 136);
            cbMaas.Name = "cbMaas";
            cbMaas.Size = new Size(92, 19);
            cbMaas.TabIndex = 5;
            cbMaas.Text = "Maaş Avansı";
            cbMaas.UseVisualStyleBackColor = true;
            // 
            // cbParaf
            // 
            cbParaf.AutoSize = true;
            cbParaf.Location = new Point(323, 40);
            cbParaf.Name = "cbParaf";
            cbParaf.Size = new Size(53, 19);
            cbParaf.TabIndex = 6;
            cbParaf.Text = "Paraf";
            cbParaf.UseVisualStyleBackColor = true;
            // 
            // cbParafly
            // 
            cbParafly.AutoSize = true;
            cbParafly.Location = new Point(323, 88);
            cbParafly.Name = "cbParafly";
            cbParafly.Size = new Size(62, 19);
            cbParafly.TabIndex = 7;
            cbParafly.Text = "Parafly";
            cbParafly.UseVisualStyleBackColor = true;
            // 
            // cbParafGenc
            // 
            cbParafGenc.AutoSize = true;
            cbParafGenc.Location = new Point(323, 136);
            cbParafGenc.Name = "cbParafGenc";
            cbParafGenc.Size = new Size(83, 19);
            cbParafGenc.TabIndex = 8;
            cbParafGenc.Text = "Paraf Genç";
            cbParafGenc.UseVisualStyleBackColor = true;
            // 
            // cbDijitalKart
            // 
            cbDijitalKart.AutoSize = true;
            cbDijitalKart.Location = new Point(452, 40);
            cbDijitalKart.Name = "cbDijitalKart";
            cbDijitalKart.Size = new Size(80, 19);
            cbDijitalKart.TabIndex = 9;
            cbDijitalKart.Text = "Dijital Kart";
            cbDijitalKart.UseVisualStyleBackColor = true;
            // 
            // cbDijitalKartTroy
            // 
            cbDijitalKartTroy.AutoSize = true;
            cbDijitalKartTroy.Location = new Point(452, 88);
            cbDijitalKartTroy.Name = "cbDijitalKartTroy";
            cbDijitalKartTroy.Size = new Size(106, 19);
            cbDijitalKartTroy.TabIndex = 10;
            cbDijitalKartTroy.Text = "Dijital Kart Troy";
            cbDijitalKartTroy.UseVisualStyleBackColor = true;
            // 
            // cbDijitalGencKart
            // 
            cbDijitalGencKart.AutoSize = true;
            cbDijitalGencKart.Location = new Point(452, 136);
            cbDijitalGencKart.Name = "cbDijitalGencKart";
            cbDijitalGencKart.Size = new Size(110, 19);
            cbDijitalGencKart.TabIndex = 11;
            cbDijitalGencKart.Text = "Dijital Genç Kart";
            cbDijitalGencKart.UseVisualStyleBackColor = true;
            // 
            // cbHalkCard
            // 
            cbHalkCard.AutoSize = true;
            cbHalkCard.Location = new Point(604, 40);
            cbHalkCard.Name = "cbHalkCard";
            cbHalkCard.Size = new Size(75, 19);
            cbHalkCard.TabIndex = 12;
            cbHalkCard.Text = "HalkCard";
            cbHalkCard.UseVisualStyleBackColor = true;
            // 
            // cbLogolu
            // 
            cbLogolu.AutoSize = true;
            cbLogolu.Location = new Point(604, 88);
            cbLogolu.Name = "cbLogolu";
            cbLogolu.Size = new Size(63, 19);
            cbLogolu.TabIndex = 13;
            cbLogolu.Text = "Logolu";
            cbLogolu.UseVisualStyleBackColor = true;
            // 
            // cbİpotekli
            // 
            cbİpotekli.AutoSize = true;
            cbİpotekli.Location = new Point(604, 136);
            cbİpotekli.Name = "cbİpotekli";
            cbİpotekli.Size = new Size(141, 19);
            cbİpotekli.TabIndex = 14;
            cbİpotekli.Text = "İpotekli Destek Kredisi";
            cbİpotekli.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbİpotekli);
            groupBox1.Controls.Add(cbLogolu);
            groupBox1.Controls.Add(cbHalkCard);
            groupBox1.Controls.Add(cbDijitalGencKart);
            groupBox1.Controls.Add(cbDijitalKartTroy);
            groupBox1.Controls.Add(cbDijitalKart);
            groupBox1.Controls.Add(cbParafGenc);
            groupBox1.Controls.Add(cbParafly);
            groupBox1.Controls.Add(cbParaf);
            groupBox1.Controls.Add(cbMaas);
            groupBox1.Controls.Add(cbPlatinum);
            groupBox1.Controls.Add(cbBonus);
            groupBox1.Controls.Add(cbTasit);
            groupBox1.Controls.Add(cbKonut);
            groupBox1.Controls.Add(cbIhtiyac);
            groupBox1.Location = new Point(10, 19);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(778, 186);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ürün Tipi Seçimi";
            // 
            // FormProductSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 755);
            Controls.Add(btnExit);
            Controls.Add(btnSec);
            Controls.Add(dgvProductList);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormProductSelection";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox2;
        private Button btnTemizle;
        private Button btnAra;
        private TextBox txtProductNameSearch;
        private Label label1;
        private DataGridView dgvProductList;
        private Button btnSec;
        private Button btnExit;
        private CheckBox cbIhtiyac;
        private CheckBox cbKonut;
        private CheckBox cbTasit;
        private CheckBox cbBonus;
        private CheckBox cbPlatinum;
        private CheckBox cbMaas;
        private CheckBox cbParaf;
        private CheckBox cbParafly;
        private CheckBox cbParafGenc;
        private CheckBox cbDijitalKart;
        private CheckBox cbDijitalKartTroy;
        private CheckBox cbDijitalGencKart;
        private CheckBox cbHalkCard;
        private CheckBox cbLogolu;
        private CheckBox cbİpotekli;
        private GroupBox groupBox1;
    }
}