using HW01.Models.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HW01.Models.Service
{
    public class CustomerService
    {
        public List<Customers> getAllData()
        {
            DaoConnect daoConnect = new DaoConnect();
            SqlConnection conn = daoConnect.SqlConnect();

            //撰寫SQL語法
            string sql = "Select * From [Sales].Customers";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Customers");

            List<Customers> customerList = new List<Customers>();
            customerList = dataSet.Tables[0].AsEnumerable().Select(
                dataRow => new Customers()
                {
                    CustomerID = dataRow.Field<int>("CustomerID"),
                    CompanyName = dataRow.Field<String>("CompanyName"),
                    ContactName = dataRow.Field<String>("ContactName"),
                    Address = dataRow.Field<String>("Address").ToString()
                }).ToList();

            return customerList;
        }
        public Customers getData(int CustomerID)
        {
            DaoConnect daoConnect = new DaoConnect();
            SqlConnection conn = daoConnect.SqlConnect();
            List<Customers> customerList = new List<Customers>();
            customerList = this.getAllData();
            Customers orderData = customerList.Single(m => m.CustomerID == CustomerID);

            return orderData;
        }
    }
}