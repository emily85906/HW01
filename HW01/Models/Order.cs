using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HW01.Models
{
    public class Order
    {
        [DisplayName("訂單編號")]
        [Required()]
        public int OrderId { get; set; }


        [DisplayName("客戶名稱")]
        [Required()]
        public string CustomerName { get; set; }

        [DisplayName("負責員工")]
        [Required()]
        public string EmployeeName { get; set; }

        [DisplayName("出貨公司")]
        public string ShipCompany { get; set; }

        [DisplayName("訂購日期")]
        public string OrderDate { get; set; }

        [DisplayName("需要日期")]
        public string ShipDate { get; set; }

        public string RequiredDate { get; set; }

        public int Freight { get; set; }

    }
}