using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_directory
{
    public class Server
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Город")]
        public string Sity { get; set; }
        [DisplayName("IP Адрес")]
        public string Ip { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
