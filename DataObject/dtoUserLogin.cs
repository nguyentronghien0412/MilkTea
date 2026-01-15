using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class dtoUserLogin
    {
        public dtoUserLogin()
        {
        }

        public string UserID { get; set; }
        public string EmployeesID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmployeesCode { get; set; }
        public string EmployeesName { get; set; }
        public string Position { get; set; }
        public DataTable dtPermission { get; set; }
        public DataTable dtPermissionDetail { get; set; }
        public bool[][] arrButtonStatusDefault { get; set; }
        public bool[][] arrButtonStatus { get; set; }
        public DateTime LoginDate { get; set; }
    }
}
