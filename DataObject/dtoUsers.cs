using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class dtoUsers
    {
        public dtoUsers()
        {
        }

        public string ID { get; set; }
        public string EmployeesID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string StoppedBy { get; set; }
        public DateTime StoppedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string Password_ResetBy { get; set; }
        public DateTime Password_ResetDate { get; set; }
        public string StatusID { get; set; }
    }
}
