namespace GUI
{
    partial class frmTRINHDO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTRINHDO));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barbtnThem = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnSua = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnHuybo = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupNhap = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMATD = new System.Windows.Forms.TextBox();
            this.txtTENTD = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColMATD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTENTD = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barbtnThem,
            this.barbtnSua,
            this.barbtnXoa,
            this.barbtnLuu,
            this.barbtnHuybo,
            this.barbtnThoat});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(428, 176);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnThem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnSua, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnXoa, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnLuu, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnHuybo, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnThoat, true)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barbtnThem
            // 
            this.barbtnThem.Caption = "barButtonItem1";
            this.barbtnThem.Id = 0;
            this.barbtnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnThem.ImageOptions.Image")));
            this.barbtnThem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnThem.ImageOptions.LargeImage")));
            this.barbtnThem.Name = "barbtnThem";
            toolTipItem1.Text = "Thêm dữ liệu";
            superToolTip1.Items.Add(toolTipItem1);
            this.barbtnThem.SuperTip = superToolTip1;
            this.barbtnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnThem_ItemClick);
            // 
            // barbtnSua
            // 
            this.barbtnSua.Caption = "barButtonItem1";
            this.barbtnSua.Id = 1;
            this.barbtnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnSua.ImageOptions.Image")));
            this.barbtnSua.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnSua.ImageOptions.LargeImage")));
            this.barbtnSua.Name = "barbtnSua";
            toolTipItem2.Text = "Sửa dữ liệu";
            superToolTip2.Items.Add(toolTipItem2);
            this.barbtnSua.SuperTip = superToolTip2;
            this.barbtnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnSua_ItemClick);
            // 
            // barbtnXoa
            // 
            this.barbtnXoa.Caption = "barButtonItem2";
            this.barbtnXoa.Id = 2;
            this.barbtnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnXoa.ImageOptions.Image")));
            this.barbtnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnXoa.ImageOptions.LargeImage")));
            this.barbtnXoa.Name = "barbtnXoa";
            toolTipItem3.Text = "Xóa dữ liệu";
            superToolTip3.Items.Add(toolTipItem3);
            this.barbtnXoa.SuperTip = superToolTip3;
            this.barbtnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnXoa_ItemClick);
            // 
            // barbtnLuu
            // 
            this.barbtnLuu.Caption = "barButtonItem3";
            this.barbtnLuu.Id = 3;
            this.barbtnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnLuu.ImageOptions.Image")));
            this.barbtnLuu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnLuu.ImageOptions.LargeImage")));
            this.barbtnLuu.Name = "barbtnLuu";
            toolTipItem4.Text = "Lưu dữ liệu";
            superToolTip4.Items.Add(toolTipItem4);
            this.barbtnLuu.SuperTip = superToolTip4;
            this.barbtnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnLuu_ItemClick);
            // 
            // barbtnHuybo
            // 
            this.barbtnHuybo.Caption = "barButtonItem4";
            this.barbtnHuybo.Id = 4;
            this.barbtnHuybo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnHuybo.ImageOptions.Image")));
            this.barbtnHuybo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnHuybo.ImageOptions.LargeImage")));
            this.barbtnHuybo.Name = "barbtnHuybo";
            toolTipItem5.Text = "Hủy bỏ";
            superToolTip5.Items.Add(toolTipItem5);
            this.barbtnHuybo.SuperTip = superToolTip5;
            this.barbtnHuybo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnHuybo_ItemClick);
            // 
            // barbtnThoat
            // 
            this.barbtnThoat.Caption = "barButtonItem5";
            this.barbtnThoat.Id = 5;
            this.barbtnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnThoat.ImageOptions.Image")));
            this.barbtnThoat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnThoat.ImageOptions.LargeImage")));
            this.barbtnThoat.Name = "barbtnThoat";
            toolTipItem6.Text = "Thoát";
            superToolTip6.Items.Add(toolTipItem6);
            this.barbtnThoat.SuperTip = superToolTip6;
            this.barbtnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnThoat_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1038, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 483);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1038, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 459);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1038, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 459);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupNhap);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1038, 459);
            this.splitContainer1.SplitterDistance = 96;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupNhap
            // 
            this.groupNhap.Controls.Add(this.splitContainer2);
            this.groupNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupNhap.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNhap.Location = new System.Drawing.Point(0, 0);
            this.groupNhap.Name = "groupNhap";
            this.groupNhap.Size = new System.Drawing.Size(1038, 96);
            this.groupNhap.TabIndex = 0;
            this.groupNhap.TabStop = false;
            this.groupNhap.Text = "Mục nhập liệu";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(3, 21);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtMATD);
            this.splitContainer2.Panel2.Controls.Add(this.txtTENTD);
            this.splitContainer2.Panel2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer2.Size = new System.Drawing.Size(1032, 72);
            this.splitContainer2.SplitterDistance = 182;
            this.splitContainer2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "&1. Mã trình độ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "&2. Nhập tên trình độ:";
            // 
            // txtMATD
            // 
            this.txtMATD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMATD.Enabled = false;
            this.txtMATD.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMATD.Location = new System.Drawing.Point(12, 10);
            this.txtMATD.Name = "txtMATD";
            this.txtMATD.Size = new System.Drawing.Size(825, 22);
            this.txtMATD.TabIndex = 2;
            // 
            // txtTENTD
            // 
            this.txtTENTD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTENTD.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTENTD.Location = new System.Drawing.Point(12, 41);
            this.txtTENTD.Name = "txtTENTD";
            this.txtTENTD.Size = new System.Drawing.Size(825, 22);
            this.txtTENTD.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1038, 359);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng dữ liệu";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 21);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1032, 335);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColMATD,
            this.gridColTENTD});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // gridColMATD
            // 
            this.gridColMATD.Caption = "Mã trình độ";
            this.gridColMATD.FieldName = "MATD";
            this.gridColMATD.Name = "gridColMATD";
            this.gridColMATD.Visible = true;
            this.gridColMATD.VisibleIndex = 0;
            this.gridColMATD.Width = 106;
            // 
            // gridColTENTD
            // 
            this.gridColTENTD.Caption = "Tên trình độ";
            this.gridColTENTD.FieldName = "TENTD";
            this.gridColTENTD.Name = "gridColTENTD";
            this.gridColTENTD.Visible = true;
            this.gridColTENTD.VisibleIndex = 1;
            this.gridColTENTD.Width = 901;
            // 
            // frmTRINHDO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 503);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmTRINHDO";
            this.Text = "Trình độ";
            this.Load += new System.EventHandler(this.frmTRINHDO_Load);
            this.Resize += new System.EventHandler(this.frmTRINHDO_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupNhap.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barbtnThem;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barbtnSua;
        private DevExpress.XtraBars.BarButtonItem barbtnXoa;
        private DevExpress.XtraBars.BarButtonItem barbtnLuu;
        private DevExpress.XtraBars.BarButtonItem barbtnHuybo;
        private DevExpress.XtraBars.BarButtonItem barbtnThoat;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtTENTD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupNhap;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColMATD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTENTD;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMATD;
    }
}