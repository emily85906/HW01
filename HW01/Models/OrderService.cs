using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW01.Models
{
    public class OrderService
    {
        public int InsertOrder(Models.Order order)
        {
            return 0;
        }

        public List<Models.Order> GetOrderByCondition(Models.OrderSearchArg arg)
        {
            List<Models.Order> result = new List<Order>();
            result.Add(new Order() { OrderId = 1, CustomerName = "Customer IBVRG", OrderDate = "2006/7/8", ShipDate = "2006/7/12", Freight = 300 });
            result.Add(new Order() { OrderId = 2, CustomerName = "Customer IBVRG", OrderDate = "2006/7/8", ShipDate = "2006/7/12", Freight = 1500 });
            result.Add(new Order() { OrderId = 3, CustomerName = "Customer IBVRG", OrderDate = "2006/7/8", ShipDate = "2006/7/12", Freight = 400 });
            result.Add(new Order() { OrderId = 4, CustomerName = "Customer NRCSK", OrderDate = "2006/7/8", ShipDate = "2006/7/12", Freight = 100 });
            result.Add(new Order() { OrderId = 5, CustomerName = "Customer NRCSK", OrderDate = "2006/7/8", ShipDate = "2006/7/12", Freight = 300 });

            return result;
        }

    }
}