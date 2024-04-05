namespace Ticari_Otomasyon
{
    partial class FrmBankalar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBankalar));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.CmbIlce = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CmbIl = new DevExpress.XtraEditors.ComboBoxEdit();
            this.MskTarih = new System.Windows.Forms.MaskedTextBox();
            this.MskTelefon = new System.Windows.Forms.MaskedTextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.LkpFirma = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.TxtHesapTuru = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.TxtHesapNo = new System.Windows.Forms.MaskedTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TxtIban = new System.Windows.Forms.MaskedTextBox();
            this.BtnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnGüncelle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSil = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.TxtYetkili = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.TxtSube = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.TxtBankaAdı = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TxtID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbIlce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbIl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LkpFirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtHesapTuru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtYetkili.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSube.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankaAdı.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.LemonChiffon;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(2, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1650, 727);
            this.gridControl1.TabIndex = 17;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // CmbIlce
            // 
            this.CmbIlce.Location = new System.Drawing.Point(94, 126);
            this.CmbIlce.Name = "CmbIlce";
            this.CmbIlce.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.CmbIlce.Properties.Appearance.Options.UseFont = true;
            this.CmbIlce.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbIlce.Size = new System.Drawing.Size(143, 24);
            this.CmbIlce.TabIndex = 2;
            // 
            // CmbIl
            // 
            this.CmbIl.Location = new System.Drawing.Point(94, 96);
            this.CmbIl.Name = "CmbIl";
            this.CmbIl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.CmbIl.Properties.Appearance.Options.UseFont = true;
            this.CmbIl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbIl.Size = new System.Drawing.Size(143, 24);
            this.CmbIl.TabIndex = 1;
            this.CmbIl.SelectedIndexChanged += new System.EventHandler(this.CmbIl_SelectedIndexChanged);
            // 
            // MskTarih
            // 
            this.MskTarih.Font = new System.Drawing.Font("Tahoma", 11F);
            this.MskTarih.Location = new System.Drawing.Point(94, 308);
            this.MskTarih.Mask = "00/00/0000";
            this.MskTarih.Name = "MskTarih";
            this.MskTarih.Size = new System.Drawing.Size(143, 25);
            this.MskTarih.TabIndex = 8;
            this.MskTarih.ValidatingType = typeof(System.DateTime);
            // 
            // MskTelefon
            // 
            this.MskTelefon.Font = new System.Drawing.Font("Tahoma", 11F);
            this.MskTelefon.Location = new System.Drawing.Point(94, 277);
            this.MskTelefon.Mask = "(999) 000-0000";
            this.MskTelefon.Name = "MskTelefon";
            this.MskTelefon.Size = new System.Drawing.Size(143, 25);
            this.MskTelefon.TabIndex = 7;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(6, 343);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(82, 18);
            this.labelControl6.TabIndex = 23;
            this.labelControl6.Text = "Hesap Türü:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.LkpFirma);
            this.groupControl1.Controls.Add(this.labelControl13);
            this.groupControl1.Controls.Add(this.TxtHesapTuru);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.TxtHesapNo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.TxtIban);
            this.groupControl1.Controls.Add(this.CmbIlce);
            this.groupControl1.Controls.Add(this.CmbIl);
            this.groupControl1.Controls.Add(this.MskTarih);
            this.groupControl1.Controls.Add(this.MskTelefon);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.BtnTemizle);
            this.groupControl1.Controls.Add(this.BtnGüncelle);
            this.groupControl1.Controls.Add(this.BtnSil);
            this.groupControl1.Controls.Add(this.BtnKaydet);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.TxtYetkili);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.TxtSube);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.TxtBankaAdı);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.TxtID);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl1.Location = new System.Drawing.Point(1658, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(245, 782);
            this.groupControl1.TabIndex = 18;
            // 
            // LkpFirma
            // 
            this.LkpFirma.Location = new System.Drawing.Point(94, 370);
            this.LkpFirma.Name = "LkpFirma";
            this.LkpFirma.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.LkpFirma.Properties.Appearance.Options.UseFont = true;
            this.LkpFirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LkpFirma.Properties.PopupView = this.gridLookUpEdit1View;
            this.LkpFirma.Size = new System.Drawing.Size(143, 24);
            this.LkpFirma.TabIndex = 108;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(47, 372);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(41, 18);
            this.labelControl13.TabIndex = 107;
            this.labelControl13.Text = "Firma:";
            // 
            // TxtHesapTuru
            // 
            this.TxtHesapTuru.EditValue = "";
            this.TxtHesapTuru.Location = new System.Drawing.Point(94, 339);
            this.TxtHesapTuru.Name = "TxtHesapTuru";
            this.TxtHesapTuru.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxtHesapTuru.Properties.Appearance.Options.UseFont = true;
            this.TxtHesapTuru.Size = new System.Drawing.Size(143, 24);
            this.TxtHesapTuru.TabIndex = 9;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(47, 251);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(41, 18);
            this.labelControl12.TabIndex = 105;
            this.labelControl12.Text = "Yetkili:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(19, 220);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 18);
            this.labelControl5.TabIndex = 104;
            this.labelControl5.Text = "Hesap No:";
            // 
            // TxtHesapNo
            // 
            this.TxtHesapNo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxtHesapNo.Location = new System.Drawing.Point(94, 216);
            this.TxtHesapNo.Name = "TxtHesapNo";
            this.TxtHesapNo.Size = new System.Drawing.Size(143, 25);
            this.TxtHesapNo.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(49, 190);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 18);
            this.labelControl3.TabIndex = 102;
            this.labelControl3.Text = "IBAN:";
            // 
            // TxtIban
            // 
            this.TxtIban.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxtIban.Location = new System.Drawing.Point(94, 185);
            this.TxtIban.Name = "TxtIban";
            this.TxtIban.Size = new System.Drawing.Size(143, 25);
            this.TxtIban.TabIndex = 4;
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnTemizle.ImageOptions.Image")));
            this.BtnTemizle.Location = new System.Drawing.Point(16, 622);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(221, 67);
            this.BtnTemizle.TabIndex = 13;
            this.BtnTemizle.Text = "Temizle";
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // BtnGüncelle
            // 
            this.BtnGüncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnGüncelle.ImageOptions.Image")));
            this.BtnGüncelle.Location = new System.Drawing.Point(16, 549);
            this.BtnGüncelle.Name = "BtnGüncelle";
            this.BtnGüncelle.Size = new System.Drawing.Size(221, 67);
            this.BtnGüncelle.TabIndex = 12;
            this.BtnGüncelle.Text = "Güncelle";
            this.BtnGüncelle.Click += new System.EventHandler(this.BtnGüncelle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSil.ImageOptions.Image")));
            this.BtnSil.Location = new System.Drawing.Point(16, 695);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(221, 67);
            this.BtnSil.TabIndex = 14;
            this.BtnSil.Text = "Sil";
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.ImageOptions.Image")));
            this.BtnKaydet.Location = new System.Drawing.Point(16, 476);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(221, 67);
            this.BtnKaydet.TabIndex = 11;
            this.BtnKaydet.Text = "Kaydet";
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(60, 129);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(28, 18);
            this.labelControl10.TabIndex = 18;
            this.labelControl10.Text = "İlçe:";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(75, 99);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(13, 18);
            this.labelControl9.TabIndex = 16;
            this.labelControl9.Text = "İl:";
            // 
            // TxtYetkili
            // 
            this.TxtYetkili.EditValue = "";
            this.TxtYetkili.Location = new System.Drawing.Point(94, 247);
            this.TxtYetkili.Name = "TxtYetkili";
            this.TxtYetkili.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxtYetkili.Properties.Appearance.Options.UseFont = true;
            this.TxtYetkili.Size = new System.Drawing.Size(143, 24);
            this.TxtYetkili.TabIndex = 6;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(51, 160);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(37, 18);
            this.labelControl8.TabIndex = 14;
            this.labelControl8.Text = "Şube:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(50, 312);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(38, 18);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Tarih:";
            // 
            // TxtSube
            // 
            this.TxtSube.Location = new System.Drawing.Point(94, 156);
            this.TxtSube.Name = "TxtSube";
            this.TxtSube.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxtSube.Properties.Appearance.Options.UseFont = true;
            this.TxtSube.Size = new System.Drawing.Size(143, 24);
            this.TxtSube.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(34, 281);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(54, 18);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Telefon:";
            // 
            // TxtBankaAdı
            // 
            this.TxtBankaAdı.Location = new System.Drawing.Point(94, 64);
            this.TxtBankaAdı.Name = "TxtBankaAdı";
            this.TxtBankaAdı.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxtBankaAdı.Properties.Appearance.Options.UseFont = true;
            this.TxtBankaAdı.Size = new System.Drawing.Size(143, 24);
            this.TxtBankaAdı.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(19, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Banka Adı:";
            // 
            // TxtID
            // 
            this.TxtID.Enabled = false;
            this.TxtID.Location = new System.Drawing.Point(94, 34);
            this.TxtID.Name = "TxtID";
            this.TxtID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxtID.Properties.Appearance.Options.UseFont = true;
            this.TxtID.Size = new System.Drawing.Size(143, 24);
            this.TxtID.TabIndex = 100;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(67, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ID:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(1564, 745);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(88, 39);
            this.simpleButton1.TabIndex = 19;
            this.simpleButton1.Text = "Yenile";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmBankalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1915, 861);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmBankalar";
            this.Text = "BANKALAR";
            this.Load += new System.EventHandler(this.FrmBankalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbIlce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbIl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LkpFirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtHesapTuru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtYetkili.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSube.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankaAdı.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.ComboBoxEdit CmbIlce;
        private DevExpress.XtraEditors.ComboBoxEdit CmbIl;
        private System.Windows.Forms.MaskedTextBox MskTarih;
        private System.Windows.Forms.MaskedTextBox MskTelefon;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton BtnTemizle;
        private DevExpress.XtraEditors.SimpleButton BtnGüncelle;
        private DevExpress.XtraEditors.SimpleButton BtnSil;
        private DevExpress.XtraEditors.SimpleButton BtnKaydet;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit TxtYetkili;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit TxtSube;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit TxtBankaAdı;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TxtID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.MaskedTextBox TxtIban;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit TxtHesapTuru;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.MaskedTextBox TxtHesapNo;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.GridLookUpEdit LkpFirma;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
    }
}