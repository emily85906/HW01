using HW01.Models.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HW01.Models
{
    public class OrderService
    {
        public List<Orders> getAllData()
        {
            DaoConnect daoConnect = new DaoConnect();
            SqlConnection conn = daoConnect.SqlConnect();

            //撰寫SQL語法
            string sql = "Select * From [Sales].Orders";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Orders");

            List<Orders> orderList = new List<Orders>();
            orderList = dataSet.Tables[0].AsEnumerable().Select(
                dataRow => new Orders()
                {
                    OrderID = dataRow.Field<int>("OrderID"),
                    CustomerID = dataRow.Field<int>("CustomerID"),
                    EmployeeID = dataRow.Field<int>("EmployeeID"),
                    OrderDate = dataRow.Field<DateTime>("OrderDate"),
                    RequiredDate = dataRow.Field<DateTime>("RequiredDate"),
                    ShippedDate = dataRow.Field<DateTime?>("ShippedDate"),
                    ShipperID = dataRow.Field<int>("ShipperID"),
                    Freight = dataRow.Field<decimal>("Freight"),
                    ShipAddress = dataRow.Field<String>("ShipAddress"),
                    ShipCity = dataRow.Field<String>("ShipCity"),
                    ShipRegion = dataRow.Field<String>("ShipRegion"),
                    ShipPostalCode = dataRow.Field<String>("ShipPostalCode"),
                    ShipCountry = dataRow.Field<String>("ShipCountry").ToString()
                }).ToList();

            return orderList;
        }

        public Orders getData(int OrderID)
        {
            DaoConnect daoConnect = new DaoConnect();
            SqlConnection conn = daoConnect.SqlConnect();
            List<Orders> orderList = new List<Orders>();
            orderList = this.getAllData();
            Orders orderData = orderList.Single(m => m.OrderID == OrderID);

            return orderData;
        }

        public void insert(Orders data)
        {
            DaoConnect daoConnect = new DaoConnect();
            SqlConnection conn = daoConnect.SqlConnect();

            string sql = @"INSERT INTO [Sales].Orders(CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipperID,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry) 
                            Values (@CustomerID,@EmployeeID,@OrderDate,@RequiredDate,@ShippedDate,@ShipperID,@Freight,@ShipName,@ShipAddress,@ShipCity,@ShipRegion,@ShipPostalCode,@ShipCountry) SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@CustomerID", data.CustomerID));
            cmd.Parameters.Add(new SqlParameter("@EmployeeID", data.EmployeeID));
            cmd.Parameters.Add(new SqlParameter("@OrderDate", data.OrderDate));
            cmd.Parameters.Add(new SqlParameter("@RequiredDate", data.RequiredDate));
            cmd.Parameters.Add(new SqlParameter("@ShippedDate", data.ShippedDate));
            cmd.Parameters.Add(new SqlParameter("@ShipperID", data.ShipperID));
            cmd.Parameters.Add(new SqlParameter("@Freight", data.Freight));
            cmd.Parameters.Add(new SqlParameter("@ShipName", ""));
            cmd.Parameters.Add(new SqlParameter("@ShipAddress", data.ShipAddress));
            cmd.Parameters.Add(new SqlParameter("@ShipCity", data.ShipCity));
            cmd.Parameters.Add(new SqlParameter("@ShipRegion", data.ShipRegion == null ? "" : data.ShipRegion));
            cmd.Parameters.Add(new SqlParameter("@ShipPostalCode", data.ShipPostalCode));
            cmd.Parameters.Add(new SqlParameter("@ShipCountry", data.ShipCountry));

            conn.Open();
            int orderId = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
        }

        public void update(Orders data)
        {
            DaoConnect daoConnect = new DaoConnect();
            SqlConnection conn = daoConnect.SqlConnect();

            string sql = @"UPDATE [Sales].Orders 
                    SET 
                        CustomerID = @CustomerID
                        ,EmployeeID = @EmployeeID
                        ,OrderDate = @OrderDate
                        ,RequiredDate = @RequiredDate
                        ,ShippedDate = @ShippedDate
                        ,ShipperID = @ShipperID
                        ,Freight = @Freight
                        ,ShipName = @ShipName
                        ,ShipAddress = @ShipAddress
                        ,ShipCity = @ShipCity
                        ,ShipRegion = @ShipRegion
                        ,ShipPostalCode = @ShipPostalCode
                        ,ShipCountry = @ShipCountry
                    WHERE OrderID = @OrderID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@OrderID", data.OrderID));
            cmd.Parameters.Add(new SqlParameter("@CustomerID", data.CustomerID));
            cmd.Parameters.Add(new SqlParameter("@EmployeeID", data.EmployeeID));
            cmd.Parameters.Add(new SqlParameter("@OrderDate", data.OrderDate));
            cmd.Parameters.Add(new SqlParameter("@RequiredDate", data.RequiredDate));
            cmd.Parameters.Add(new SqlParameter("@ShippedDate", data.ShippedDate));
            cmd.Parameters.Add(new SqlParameter("@ShipperID", data.ShipperID));
            cmd.Parameters.Add(new SqlParameter("@Freight", data.Freight));
            cmd.Parameters.Add(new SqlParameter("@ShipName", ""));
            cmd.Parameters.Add(new SqlParameter("@ShipAddress", data.ShipAddress));
            cmd.Parameters.Add(new SqlParameter("@ShipCity", data.ShipCity));
            cmd.Parameters.Add(new SqlParameter("@ShipRegion", data.ShipRegion == null ? "" : data.ShipRegion));
            cmd.Parameters.Add(new SqlParameter("@ShipPostalCode", data.ShipPostalCode));
            cmd.Parameters.Add(new SqlParameter("@ShipCountry", data.ShipCountry));

            conn.Open();
            int orderId = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
        }
        public void delete(Orders data)
        {
            DaoConnect daoConnect = new DaoConnect();
            SqlConnection conn = daoConnect.SqlConnect();

            string sql = @"DELETE FROM  [Sales].Orders
                    WHERE OrderID = @OrderID";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add(new SqlParameter("@OrderID", data.OrderID));

            conn.Open();
            int orderId = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
        }
    }
}