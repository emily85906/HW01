using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HW01.Models
{
    public class Orders
    {
        [DisplayName("訂單編號")]
        [Required]
        public int OrderID { get; set; }

        [DisplayName("客戶")]
        [Required]
        public int CustomerID { get; set; }

        [DisplayName("負責員工")]
        [Required]
        public int EmployeeID { get; set; }

        [DisplayName("訂單日期")]
        [Required]
        public DateTime OrderDate { get; set; }

        [DisplayName("需要日期")]
        [Required]
        public DateTime RequiredDate { get; set; }

        [DisplayName("出貨日期")]
        [Required]
        public DateTime? ShippedDate { get; set; }

        [DisplayName("貨物編號")]
        [Required]
        public int ShipperID { get; set; }

        [DisplayName("運費")]
        [Required]
        public decimal Freight { get; set; }

        [DisplayName("送貨地址")]
        [Required]
        public string ShipAddress { get; set; }

        [DisplayName("城市")]
        [Required]
        public string ShipCity { get; set; }

        [DisplayName("地區")]
        public string ShipRegion { get; set; }

        [DisplayName("郵遞區號")]
        [Required]
        public string ShipPostalCode { get; set; }

        [DisplayName("國家")]
        [Required]
        public string ShipCountry { get; set; }
    }
}