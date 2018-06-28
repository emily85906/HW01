using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HW01.Models
{
    public class Customers
    {
        [DisplayName("客戶編號")]
        public int CustomerID { get; set; }

        [DisplayName("公司名稱")]
        public string CompanyName { get; set; }

        [DisplayName("聯絡人")]
        public string ContactName { get; set; }

        [DisplayName("地址")]
        public string Address { get; set; }
    }
}