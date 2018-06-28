using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HW01.Models
{
    public class Shippers
    {
        [DisplayName("貨物編號")]
        public int ShipperID { get; set; }

        [DisplayName("公司名稱")]
        public string CompanyName { get; set; }

        [DisplayName("電話")]
        public string Phone { get; set; }
    }
}