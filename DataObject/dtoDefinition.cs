using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class dtoDefinition
    {
        public Color COLOR_REQUIRED { get; set; }
        public string USER_DEFAULT_PASSWORD { get; set; }
        public string COMPANY_NAME { get; set; }
        public string COMPANY_ADDRESS { get; set; }
        public string COMPANY_PHONE { get; set; }
        public string COMPANY_EMAIL { get; set; }
        public string COMPANY_FACE { get; set; }
        public string COMPANY_ZALO { get; set; }
        public string BILL_PREFIX { get; set; }
        public string WAREHOUSE { get; set; }
        public string BRANCH_NAME { get; set; }

        public string SMTP_GG_ENABLE { get; set; }
        public string SMTP_GG_HOST { get; set; }
        public string SMTP_GG_PORT { get; set; }
        public string SMTP_GG_SSL { get; set; }
        public string SMTP_GG_CREDENTIALS { get; set; }
        public string SMTP_GG_METHOD { get; set; }
        public string SMTP_GG_USERNAME { get; set; }
        public string SMTP_GG_PASSWORD { get; set; }
        public string AUTO_REPORT_EMAIL { get; set; }
        public string SUMMARY_OF_REVENUE { get; set; }

    }
}
