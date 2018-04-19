using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW01.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            Models.OrderService orderService = new Models.OrderService();
            var orders = orderService.GetOrderByCondition(new Models.OrderSearchArg()
            {
                OrderId = 1,
                CustomerName = "",
                EmployeeName = "",
                ShipCompany = "",
                OrderDate = "",
                ShipDate = "",
                RequiredDate = "",
                Freight = 300
            });

            ViewBag.OrderAdd = orders[0].OrderDate;
            return View();
        }
        [HttpPost()]
        public ActionResult Index(FormCollection form)
        {
            return View("Index");
        }
        /// <summary>
        /// url進入
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult InsertOrder()
        {
            Models.Order result = new Models.Order();
            return View(result);
        }


        [HttpPost]
        public ActionResult InsertOrder(Models.Order order)
        {
            return View();
        }
    }
}