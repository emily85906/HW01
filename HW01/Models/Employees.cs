using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HW01.Models
{
    public class Employees
    {
        [DisplayName("員工編號")]
        public int EmployeeID { get; set; }

        [DisplayName("姓氏")]
        public string LastName { get; set; }

        [DisplayName("名字")]
        public string FirstName { get; set; }
    }
}