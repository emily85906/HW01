using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW01.Models
{
    public class OrderSearchArg
    {
        
        public int OrderId { get; set; }

        public string CustomerName { get; set; }

        public string EmployeeName { get; set; }

        public string ShipCompany { get; set; }

        public string OrderDate { get; set; }

        public string ShipDate { get; set; }

        public string RequiredDate { get; set; }

        public int Freight { get; set; }
    }
}