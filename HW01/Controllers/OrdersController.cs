using HW01.Models;
using HW01.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW01.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            //訂單列
            OrderService orderService = new OrderService();
            List<Orders> orderList = orderService.getAllData();
            CustomerService customerService = new CustomerService();
            List<Customers> customerList = customerService.getAllData();
            EmployeeService employeeService = new EmployeeService();
            List<Employees> employeeList = employeeService.getAllData();

            ViewBag.customerAllList = customerList;
            ViewBag.orderAllList = orderList;
            ViewBag.employeeAllList = employeeList;
            return View();
        }

        // GET: Orders
        public ActionResult InsertOrder()
        {
            //員工下拉
            EmployeeService employeeService = new EmployeeService();
            List<Employees> employeeList = employeeService.getAllData();
            List<SelectListItem> employeeSelectItemList = new List<SelectListItem>();
            employeeSelectItemList = employeeList.Select(
                m => new SelectListItem()
                {
                    Text = m.LastName + m.FirstName,
                    Value = m.EmployeeID.ToString()
                }).ToList();
            ViewBag.employeeSelectItemList = employeeSelectItemList;

            //客戶下拉
            CustomerService customerService = new CustomerService();
            List<Customers> customerList = customerService.getAllData();
            List<SelectListItem> customerSelectItemList = new List<SelectListItem>();
            customerSelectItemList = customerList.Select(
                m => new SelectListItem()
                {
                    Text = m.CompanyName + m.ContactName,
                    Value = m.CustomerID.ToString()
                }).ToList();
            ViewBag.customerSelectItemList = customerSelectItemList;

            //訂單下拉
            ShipperService shipperService = new ShipperService();
            List<Shippers> shipperList = shipperService.getAllData();
            List<SelectListItem> shipperSelectItemList = new List<SelectListItem>();
            shipperSelectItemList = shipperList.Select(
                m => new SelectListItem()
                {
                    Text = m.ShipperID.ToString(),
                    Value = m.ShipperID.ToString()
                }).ToList();
            ViewBag.shipperSelectItemList = shipperSelectItemList;

            return View();
        }

        [HttpPost]
        public ActionResult InsertOrder(Orders orders)
        {
            OrderService orderService = new OrderService();
            orderService.insert(orders);

            return RedirectToAction("./Index");
        }


        public ActionResult UpdateOrder(int OrderID)
        {
            //員工下拉
            EmployeeService employeeService = new EmployeeService();
            List<Employees> employeeList = employeeService.getAllData();
            List<SelectListItem> employeeSelectItemList = new List<SelectListItem>();
            employeeSelectItemList = employeeList.Select(
                m => new SelectListItem()
                {
                    Text = m.LastName + m.FirstName,
                    Value = m.EmployeeID.ToString()
                }).ToList();
            ViewBag.employeeSelectItemList = employeeSelectItemList;

            //客戶下拉
            CustomerService customerService = new CustomerService();
            List<Customers> customerList = customerService.getAllData();
            List<SelectListItem> customerSelectItemList = new List<SelectListItem>();
            customerSelectItemList = customerList.Select(
                m => new SelectListItem()
                {
                    Text = m.CompanyName + m.ContactName,
                    Value = m.CustomerID.ToString()
                }).ToList();
            ViewBag.customerSelectItemList = customerSelectItemList;

            //訂單下拉
            ShipperService shipperService = new ShipperService();
            List<Shippers> shipperList = shipperService.getAllData();
            List<SelectListItem> shipperSelectItemList = new List<SelectListItem>();
            shipperSelectItemList = shipperList.Select(
                m => new SelectListItem()
                {
                    Text = m.ShipperID.ToString(),
                    Value = m.ShipperID.ToString()
                }).ToList();
            ViewBag.shipperSelectItemList = shipperSelectItemList;

            OrderService orderService = new OrderService();
            Orders orderData = orderService.getData(OrderID);


            return View(orderData);
        }

        [HttpPost]
        public ActionResult UpdateOrder(Orders orders)
        {
            OrderService orderService = new OrderService();
            orderService.update(orders);

            return RedirectToAction("./Index");
        }

        public ActionResult InquireOrder(int OrderID)
        {
            //訂單資料

            OrderService orderService = new OrderService();
            Orders orderData = orderService.getData(OrderID);

            return View(orderData);
        }
        //[HttpPost]
        public ActionResult DeleteOrder(Orders orders)
        {
            OrderService orderService = new OrderService();
            orderService.delete(orders);

            return RedirectToAction("./Index");
        }
    }
}