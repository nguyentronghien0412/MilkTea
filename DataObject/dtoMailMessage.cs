using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class dtoMailMessage
    {
        public dtoMailMessage()
        {
        }

        public List<string> EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DataTable AttachFiles { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
