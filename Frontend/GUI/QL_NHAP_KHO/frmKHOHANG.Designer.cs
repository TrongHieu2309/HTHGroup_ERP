namespace GUI.QL_NHAP_KHO_GUI
{
    partial class frmKHOHANG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKHOHANG));
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
            this.barbtnSua = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnHuybo = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupNhap = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGHICHU = new System.Windows.Forms.TextBox();
            this.txtNGUOIQL = new System.Windows.Forms.TextBox();
            this.txtTENKHO = new System.Windows.Forms.TextBox();
            this.txtMAKHO = new System.Windows.Forms.TextBox();
            this.txtDIACHI = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTENKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColNGUOIQUANLY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGHICHU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barbtnThem = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // barbtnSua
            // 
            this.barbtnSua.Caption = "barButtonItem1";
            this.barbtnSua.Id = 1;
            this.barbtnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnSua.ImageOptions.Image")));
            this.barbtnSua.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnSua.ImageOptions.LargeImage")));
            this.barbtnSua.Name = "barbtnSua";
            toolTipItem1.Text = "Sửa dữ liệu";
            superToolTip1.Items.Add(toolTipItem1);
            this.barbtnSua.SuperTip = superToolTip1;
            this.barbtnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnSua_ItemClick);
            // 
            // barbtnLuu
            // 
            this.barbtnLuu.Caption = "barButtonItem3";
            this.barbtnLuu.Id = 3;
            this.barbtnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnLuu.ImageOptions.Image")));
            this.barbtnLuu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnLuu.ImageOptions.LargeImage")));
            this.barbtnLuu.Name = "barbtnLuu";
            toolTipItem2.Text = "Lưu dữ liệu";
            superToolTip2.Items.Add(toolTipItem2);
            this.barbtnLuu.SuperTip = superToolTip2;
            this.barbtnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnLuu_ItemClick);
            // 
            // barbtnHuybo
            // 
            this.barbtnHuybo.Caption = "barButtonItem4";
            this.barbtnHuybo.Id = 4;
            this.barbtnHuybo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnHuybo.ImageOptions.Image")));
            this.barbtnHuybo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnHuybo.ImageOptions.LargeImage")));
            this.barbtnHuybo.Name = "barbtnHuybo";
            toolTipItem3.Text = "Hủy bỏ";
            superToolTip3.Items.Add(toolTipItem3);
            this.barbtnHuybo.SuperTip = superToolTip3;
            this.barbtnHuybo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnHuybo_ItemClick);
            // 
            // barbtnThoat
            // 
            this.barbtnThoat.Caption = "barButtonItem5";
            this.barbtnThoat.Id = 5;
            this.barbtnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnThoat.ImageOptions.Image")));
            this.barbtnThoat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnThoat.ImageOptions.LargeImage")));
            this.barbtnThoat.Name = "barbtnThoat";
            toolTipItem4.Text = "Thoát";
            superToolTip4.Items.Add(toolTipItem4);
            this.barbtnThoat.SuperTip = superToolTip4;
            this.barbtnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnThoat_ItemClick);
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
            this.splitContainer1.Size = new System.Drawing.Size(1080, 522);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 30;
            // 
            // groupNhap
            // 
            this.groupNhap.Controls.Add(this.splitContainer2);
            this.groupNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupNhap.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNhap.Location = new System.Drawing.Point(0, 0);
            this.groupNhap.Name = "groupNhap";
            this.groupNhap.Size = new System.Drawing.Size(1080, 175);
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
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtGHICHU);
            this.splitContainer2.Panel2.Controls.Add(this.txtNGUOIQL);
            this.splitContainer2.Panel2.Controls.Add(this.txtTENKHO);
            this.splitContainer2.Panel2.Controls.Add(this.txtMAKHO);
            this.splitContainer2.Panel2.Controls.Add(this.txtDIACHI);
            this.splitContainer2.Panel2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer2.Size = new System.Drawing.Size(1074, 151);
            this.splitContainer2.SplitterDistance = 152;
            this.splitContainer2.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "&1. Mã kho:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "&5. Ghi chú:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "&3. Địa chỉ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "&2. Tên kho:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "&4. Người quản lý:";
            // 
            // txtGHICHU
            // 
            this.txtGHICHU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGHICHU.Location = new System.Drawing.Point(13, 117);
            this.txtGHICHU.Name = "txtGHICHU";
            this.txtGHICHU.Size = new System.Drawing.Size(887, 25);
            this.txtGHICHU.TabIndex = 8;
            // 
            // txtNGUOIQL
            // 
            this.txtNGUOIQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNGUOIQL.Location = new System.Drawing.Point(13, 89);
            this.txtNGUOIQL.Name = "txtNGUOIQL";
            this.txtNGUOIQL.Size = new System.Drawing.Size(887, 25);
            this.txtNGUOIQL.TabIndex = 6;
            // 
            // txtTENKHO
            // 
            this.txtTENKHO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTENKHO.Location = new System.Drawing.Point(13, 34);
            this.txtTENKHO.Name = "txtTENKHO";
            this.txtTENKHO.Size = new System.Drawing.Size(887, 25);
            this.txtTENKHO.TabIndex = 5;
            // 
            // txtMAKHO
            // 
            this.txtMAKHO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMAKHO.Enabled = false;
            this.txtMAKHO.Location = new System.Drawing.Point(13, 7);
            this.txtMAKHO.Name = "txtMAKHO";
            this.txtMAKHO.Size = new System.Drawing.Size(887, 25);
            this.txtMAKHO.TabIndex = 4;
            // 
            // txtDIACHI
            // 
            this.txtDIACHI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDIACHI.Location = new System.Drawing.Point(13, 61);
            this.txtDIACHI.Name = "txtDIACHI";
            this.txtDIACHI.Size = new System.Drawing.Size(887, 25);
            this.txtDIACHI.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1080, 343);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng dữ liệu";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 21);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1074, 319);
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
            this.gridColMAKHO,
            this.gridColTENKHO,
            this.gridColDIACHI,
            this.gridColNGUOIQUANLY,
            this.gridColGHICHU});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // gridColMAKHO
            // 
            this.gridColMAKHO.Caption = "Mã kho";
            this.gridColMAKHO.FieldName = "MAKHO";
            this.gridColMAKHO.Name = "gridColMAKHO";
            this.gridColMAKHO.Visible = true;
            this.gridColMAKHO.VisibleIndex = 0;
            this.gridColMAKHO.Width = 102;
            // 
            // gridColTENKHO
            // 
            this.gridColTENKHO.Caption = "Tên kho";
            this.gridColTENKHO.FieldName = "TENKHO";
            this.gridColTENKHO.Name = "gridColTENKHO";
            this.gridColTENKHO.Visible = true;
            this.gridColTENKHO.VisibleIndex = 1;
            this.gridColTENKHO.Width = 96;
            // 
            // gridColDIACHI
            // 
            this.gridColDIACHI.Caption = "Địa chỉ";
            this.gridColDIACHI.FieldName = "DIACHI";
            this.gridColDIACHI.Name = "gridColDIACHI";
            this.gridColDIACHI.UnboundDataType = typeof(System.DateOnly);
            this.gridColDIACHI.Visible = true;
            this.gridColDIACHI.VisibleIndex = 2;
            this.gridColDIACHI.Width = 96;
            // 
            // gridColNGUOIQUANLY
            // 
            this.gridColNGUOIQUANLY.Caption = "Người quản lý";
            this.gridColNGUOIQUANLY.FieldName = "NGUOIQUANLY";
            this.gridColNGUOIQUANLY.Name = "gridColNGUOIQUANLY";
            this.gridColNGUOIQUANLY.Visible = true;
            this.gridColNGUOIQUANLY.VisibleIndex = 3;
            this.gridColNGUOIQUANLY.Width = 121;
            // 
            // gridColGHICHU
            // 
            this.gridColGHICHU.Caption = "Ghi chú";
            this.gridColGHICHU.FieldName = "GHICHU";
            this.gridColGHICHU.Name = "gridColGHICHU";
            this.gridColGHICHU.Visible = true;
            this.gridColGHICHU.VisibleIndex = 4;
            this.gridColGHICHU.Width = 160;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 522);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
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
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
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
            toolTipItem5.Text = "Thêm dữ liệu";
            superToolTip5.Items.Add(toolTipItem5);
            this.barbtnThem.SuperTip = superToolTip5;
            this.barbtnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnThem_ItemClick);
            // 
            // barbtnXoa
            // 
            this.barbtnXoa.Caption = "barButtonItem2";
            this.barbtnXoa.Id = 2;
            this.barbtnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barbtnXoa.ImageOptions.Image")));
            this.barbtnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barbtnXoa.ImageOptions.LargeImage")));
            this.barbtnXoa.Name = "barbtnXoa";
            toolTipItem6.Text = "Xóa dữ liệu";
            superToolTip6.Items.Add(toolTipItem6);
            this.barbtnXoa.SuperTip = superToolTip6;
            this.barbtnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnXoa_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1080, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 546);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1080, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1080, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 522);
            // 
            // frmKHOHANG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 546);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmKHOHANG";
            this.Text = "Kho hàng";
            this.Load += new System.EventHandler(this.frmKHOHANG_Load);
            this.Resize += new System.EventHandler(this.frmKHOHANG_Resize);
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
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem barbtnSua;
        private DevExpress.XtraBars.BarButtonItem barbtnLuu;
        private DevExpress.XtraBars.BarButtonItem barbtnHuybo;
        private DevExpress.XtraBars.BarButtonItem barbtnThoat;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupNhap;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMAKHO;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barbtnThem;
        private DevExpress.XtraBars.BarButtonItem barbtnXoa;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.TextBox txtDIACHI;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColMAKHO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTENKHO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn gridColNGUOIQUANLY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGHICHU;
        private System.Windows.Forms.TextBox txtTENKHO;
        private System.Windows.Forms.TextBox txtNGUOIQL;
        private System.Windows.Forms.TextBox txtGHICHU;
    }
}