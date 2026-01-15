
namespace PresentationLayer
{
    partial class MainForm
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
            DevExpress.XtraSplashScreen.SplashScreenManager spStarting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::PresentationLayer.pageSystem_Starting), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.pageSystem_groupConfiguration_ConnectToDatabase = new DevExpress.XtraBars.BarButtonItem();
            this.pageSystem_groupConfiguration_UserConfiguration = new DevExpress.XtraBars.BarButtonItem();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintView = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportFile = new DevExpress.XtraBars.BarSubItem();
            this.btnExportFile_Pdf = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportFile_Word = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportFile_Excel = new DevExpress.XtraBars.BarButtonItem();
            this.btnWindow = new DevExpress.XtraBars.BarSubItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.bsPosition = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.bsLoginDate = new DevExpress.XtraBars.BarStaticItem();
            this.bsLoginName = new DevExpress.XtraBars.BarStaticItem();
            this.txtCurrentForm = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.pageSystem_groupUser_Login = new DevExpress.XtraBars.BarButtonItem();
            this.pageSystem_groupUser_Logout = new DevExpress.XtraBars.BarButtonItem();
            this.pageSystem_groupUser_Role = new DevExpress.XtraBars.BarButtonItem();
            this.pageSystem_groupUser_UserAdministrator = new DevExpress.XtraBars.BarButtonItem();
            this.pageSystem_groupUser_ChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.pageCategories_groupSystem_Position = new DevExpress.XtraBars.BarButtonItem();
            this.pageCategories_groupMaterialMenu_DinnerTable = new DevExpress.XtraBars.BarButtonItem();
            this.pageCategories_groupMaterialMenu_Menu = new DevExpress.XtraBars.BarButtonItem();
            this.pageCategories_groupMaterialMenu_MenuGroup = new DevExpress.XtraBars.BarButtonItem();
            this.pageCategories_groupMaterialMenu_ListOfMaterials = new DevExpress.XtraBars.BarButtonItem();
            this.pageCategories_groupMaterialMenu_Unit = new DevExpress.XtraBars.BarButtonItem();
            this.pageCategories_groupPriceList_Price = new DevExpress.XtraBars.BarButtonItem();
            this.pageManagement_groupFunctions_TableAndDish = new DevExpress.XtraBars.BarButtonItem();
            this.pageManagement_groupFunctions_CollectAndSpend = new DevExpress.XtraBars.BarButtonItem();
            this.pageReport_groupRevenue_Employee = new DevExpress.XtraBars.BarButtonItem();
            this.pageManagement_groupFunctions_PromotionOnTotalBill = new DevExpress.XtraBars.BarButtonItem();
            this.pageCategories_groupMaterialMenu_MenuAndMaterial = new DevExpress.XtraBars.BarButtonItem();
            this.pageManagement_groupFunctions_ImportMaterials = new DevExpress.XtraBars.BarButtonItem();
            this.pageReport_groupWarehouse_Inventory = new DevExpress.XtraBars.BarButtonItem();
            this.pageManagement_groupSalaryManagement_Timekeeping = new DevExpress.XtraBars.BarButtonItem();
            this.pageManagement_groupSalaryManagement_AttendanceData = new DevExpress.XtraBars.BarButtonItem();
            this.pageManagement_groupSalaryManagement_Payroll = new DevExpress.XtraBars.BarButtonItem();
            this.pageManagement_groupSalaryManagement_Overtime = new DevExpress.XtraBars.BarButtonItem();
            this.pageReport_groupRevenue_BestSeller = new DevExpress.XtraBars.BarButtonItem();
            this.pageManagement_groupSalaryManagement_TimekeepingOther = new DevExpress.XtraBars.BarButtonItem();
            this.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay = new DevExpress.XtraBars.BarButtonItem();
            this.pageSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pageSystem_groupConfiguration = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageSystem_groupUser = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageCategories = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pageCategories_groupSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageCategories_groupMaterialMenu = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageCategories_groupPriceList = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageManagement = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pageManagement_groupFunctions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageManagement_groupSalaryManagement = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageReport = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pageReport_groupRevenue = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageReport_groupWarehouse = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemHypertextLabel1 = new DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerAutoReport = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // spStarting
            // 
            spStarting.ClosingDelay = 500;
            // 
            // ribbonMenu
            // 
            this.ribbonMenu.AllowTrimPageText = false;
            this.ribbonMenu.ExpandCollapseItem.Id = 0;
            this.ribbonMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMenu.ExpandCollapseItem,
            this.pageSystem_groupConfiguration_ConnectToDatabase,
            this.pageSystem_groupConfiguration_UserConfiguration,
            this.btnNew,
            this.btnEdit,
            this.btnSave,
            this.btnDelete,
            this.btnCancel,
            this.btnRefresh,
            this.btnPrintView,
            this.btnPrint,
            this.btnExportFile,
            this.btnWindow,
            this.barStaticItem1,
            this.bsPosition,
            this.barStaticItem3,
            this.bsLoginDate,
            this.bsLoginName,
            this.txtCurrentForm,
            this.pageSystem_groupUser_Login,
            this.pageSystem_groupUser_Logout,
            this.pageSystem_groupUser_Role,
            this.pageSystem_groupUser_UserAdministrator,
            this.pageSystem_groupUser_ChangePassword,
            this.pageCategories_groupSystem_Position,
            this.pageCategories_groupMaterialMenu_DinnerTable,
            this.pageCategories_groupMaterialMenu_Menu,
            this.pageCategories_groupMaterialMenu_MenuGroup,
            this.pageCategories_groupMaterialMenu_ListOfMaterials,
            this.pageCategories_groupMaterialMenu_Unit,
            this.pageCategories_groupPriceList_Price,
            this.pageManagement_groupFunctions_TableAndDish,
            this.pageManagement_groupFunctions_CollectAndSpend,
            this.pageReport_groupRevenue_Employee,
            this.btnExportFile_Pdf,
            this.btnExportFile_Word,
            this.btnExportFile_Excel,
            this.pageManagement_groupFunctions_PromotionOnTotalBill,
            this.pageCategories_groupMaterialMenu_MenuAndMaterial,
            this.pageManagement_groupFunctions_ImportMaterials,
            this.pageReport_groupWarehouse_Inventory,
            this.pageManagement_groupSalaryManagement_Timekeeping,
            this.pageManagement_groupSalaryManagement_AttendanceData,
            this.pageManagement_groupSalaryManagement_Payroll,
            this.pageManagement_groupSalaryManagement_Overtime,
            this.pageReport_groupRevenue_BestSeller,
            this.pageManagement_groupSalaryManagement_TimekeepingOther,
            this.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay});
            this.ribbonMenu.Location = new System.Drawing.Point(0, 0);
            this.ribbonMenu.MaxItemId = 53;
            this.ribbonMenu.Name = "ribbonMenu";
            this.ribbonMenu.PageHeaderItemLinks.Add(this.bsLoginName);
            this.ribbonMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pageSystem,
            this.pageCategories,
            this.pageManagement,
            this.pageReport});
            this.ribbonMenu.QuickToolbarItemLinks.Add(this.txtCurrentForm);
            this.ribbonMenu.QuickToolbarItemLinks.Add(this.btnNew);
            this.ribbonMenu.QuickToolbarItemLinks.Add(this.btnSave);
            this.ribbonMenu.QuickToolbarItemLinks.Add(this.btnEdit);
            this.ribbonMenu.QuickToolbarItemLinks.Add(this.btnDelete);
            this.ribbonMenu.QuickToolbarItemLinks.Add(this.btnCancel);
            this.ribbonMenu.QuickToolbarItemLinks.Add(this.btnRefresh);
            this.ribbonMenu.QuickToolbarItemLinks.Add(this.btnPrintView);
            this.ribbonMenu.QuickToolbarItemLinks.Add(this.btnPrint);
            this.ribbonMenu.QuickToolbarItemLinks.Add(this.btnExportFile);
            this.ribbonMenu.QuickToolbarItemLinks.Add(this.btnWindow);
            this.ribbonMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHypertextLabel1,
            this.repositoryItemTextEdit1});
            this.ribbonMenu.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonMenu.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonMenu.ShowItemCaptionsInQAT = true;
            this.ribbonMenu.ShowToolbarCustomizeItem = false;
            this.ribbonMenu.Size = new System.Drawing.Size(1127, 182);
            this.ribbonMenu.StatusBar = this.ribbonStatusBar;
            this.ribbonMenu.Toolbar.ShowCustomizeItem = false;
            this.ribbonMenu.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Below;
            this.ribbonMenu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ribbonMenu_ItemClick);
            // 
            // pageSystem_groupConfiguration_ConnectToDatabase
            // 
            this.pageSystem_groupConfiguration_ConnectToDatabase.Caption = "Kết nối cơ sở dữ liệu";
            this.pageSystem_groupConfiguration_ConnectToDatabase.Id = 4;
            this.pageSystem_groupConfiguration_ConnectToDatabase.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageSystem_groupConfiguration_ConnectToDatabase.ImageOptions.SvgImage")));
            this.pageSystem_groupConfiguration_ConnectToDatabase.Name = "pageSystem_groupConfiguration_ConnectToDatabase";
            this.pageSystem_groupConfiguration_ConnectToDatabase.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageSystem_groupConfiguration_ConnectToDatabase_ItemClick);
            // 
            // pageSystem_groupConfiguration_UserConfiguration
            // 
            this.pageSystem_groupConfiguration_UserConfiguration.Caption = "Cấu hình người dùng";
            this.pageSystem_groupConfiguration_UserConfiguration.Id = 5;
            this.pageSystem_groupConfiguration_UserConfiguration.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageSystem_groupConfiguration_UserConfiguration.ImageOptions.SvgImage")));
            this.pageSystem_groupConfiguration_UserConfiguration.Name = "pageSystem_groupConfiguration_UserConfiguration";
            this.pageSystem_groupConfiguration_UserConfiguration.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageSystem_groupConfiguration_UserConfiguration_ItemClick);
            // 
            // btnNew
            // 
            this.btnNew.Caption = "Thêm";
            this.btnNew.Id = 6;
            this.btnNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNew.ImageOptions.SvgImage")));
            this.btnNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Id = 7;
            this.btnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 8;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 9;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Bỏ qua";
            this.btnCancel.Id = 10;
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Làm mới";
            this.btnRefresh.Id = 11;
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnPrintView
            // 
            this.btnPrintView.Caption = "Xem trước";
            this.btnPrintView.Id = 12;
            this.btnPrintView.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintView.ImageOptions.SvgImage")));
            this.btnPrintView.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M));
            this.btnPrintView.Name = "btnPrintView";
            this.btnPrintView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintView_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Id = 13;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnExportFile
            // 
            this.btnExportFile.Caption = "Xuất file";
            this.btnExportFile.Id = 15;
            this.btnExportFile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExportFile.ImageOptions.SvgImage")));
            this.btnExportFile.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.E));
            this.btnExportFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportFile_Pdf),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportFile_Word),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportFile_Excel)});
            this.btnExportFile.Name = "btnExportFile";
            // 
            // btnExportFile_Pdf
            // 
            this.btnExportFile_Pdf.Caption = "Pdf";
            this.btnExportFile_Pdf.Id = 39;
            this.btnExportFile_Pdf.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExportFile_Pdf.ImageOptions.SvgImage")));
            this.btnExportFile_Pdf.Name = "btnExportFile_Pdf";
            this.btnExportFile_Pdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportFile_Pdf_ItemClick);
            // 
            // btnExportFile_Word
            // 
            this.btnExportFile_Word.Caption = "Word";
            this.btnExportFile_Word.Id = 40;
            this.btnExportFile_Word.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExportFile_Word.ImageOptions.SvgImage")));
            this.btnExportFile_Word.Name = "btnExportFile_Word";
            this.btnExportFile_Word.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportFile_Word_ItemClick);
            // 
            // btnExportFile_Excel
            // 
            this.btnExportFile_Excel.Caption = "Excel";
            this.btnExportFile_Excel.Id = 41;
            this.btnExportFile_Excel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExportFile_Excel.ImageOptions.SvgImage")));
            this.btnExportFile_Excel.Name = "btnExportFile_Excel";
            this.btnExportFile_Excel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportFile_Excel_ItemClick);
            // 
            // btnWindow
            // 
            this.btnWindow.Caption = "Cửa sổ";
            this.btnWindow.Id = 16;
            this.btnWindow.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnWindow.ImageOptions.SvgImage")));
            this.btnWindow.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W));
            this.btnWindow.Name = "btnWindow";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Phím nóng: CtrlN=Thêm - CtrlS=Lưu - CtrlE=Sửa - CtrlD=Xóa - CtrlU=Bỏ qua - CtrlR=" +
    "Làm mới - CtrlM=Xem trước - CtrlP=In";
            this.barStaticItem1.Id = 18;
            this.barStaticItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barStaticItem1.ImageOptions.SvgImage")));
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bsPosition
            // 
            this.bsPosition.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsPosition.Caption = "Chức vụ";
            this.bsPosition.Id = 19;
            this.bsPosition.Name = "bsPosition";
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem3.Caption = "|";
            this.barStaticItem3.Id = 20;
            this.barStaticItem3.Name = "barStaticItem3";
            // 
            // bsLoginDate
            // 
            this.bsLoginDate.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsLoginDate.Caption = "Thời gian đăng nhập";
            this.bsLoginDate.Id = 21;
            this.bsLoginDate.Name = "bsLoginDate";
            // 
            // bsLoginName
            // 
            this.bsLoginName.Caption = "Người đăng nhập";
            this.bsLoginName.Id = 22;
            this.bsLoginName.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bsLoginName.ImageOptions.SvgImage")));
            this.bsLoginName.Name = "bsLoginName";
            this.bsLoginName.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // txtCurrentForm
            // 
            this.txtCurrentForm.Edit = this.repositoryItemTextEdit1;
            this.txtCurrentForm.EditWidth = 200;
            this.txtCurrentForm.Id = 23;
            this.txtCurrentForm.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtCurrentForm.ImageOptions.SvgImage")));
            this.txtCurrentForm.Name = "txtCurrentForm";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            // 
            // pageSystem_groupUser_Login
            // 
            this.pageSystem_groupUser_Login.Caption = "Đăng nhập";
            this.pageSystem_groupUser_Login.Id = 24;
            this.pageSystem_groupUser_Login.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageSystem_groupUser_Login.ImageOptions.SvgImage")));
            this.pageSystem_groupUser_Login.Name = "pageSystem_groupUser_Login";
            this.pageSystem_groupUser_Login.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageSystem_groupUser_Login_ItemClick);
            // 
            // pageSystem_groupUser_Logout
            // 
            this.pageSystem_groupUser_Logout.Caption = "Đăng xuất";
            this.pageSystem_groupUser_Logout.Id = 25;
            this.pageSystem_groupUser_Logout.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageSystem_groupUser_Logout.ImageOptions.SvgImage")));
            this.pageSystem_groupUser_Logout.Name = "pageSystem_groupUser_Logout";
            this.pageSystem_groupUser_Logout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageSystem_groupUser_Logout_ItemClick);
            // 
            // pageSystem_groupUser_Role
            // 
            this.pageSystem_groupUser_Role.Caption = "Nhóm quyền";
            this.pageSystem_groupUser_Role.Id = 26;
            this.pageSystem_groupUser_Role.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageSystem_groupUser_Role.ImageOptions.SvgImage")));
            this.pageSystem_groupUser_Role.Name = "pageSystem_groupUser_Role";
            this.pageSystem_groupUser_Role.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageSystem_groupUser_Role_ItemClick);
            // 
            // pageSystem_groupUser_UserAdministrator
            // 
            this.pageSystem_groupUser_UserAdministrator.Caption = "Quản trị người dùng";
            this.pageSystem_groupUser_UserAdministrator.Id = 27;
            this.pageSystem_groupUser_UserAdministrator.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageSystem_groupUser_UserAdministrator.ImageOptions.SvgImage")));
            this.pageSystem_groupUser_UserAdministrator.Name = "pageSystem_groupUser_UserAdministrator";
            this.pageSystem_groupUser_UserAdministrator.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageSystem_groupUser_UserAdministrator_ItemClick);
            // 
            // pageSystem_groupUser_ChangePassword
            // 
            this.pageSystem_groupUser_ChangePassword.Caption = "Đổi mật khẩu";
            this.pageSystem_groupUser_ChangePassword.Id = 28;
            this.pageSystem_groupUser_ChangePassword.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageSystem_groupUser_ChangePassword.ImageOptions.SvgImage")));
            this.pageSystem_groupUser_ChangePassword.Name = "pageSystem_groupUser_ChangePassword";
            this.pageSystem_groupUser_ChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageSystem_groupUser_ChangePassword_ItemClick);
            // 
            // pageCategories_groupSystem_Position
            // 
            this.pageCategories_groupSystem_Position.Caption = "Chức vụ";
            this.pageCategories_groupSystem_Position.Id = 29;
            this.pageCategories_groupSystem_Position.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageCategories_groupSystem_Position.ImageOptions.SvgImage")));
            this.pageCategories_groupSystem_Position.Name = "pageCategories_groupSystem_Position";
            this.pageCategories_groupSystem_Position.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageCategories_groupSystem_Position_ItemClick);
            // 
            // pageCategories_groupMaterialMenu_DinnerTable
            // 
            this.pageCategories_groupMaterialMenu_DinnerTable.Caption = "Bàn";
            this.pageCategories_groupMaterialMenu_DinnerTable.Id = 30;
            this.pageCategories_groupMaterialMenu_DinnerTable.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pageCategories_groupMaterialMenu_DinnerTable.ImageOptions.Image")));
            this.pageCategories_groupMaterialMenu_DinnerTable.ImageOptions.LargeImage = global::PresentationLayer.Properties.Resources.Table;
            this.pageCategories_groupMaterialMenu_DinnerTable.Name = "pageCategories_groupMaterialMenu_DinnerTable";
            this.pageCategories_groupMaterialMenu_DinnerTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageCategories_groupMaterialMenu_DinnerTable_ItemClick);
            // 
            // pageCategories_groupMaterialMenu_Menu
            // 
            this.pageCategories_groupMaterialMenu_Menu.Caption = "Thực đơn";
            this.pageCategories_groupMaterialMenu_Menu.Id = 31;
            this.pageCategories_groupMaterialMenu_Menu.ImageOptions.LargeImage = global::PresentationLayer.Properties.Resources.Menu;
            this.pageCategories_groupMaterialMenu_Menu.Name = "pageCategories_groupMaterialMenu_Menu";
            this.pageCategories_groupMaterialMenu_Menu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageCategories_groupMaterialMenu_Menu_ItemClick);
            // 
            // pageCategories_groupMaterialMenu_MenuGroup
            // 
            this.pageCategories_groupMaterialMenu_MenuGroup.Caption = "Nhóm thực đơn";
            this.pageCategories_groupMaterialMenu_MenuGroup.Id = 32;
            this.pageCategories_groupMaterialMenu_MenuGroup.ImageOptions.LargeImage = global::PresentationLayer.Properties.Resources.List;
            this.pageCategories_groupMaterialMenu_MenuGroup.Name = "pageCategories_groupMaterialMenu_MenuGroup";
            this.pageCategories_groupMaterialMenu_MenuGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageCategories_groupMaterialMenu_MenuGroup_ItemClick);
            // 
            // pageCategories_groupMaterialMenu_ListOfMaterials
            // 
            this.pageCategories_groupMaterialMenu_ListOfMaterials.Caption = "Danh sách Vật tư && Hàng hóa";
            this.pageCategories_groupMaterialMenu_ListOfMaterials.Id = 33;
            this.pageCategories_groupMaterialMenu_ListOfMaterials.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageCategories_groupMaterialMenu_ListOfMaterials.ImageOptions.SvgImage")));
            this.pageCategories_groupMaterialMenu_ListOfMaterials.Name = "pageCategories_groupMaterialMenu_ListOfMaterials";
            this.pageCategories_groupMaterialMenu_ListOfMaterials.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageCategories_groupMaterialMenu_ListOfMaterials_ItemClick);
            // 
            // pageCategories_groupMaterialMenu_Unit
            // 
            this.pageCategories_groupMaterialMenu_Unit.Caption = "Đơn vị tính";
            this.pageCategories_groupMaterialMenu_Unit.Id = 34;
            this.pageCategories_groupMaterialMenu_Unit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageCategories_groupMaterialMenu_Unit.ImageOptions.SvgImage")));
            this.pageCategories_groupMaterialMenu_Unit.Name = "pageCategories_groupMaterialMenu_Unit";
            this.pageCategories_groupMaterialMenu_Unit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageCategories_groupMaterialMenu_Unit_ItemClick);
            // 
            // pageCategories_groupPriceList_Price
            // 
            this.pageCategories_groupPriceList_Price.Caption = "Bảng giá";
            this.pageCategories_groupPriceList_Price.Id = 35;
            this.pageCategories_groupPriceList_Price.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageCategories_groupPriceList_Price.ImageOptions.SvgImage")));
            this.pageCategories_groupPriceList_Price.Name = "pageCategories_groupPriceList_Price";
            this.pageCategories_groupPriceList_Price.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageCategories_groupPriceList_Price_ItemClick);
            // 
            // pageManagement_groupFunctions_TableAndDish
            // 
            this.pageManagement_groupFunctions_TableAndDish.Caption = "Bàn && Món ăn";
            this.pageManagement_groupFunctions_TableAndDish.Id = 36;
            this.pageManagement_groupFunctions_TableAndDish.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageManagement_groupFunctions_TableAndDish.ImageOptions.SvgImage")));
            this.pageManagement_groupFunctions_TableAndDish.Name = "pageManagement_groupFunctions_TableAndDish";
            this.pageManagement_groupFunctions_TableAndDish.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageManagement_groupFunctions_TableAndDish_ItemClick);
            // 
            // pageManagement_groupFunctions_CollectAndSpend
            // 
            this.pageManagement_groupFunctions_CollectAndSpend.Caption = "Quản lý thu chi";
            this.pageManagement_groupFunctions_CollectAndSpend.Id = 37;
            this.pageManagement_groupFunctions_CollectAndSpend.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageManagement_groupFunctions_CollectAndSpend.ImageOptions.SvgImage")));
            this.pageManagement_groupFunctions_CollectAndSpend.Name = "pageManagement_groupFunctions_CollectAndSpend";
            this.pageManagement_groupFunctions_CollectAndSpend.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageManagement_groupFunctions_CollectAndSpend_ItemClick);
            // 
            // pageReport_groupRevenue_Employee
            // 
            this.pageReport_groupRevenue_Employee.Caption = "Doanh thu chi tiết theo nhân viên";
            this.pageReport_groupRevenue_Employee.Id = 38;
            this.pageReport_groupRevenue_Employee.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageReport_groupRevenue_Employee.ImageOptions.SvgImage")));
            this.pageReport_groupRevenue_Employee.Name = "pageReport_groupRevenue_Employee";
            this.pageReport_groupRevenue_Employee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageReport_groupRevenue_Employee_ItemClick);
            // 
            // pageManagement_groupFunctions_PromotionOnTotalBill
            // 
            this.pageManagement_groupFunctions_PromotionOnTotalBill.Caption = "Chương trình khuyến mãi";
            this.pageManagement_groupFunctions_PromotionOnTotalBill.Id = 42;
            this.pageManagement_groupFunctions_PromotionOnTotalBill.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageManagement_groupFunctions_PromotionOnTotalBill.ImageOptions.SvgImage")));
            this.pageManagement_groupFunctions_PromotionOnTotalBill.Name = "pageManagement_groupFunctions_PromotionOnTotalBill";
            this.pageManagement_groupFunctions_PromotionOnTotalBill.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageManagement_groupFunctions_PromotionOnTotalBill_ItemClick);
            // 
            // pageCategories_groupMaterialMenu_MenuAndMaterial
            // 
            this.pageCategories_groupMaterialMenu_MenuAndMaterial.Caption = "Thực đơn && Nguyên liệu";
            this.pageCategories_groupMaterialMenu_MenuAndMaterial.Id = 43;
            this.pageCategories_groupMaterialMenu_MenuAndMaterial.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageCategories_groupMaterialMenu_MenuAndMaterial.ImageOptions.SvgImage")));
            this.pageCategories_groupMaterialMenu_MenuAndMaterial.Name = "pageCategories_groupMaterialMenu_MenuAndMaterial";
            this.pageCategories_groupMaterialMenu_MenuAndMaterial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageCategories_groupMaterialMenu_MenuAndMaterial_ItemClick);
            // 
            // pageManagement_groupFunctions_ImportMaterials
            // 
            this.pageManagement_groupFunctions_ImportMaterials.Caption = "Nhập hàng";
            this.pageManagement_groupFunctions_ImportMaterials.Id = 44;
            this.pageManagement_groupFunctions_ImportMaterials.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageManagement_groupFunctions_ImportMaterials.ImageOptions.SvgImage")));
            this.pageManagement_groupFunctions_ImportMaterials.Name = "pageManagement_groupFunctions_ImportMaterials";
            this.pageManagement_groupFunctions_ImportMaterials.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageManagement_groupFunctions_ImportMaterials_ItemClick);
            // 
            // pageReport_groupWarehouse_Inventory
            // 
            this.pageReport_groupWarehouse_Inventory.Caption = "Tồn kho";
            this.pageReport_groupWarehouse_Inventory.Id = 45;
            this.pageReport_groupWarehouse_Inventory.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageReport_groupWarehouse_Inventory.ImageOptions.SvgImage")));
            this.pageReport_groupWarehouse_Inventory.Name = "pageReport_groupWarehouse_Inventory";
            this.pageReport_groupWarehouse_Inventory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageReport_groupWarehouse_Inventory_ItemClick);
            // 
            // pageManagement_groupSalaryManagement_Timekeeping
            // 
            this.pageManagement_groupSalaryManagement_Timekeeping.Caption = "Chấm công";
            this.pageManagement_groupSalaryManagement_Timekeeping.Id = 46;
            this.pageManagement_groupSalaryManagement_Timekeeping.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageManagement_groupSalaryManagement_Timekeeping.ImageOptions.SvgImage")));
            this.pageManagement_groupSalaryManagement_Timekeeping.Name = "pageManagement_groupSalaryManagement_Timekeeping";
            this.pageManagement_groupSalaryManagement_Timekeeping.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageManagement_groupSalaryManagement_Timekeeping_ItemClick);
            // 
            // pageManagement_groupSalaryManagement_AttendanceData
            // 
            this.pageManagement_groupSalaryManagement_AttendanceData.Caption = "Dữ liệu chấm công";
            this.pageManagement_groupSalaryManagement_AttendanceData.Id = 47;
            this.pageManagement_groupSalaryManagement_AttendanceData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageManagement_groupSalaryManagement_AttendanceData.ImageOptions.SvgImage")));
            this.pageManagement_groupSalaryManagement_AttendanceData.Name = "pageManagement_groupSalaryManagement_AttendanceData";
            this.pageManagement_groupSalaryManagement_AttendanceData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageManagement_groupSalaryManagement_AttendanceData_ItemClick);
            // 
            // pageManagement_groupSalaryManagement_Payroll
            // 
            this.pageManagement_groupSalaryManagement_Payroll.Caption = "Bảng lương";
            this.pageManagement_groupSalaryManagement_Payroll.Id = 48;
            this.pageManagement_groupSalaryManagement_Payroll.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageManagement_groupSalaryManagement_Payroll.ImageOptions.SvgImage")));
            this.pageManagement_groupSalaryManagement_Payroll.Name = "pageManagement_groupSalaryManagement_Payroll";
            this.pageManagement_groupSalaryManagement_Payroll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageManagement_groupSalaryManagement_Payroll_ItemClick);
            // 
            // pageManagement_groupSalaryManagement_Overtime
            // 
            this.pageManagement_groupSalaryManagement_Overtime.Caption = "Tăng ca";
            this.pageManagement_groupSalaryManagement_Overtime.Id = 49;
            this.pageManagement_groupSalaryManagement_Overtime.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageManagement_groupSalaryManagement_Overtime.ImageOptions.SvgImage")));
            this.pageManagement_groupSalaryManagement_Overtime.Name = "pageManagement_groupSalaryManagement_Overtime";
            this.pageManagement_groupSalaryManagement_Overtime.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageManagement_groupSalaryManagement_Overtime_ItemClick);
            // 
            // pageReport_groupRevenue_BestSeller
            // 
            this.pageReport_groupRevenue_BestSeller.Caption = "Danh sách các món đã bán";
            this.pageReport_groupRevenue_BestSeller.Id = 50;
            this.pageReport_groupRevenue_BestSeller.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageReport_groupRevenue_BestSeller.ImageOptions.SvgImage")));
            this.pageReport_groupRevenue_BestSeller.Name = "pageReport_groupRevenue_BestSeller";
            this.pageReport_groupRevenue_BestSeller.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageReport_groupRevenue_BestSeller_ItemClick);
            // 
            // pageManagement_groupSalaryManagement_TimekeepingOther
            // 
            this.pageManagement_groupSalaryManagement_TimekeepingOther.Caption = "Chấm công hộ";
            this.pageManagement_groupSalaryManagement_TimekeepingOther.Id = 51;
            this.pageManagement_groupSalaryManagement_TimekeepingOther.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageManagement_groupSalaryManagement_TimekeepingOther.ImageOptions.SvgImage")));
            this.pageManagement_groupSalaryManagement_TimekeepingOther.Name = "pageManagement_groupSalaryManagement_TimekeepingOther";
            this.pageManagement_groupSalaryManagement_TimekeepingOther.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageManagement_groupSalaryManagement_TimekeepingOther_ItemClick);
            // 
            // pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay
            // 
            this.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.Caption = "Doanh thu tổng hợp theo nhân viên";
            this.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.Id = 52;
            this.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.ImageOptions.SvgImage")));
            this.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.Name = "pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay";
            this.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_ItemClick);
            // 
            // pageSystem
            // 
            this.pageSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pageSystem_groupConfiguration,
            this.pageSystem_groupUser});
            this.pageSystem.Name = "pageSystem";
            this.pageSystem.Text = "Hệ thống";
            // 
            // pageSystem_groupConfiguration
            // 
            this.pageSystem_groupConfiguration.ItemLinks.Add(this.pageSystem_groupConfiguration_ConnectToDatabase);
            this.pageSystem_groupConfiguration.ItemLinks.Add(this.pageSystem_groupConfiguration_UserConfiguration);
            this.pageSystem_groupConfiguration.Name = "pageSystem_groupConfiguration";
            this.pageSystem_groupConfiguration.Text = "Cấu hình";
            // 
            // pageSystem_groupUser
            // 
            this.pageSystem_groupUser.ItemLinks.Add(this.pageSystem_groupUser_UserAdministrator);
            this.pageSystem_groupUser.ItemLinks.Add(this.pageSystem_groupUser_Role);
            this.pageSystem_groupUser.ItemLinks.Add(this.pageSystem_groupUser_Login);
            this.pageSystem_groupUser.ItemLinks.Add(this.pageSystem_groupUser_Logout);
            this.pageSystem_groupUser.ItemLinks.Add(this.pageSystem_groupUser_ChangePassword);
            this.pageSystem_groupUser.Name = "pageSystem_groupUser";
            this.pageSystem_groupUser.Text = "Người dùng";
            // 
            // pageCategories
            // 
            this.pageCategories.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pageCategories_groupSystem,
            this.pageCategories_groupMaterialMenu,
            this.pageCategories_groupPriceList});
            this.pageCategories.Name = "pageCategories";
            this.pageCategories.Text = "Danh mục";
            // 
            // pageCategories_groupSystem
            // 
            this.pageCategories_groupSystem.ItemLinks.Add(this.pageCategories_groupSystem_Position);
            this.pageCategories_groupSystem.Name = "pageCategories_groupSystem";
            this.pageCategories_groupSystem.Text = "Hệ thống";
            // 
            // pageCategories_groupMaterialMenu
            // 
            this.pageCategories_groupMaterialMenu.ItemLinks.Add(this.pageCategories_groupMaterialMenu_ListOfMaterials);
            this.pageCategories_groupMaterialMenu.ItemLinks.Add(this.pageCategories_groupMaterialMenu_DinnerTable);
            this.pageCategories_groupMaterialMenu.ItemLinks.Add(this.pageCategories_groupMaterialMenu_Unit);
            this.pageCategories_groupMaterialMenu.ItemLinks.Add(this.pageCategories_groupMaterialMenu_MenuGroup);
            this.pageCategories_groupMaterialMenu.ItemLinks.Add(this.pageCategories_groupMaterialMenu_Menu);
            this.pageCategories_groupMaterialMenu.ItemLinks.Add(this.pageCategories_groupMaterialMenu_MenuAndMaterial);
            this.pageCategories_groupMaterialMenu.Name = "pageCategories_groupMaterialMenu";
            this.pageCategories_groupMaterialMenu.Text = "Vật tư && Thực đơn";
            // 
            // pageCategories_groupPriceList
            // 
            this.pageCategories_groupPriceList.ItemLinks.Add(this.pageCategories_groupPriceList_Price);
            this.pageCategories_groupPriceList.Name = "pageCategories_groupPriceList";
            this.pageCategories_groupPriceList.Text = "Bảng giá";
            // 
            // pageManagement
            // 
            this.pageManagement.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pageManagement_groupFunctions,
            this.pageManagement_groupSalaryManagement});
            this.pageManagement.Name = "pageManagement";
            this.pageManagement.Text = "Quản lý";
            // 
            // pageManagement_groupFunctions
            // 
            this.pageManagement_groupFunctions.ItemLinks.Add(this.pageManagement_groupFunctions_TableAndDish);
            this.pageManagement_groupFunctions.ItemLinks.Add(this.pageManagement_groupFunctions_CollectAndSpend);
            this.pageManagement_groupFunctions.ItemLinks.Add(this.pageManagement_groupFunctions_PromotionOnTotalBill);
            this.pageManagement_groupFunctions.ItemLinks.Add(this.pageManagement_groupFunctions_ImportMaterials);
            this.pageManagement_groupFunctions.Name = "pageManagement_groupFunctions";
            this.pageManagement_groupFunctions.Text = "Chức năng";
            // 
            // pageManagement_groupSalaryManagement
            // 
            this.pageManagement_groupSalaryManagement.ItemLinks.Add(this.pageManagement_groupSalaryManagement_Timekeeping);
            this.pageManagement_groupSalaryManagement.ItemLinks.Add(this.pageManagement_groupSalaryManagement_TimekeepingOther);
            this.pageManagement_groupSalaryManagement.ItemLinks.Add(this.pageManagement_groupSalaryManagement_AttendanceData);
            this.pageManagement_groupSalaryManagement.ItemLinks.Add(this.pageManagement_groupSalaryManagement_Overtime);
            this.pageManagement_groupSalaryManagement.ItemLinks.Add(this.pageManagement_groupSalaryManagement_Payroll);
            this.pageManagement_groupSalaryManagement.Name = "pageManagement_groupSalaryManagement";
            this.pageManagement_groupSalaryManagement.Text = "Quản lý lương";
            // 
            // pageReport
            // 
            this.pageReport.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pageReport_groupRevenue,
            this.pageReport_groupWarehouse});
            this.pageReport.Name = "pageReport";
            this.pageReport.Text = "Báo cáo";
            // 
            // pageReport_groupRevenue
            // 
            this.pageReport_groupRevenue.ItemLinks.Add(this.pageReport_groupRevenue_Employee);
            this.pageReport_groupRevenue.ItemLinks.Add(this.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay);
            this.pageReport_groupRevenue.ItemLinks.Add(this.pageReport_groupRevenue_BestSeller);
            this.pageReport_groupRevenue.Name = "pageReport_groupRevenue";
            this.pageReport_groupRevenue.Text = "Doanh thu";
            // 
            // pageReport_groupWarehouse
            // 
            this.pageReport_groupWarehouse.ItemLinks.Add(this.pageReport_groupWarehouse_Inventory);
            this.pageReport_groupWarehouse.Name = "pageReport_groupWarehouse";
            this.pageReport_groupWarehouse.Text = "Kho hàng";
            // 
            // repositoryItemHypertextLabel1
            // 
            this.repositoryItemHypertextLabel1.Name = "repositoryItemHypertextLabel1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.bsPosition);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem3);
            this.ribbonStatusBar.ItemLinks.Add(this.bsLoginDate);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 577);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonMenu;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1127, 22);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2019 Colorful";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "button_ok_16 - Copy.png");
            // 
            // timerAutoReport
            // 
            this.timerAutoReport.Tick += new System.EventHandler(this.timerAutoReport_Tick);
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AllowMdiBar = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 599);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonMenu);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("MainForm.IconOptions.Image")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbonMenu;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Phần mềm quản lý cửa hàng trà sữa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageSystem_groupConfiguration;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem pageSystem_groupConfiguration_ConnectToDatabase;
        private DevExpress.XtraBars.BarButtonItem pageSystem_groupConfiguration_UserConfiguration;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnPrintView;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarSubItem btnExportFile;
        private DevExpress.XtraBars.BarSubItem btnWindow;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel repositoryItemHypertextLabel1;
        private DevExpress.XtraBars.BarStaticItem bsPosition;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem bsLoginDate;
        private DevExpress.XtraBars.BarStaticItem bsLoginName;
        private DevExpress.XtraBars.BarEditItem txtCurrentForm;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageSystem_groupUser;
        private DevExpress.XtraBars.BarButtonItem pageSystem_groupUser_Login;
        private DevExpress.XtraBars.BarButtonItem pageSystem_groupUser_Logout;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem pageSystem_groupUser_Role;
        private DevExpress.XtraBars.BarButtonItem pageSystem_groupUser_UserAdministrator;
        private DevExpress.XtraBars.BarButtonItem pageSystem_groupUser_ChangePassword;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageCategories;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageCategories_groupSystem;
        private DevExpress.XtraBars.BarButtonItem pageCategories_groupSystem_Position;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageCategories_groupMaterialMenu;
        private DevExpress.XtraBars.BarButtonItem pageCategories_groupMaterialMenu_DinnerTable;
        private DevExpress.XtraBars.BarButtonItem pageCategories_groupMaterialMenu_Menu;
        private DevExpress.XtraBars.BarButtonItem pageCategories_groupMaterialMenu_MenuGroup;
        private DevExpress.XtraBars.BarButtonItem pageCategories_groupMaterialMenu_ListOfMaterials;
        private DevExpress.XtraBars.BarButtonItem pageCategories_groupMaterialMenu_Unit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageCategories_groupPriceList;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageManagement;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageManagement_groupFunctions;
        private DevExpress.XtraBars.BarButtonItem pageCategories_groupPriceList_Price;
        private DevExpress.XtraBars.BarButtonItem pageManagement_groupFunctions_TableAndDish;
        private DevExpress.XtraBars.BarButtonItem pageManagement_groupFunctions_CollectAndSpend;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageReport_groupRevenue;
        private DevExpress.XtraBars.BarButtonItem pageReport_groupRevenue_Employee;
        private DevExpress.XtraBars.BarButtonItem btnExportFile_Pdf;
        private DevExpress.XtraBars.BarButtonItem btnExportFile_Word;
        private DevExpress.XtraBars.BarButtonItem btnExportFile_Excel;
        private DevExpress.XtraBars.BarButtonItem pageManagement_groupFunctions_PromotionOnTotalBill;
        private DevExpress.XtraBars.BarButtonItem pageCategories_groupMaterialMenu_MenuAndMaterial;
        private DevExpress.XtraBars.BarButtonItem pageManagement_groupFunctions_ImportMaterials;
        private DevExpress.XtraBars.BarButtonItem pageReport_groupWarehouse_Inventory;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageReport_groupWarehouse;
        private DevExpress.XtraBars.BarButtonItem pageManagement_groupSalaryManagement_Timekeeping;
        private DevExpress.XtraBars.BarButtonItem pageManagement_groupSalaryManagement_AttendanceData;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageManagement_groupSalaryManagement;
        private DevExpress.XtraBars.BarButtonItem pageManagement_groupSalaryManagement_Payroll;
        private DevExpress.XtraBars.BarButtonItem pageManagement_groupSalaryManagement_Overtime;
        private DevExpress.XtraBars.BarButtonItem pageReport_groupRevenue_BestSeller;
        private DevExpress.XtraBars.BarButtonItem pageManagement_groupSalaryManagement_TimekeepingOther;
        private System.Windows.Forms.Timer timerAutoReport;
        private DevExpress.XtraBars.BarButtonItem pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay;
    }
}