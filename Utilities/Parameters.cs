using DataObject;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Utilities
{
    public class Parameters
    {
        public static string Notification = "Hệ thống - Thông báo";
        public static string Warning = "Hệ thống - Cảnh báo";
        public static string Error = "Hệ thống - Lỗi";
        public static string Confirm = "Hệ thống - Xác nhận";
        public static string Result = "Hệ thống - Kết quả";

        public const string ResultMessage = "SUCCESS@@@";

        public static string LogErrorPath = Application.StartupPath + "\\LogError";
        public static string ComputerName = "Computer name: " + System.Environment.MachineName + "\n";

        public const string KEY_Permission = "nguyentronghien0412@gmail.com";
        public const string IV_Permission = "0937410899@";

        public const string KEY_SystemConfig = "NguyenHoangThienVuong@!";
        public const string IV_SystemConfig = "0937410899@";

        public const string KEY_PasswordUser = "Password@!";
        public const string IV_PasswordUser = "0937410899@";

        public const string KEY_Definition = "Definition@!";
        public const string IV_Definition = "0937410899@";

        public static string SystemConfig_FileName = string.Format(@"{0}\{1}", Application.StartupPath, "SystemConfig.xml");

        public static dtoDefinition Definition = new dtoDefinition();
        public static dtoUserLogin UserLogin = new dtoUserLogin();

        public static string Server = "", Port ="", Username = "", Password = "", Database = "";
        public static string ConnectionString = "";

        public static int TotalAction = 10;

        public const string Permission_NEW = "NEW";
        public const string Permission_SAVE = "SAVE";
        public const string Permission_EDIT = "EDIT";
        public const string Permission_DELETE = "DELETE";
        public const string Permission_CANCEL = "CANCEL";
        public const string Permission_VIEW = "VIEW";
        public const string Permission_PRINT = "PRINT";
        public const string Permission_EXPORT = "EXPORT";
        public const string Permission_LOAD = "LOAD";

        public const string Permission_RESET_PASSWORD = "RESET_PASSWORD";
        public const string Permission_SET_RIGHT = "SET_RIGHT";
        public const string Permission_UPDATE_ACCOUNT = "UPDATE_ACCOUNT";

        public const string Permission_DISH_ADD = "DISH_ADD";
        public const string Permission_DISH_EDIT = "DISH_EDIT";
        public const string Permission_DISH_DELETE = "DISH_DELETE";
        public const string Permission_TABLE_ADD = "TABLE_ADD";
        public const string Permission_TABLE_CHANGE = "TABLE_CHANGE";
        public const string Permission_TABLE_MERGE = "TABLE_MERGE";
        public const string Permission_TABLE_DELETE = "TABLE_DELETE";
        public const string Permission_TABLE_PRINTLIST = "TABLE_PRINTLIST";
        public const string Permission_TABLE_PAYMENT = "TABLE_PAYMENT";
        public const string Permission_TABLE_PRINTBILL = "TABLE_PRINTBILL";
        public const string Permission_TABLE_ADDNOTE = "TABLE_ADDNOTE";
        public const string Permission_TABLE_COLLECTEDMONEY = "TABLE_COLLECTEDMONEY";
        public const string Permission_COST_PRICE = "COST_PRICE";
        public const string Permission_VIEW_ALL = "VIEW_ALL";
        public const string Permission_APPROVED = "APPROVED";
        public const string Permission_PAYMENTED = "PAYMENTED";

        public const string Definition_COLOR_REQUIRED = "COLOR_REQUIRED";
        public const string Definition_USER_DEFAULT_PASSWORD = "USER_DEFAULT_PASSWORD";
        public const string Definition_COMPANY_NAME = "COMPANY_NAME";
        public const string Definition_COMPANY_ADDRESS = "COMPANY_ADDRESS";
        public const string Definition_COMPANY_PHONE = "COMPANY_PHONE";
        public const string Definition_COMPANY_EMAIL = "COMPANY_EMAIL";
        public const string Definition_COMPANY_FACE = "COMPANY_FACE";
        public const string Definition_COMPANY_ZALO = "COMPANY_ZALO";
        public const string Definition_BILL_PREFIX = "BILL_PREFIX";
        public const string Definition_BANK_QRCODE = "BANK_QRCODE";
        public const string Definition_WAREHOUSE = "WAREHOUSE";
        public const string Definition_PRINT_STICKER = "PRINT_STICKER";
        public const string Definition_BRANCH_NAME = "BRANCH_NAME";

        public const string Definition_SMTP_GG_ENABLE = "SMTP_GG_ENABLE";
        public const string Definition_SMTP_GG_HOST = "SMTP_GG_HOST";
        public const string Definition_SMTP_GG_PORT = "SMTP_GG_PORT";
        public const string Definition_SMTP_GG_SSL = "SMTP_GG_SSL";
        public const string Definition_SMTP_GG_CREDENTIALS = "SMTP_GG_CREDENTIALS";
        public const string Definition_SMTP_GG_METHOD = "SMTP_GG_METHOD";
        public const string Definition_SMTP_GG_USERNAME = "SMTP_GG_USERNAME";
        public const string Definition_SMTP_GG_PASSWORD = "SMTP_GG_PASSWORD";
        public const string Definition_AUTO_REPORT_EMAIL = "AUTO_REPORT_EMAIL"; 
        public const string Definition_SUMMARY_OF_REVENUE = "SUMMARY_OF_REVENUE";

        public static List<int> MenuID_NoConfigMaterial = new List<int>{ 285, 299, 298, 288, 79,
                                                                      312,310,309,313,314,308,307,311};

    }
}
