namespace Ticari_Otomasyon
{
    partial class FrmAnaModul
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnaModul));
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.BtnAnasayfa = new DevExpress.XtraBars.BarButtonItem();
            this.BtnUrunler = new DevExpress.XtraBars.BarButtonItem();
            this.BtnStoklar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnMusteriler = new DevExpress.XtraBars.BarButtonItem();
            this.BtnFirmalar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnPersoneller = new DevExpress.XtraBars.BarButtonItem();
            this.BtnGiderler = new DevExpress.XtraBars.BarButtonItem();
            this.BtnKasa = new DevExpress.XtraBars.BarButtonItem();
            this.BtnNotlar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnBankalar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnRehber = new DevExpress.XtraBars.BarButtonItem();
            this.BtnFaturalar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnHareketler = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAyarlar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnRaporlar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "TİCARİ OTOMASYON";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAnasayfa);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnUrunler);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnStoklar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnMusteriler);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnFirmalar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnPersoneller);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnGiderler);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnKasa);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnNotlar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnBankalar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnRehber);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnFaturalar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnHareketler);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAyarlar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // BtnAnasayfa
            // 
            this.BtnAnasayfa.Caption = "ANA SAYFA";
            this.BtnAnasayfa.Id = 5;
            this.BtnAnasayfa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnAnasayfa.ImageOptions.LargeImage")));
            this.BtnAnasayfa.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.BtnAnasayfa.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnAnasayfa.Name = "BtnAnasayfa";
            this.BtnAnasayfa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAnasayfa_ItemClick);
            // 
            // BtnUrunler
            // 
            this.BtnUrunler.Caption = "ÜRÜNLER";
            this.BtnUrunler.Id = 1;
            this.BtnUrunler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnUrunler.ImageOptions.LargeImage")));
            this.BtnUrunler.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnUrunler.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnUrunler.Name = "BtnUrunler";
            this.BtnUrunler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnUrunler_ItemClick);
            // 
            // BtnStoklar
            // 
            this.BtnStoklar.Caption = "STOKLAR";
            this.BtnStoklar.Id = 2;
            this.BtnStoklar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnStoklar.ImageOptions.LargeImage")));
            this.BtnStoklar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnStoklar.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnStoklar.Name = "BtnStoklar";
            this.BtnStoklar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnStoklar_ItemClick);
            // 
            // BtnMusteriler
            // 
            this.BtnMusteriler.Caption = "MÜŞTERİLER";
            this.BtnMusteriler.Id = 3;
            this.BtnMusteriler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnMusteriler.ImageOptions.LargeImage")));
            this.BtnMusteriler.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.BtnMusteriler.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnMusteriler.Name = "BtnMusteriler";
            this.BtnMusteriler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnMusteriler_ItemClick);
            // 
            // BtnFirmalar
            // 
            this.BtnFirmalar.Caption = "FİRMALAR";
            this.BtnFirmalar.Id = 4;
            this.BtnFirmalar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnFirmalar.ImageOptions.LargeImage")));
            this.BtnFirmalar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.BtnFirmalar.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnFirmalar.Name = "BtnFirmalar";
            this.BtnFirmalar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnFirmalar_ItemClick);
            // 
            // BtnPersoneller
            // 
            this.BtnPersoneller.Caption = "PERSONELLER";
            this.BtnPersoneller.Id = 8;
            this.BtnPersoneller.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnPersoneller.ImageOptions.LargeImage")));
            this.BtnPersoneller.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.BtnPersoneller.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnPersoneller.Name = "BtnPersoneller";
            this.BtnPersoneller.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnPersoneller_ItemClick);
            // 
            // BtnGiderler
            // 
            this.BtnGiderler.Caption = "GİDERLER";
            this.BtnGiderler.Id = 9;
            this.BtnGiderler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnGiderler.ImageOptions.LargeImage")));
            this.BtnGiderler.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.BtnGiderler.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnGiderler.Name = "BtnGiderler";
            this.BtnGiderler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnGiderler_ItemClick);
            // 
            // BtnKasa
            // 
            this.BtnKasa.Caption = "KASA";
            this.BtnKasa.Id = 10;
            this.BtnKasa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnKasa.ImageOptions.LargeImage")));
            this.BtnKasa.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.BtnKasa.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnKasa.Name = "BtnKasa";
            this.BtnKasa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnKasa_ItemClick);
            // 
            // BtnNotlar
            // 
            this.BtnNotlar.Caption = "NOTLAR";
            this.BtnNotlar.Id = 11;
            this.BtnNotlar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnNotlar.ImageOptions.LargeImage")));
            this.BtnNotlar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.BtnNotlar.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnNotlar.Name = "BtnNotlar";
            this.BtnNotlar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnNotlar_ItemClick);
            // 
            // BtnBankalar
            // 
            this.BtnBankalar.Caption = "BANKALAR";
            this.BtnBankalar.Id = 12;
            this.BtnBankalar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnBankalar.ImageOptions.LargeImage")));
            this.BtnBankalar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.BtnBankalar.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnBankalar.Name = "BtnBankalar";
            this.BtnBankalar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnBankalar_ItemClick);
            // 
            // BtnRehber
            // 
            this.BtnRehber.Caption = "REHBER";
            this.BtnRehber.Id = 14;
            this.BtnRehber.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnRehber.ImageOptions.LargeImage")));
            this.BtnRehber.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.BtnRehber.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnRehber.Name = "BtnRehber";
            this.BtnRehber.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRehber_ItemClick);
            // 
            // BtnFaturalar
            // 
            this.BtnFaturalar.Caption = "FATURALAR";
            this.BtnFaturalar.Id = 13;
            this.BtnFaturalar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnFaturalar.ImageOptions.LargeImage")));
            this.BtnFaturalar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.BtnFaturalar.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnFaturalar.Name = "BtnFaturalar";
            this.BtnFaturalar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnFaturalar_ItemClick);
            // 
            // BtnHareketler
            // 
            this.BtnHareketler.Caption = "HAREKETLER";
            this.BtnHareketler.Id = 17;
            this.BtnHareketler.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnHareketler.ImageOptions.LargeImage")));
            this.BtnHareketler.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnHareketler.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnHareketler.Name = "BtnHareketler";
            this.BtnHareketler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnHareketler_ItemClick);
            // 
            // BtnAyarlar
            // 
            this.BtnAyarlar.Caption = "AYARLAR";
            this.BtnAyarlar.Id = 15;
            this.BtnAyarlar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnAyarlar.ImageOptions.LargeImage")));
            this.BtnAyarlar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.BtnAyarlar.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnAyarlar.Name = "BtnAyarlar";
            this.BtnAyarlar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAyarlar_ItemClick);
            // 
            // BtnRaporlar
            // 
            this.BtnRaporlar.Caption = "RAPORLAR";
            this.BtnRaporlar.Id = 18;
            this.BtnRaporlar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnRaporlar.ImageOptions.LargeImage")));
            this.BtnRaporlar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11F);
            this.BtnRaporlar.ItemAppearance.Normal.Options.UseFont = true;
            this.BtnRaporlar.Name = "BtnRaporlar";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.BtnUrunler,
            this.BtnStoklar,
            this.BtnMusteriler,
            this.BtnFirmalar,
            this.BtnAnasayfa,
            this.BtnPersoneller,
            this.BtnGiderler,
            this.BtnKasa,
            this.BtnNotlar,
            this.BtnBankalar,
            this.BtnFaturalar,
            this.BtnRehber,
            this.BtnAyarlar,
            this.BtnHareketler,
            this.BtnRaporlar});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 19;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.ribbonControl1.Size = new System.Drawing.Size(1098, 150);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // FrmAnaModul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 579);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "FrmAnaModul";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem BtnUrunler;
        private DevExpress.XtraBars.BarButtonItem BtnStoklar;
        private DevExpress.XtraBars.BarButtonItem BtnMusteriler;
        private DevExpress.XtraBars.BarButtonItem BtnFirmalar;
        private DevExpress.XtraBars.BarButtonItem BtnAnasayfa;
        private DevExpress.XtraBars.BarButtonItem BtnPersoneller;
        private DevExpress.XtraBars.BarButtonItem BtnGiderler;
        private DevExpress.XtraBars.BarButtonItem BtnKasa;
        private DevExpress.XtraBars.BarButtonItem BtnNotlar;
        private DevExpress.XtraBars.BarButtonItem BtnBankalar;
        private DevExpress.XtraBars.BarButtonItem BtnFaturalar;
        private DevExpress.XtraBars.BarButtonItem BtnRehber;
        private DevExpress.XtraBars.BarButtonItem BtnAyarlar;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem BtnHareketler;
        private DevExpress.XtraBars.BarButtonItem BtnRaporlar;
    }
}

