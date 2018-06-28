using HW01.Models.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HW01.Models.Service
{
    public class EmployeeService
    {
        public List<Employees> getAllData()
        {
            DaoConnect daoConnect = new DaoConnect();
            SqlConnection conn = daoConnect.SqlConnect();

            //撰寫SQL語法
            string sql = "Select * From [HR].Employees";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Employees");

            List<Employees> employeeList = new List<Employees>();
            employeeList = dataSet.Tables[0].AsEnumerable().Select(
                dataRow => new Employees()
                {
                    EmployeeID = dataRow.Field<int>("EmployeeID"),
                    LastName = dataRow.Field<String>("LastName"),
                    FirstName = dataRow.Field<String>("FirstName").ToString()
                }).ToList();

            return employeeList;
        }
        public Employees getData(int EmployeeID)
        {
            DaoConnect daoConnect = new DaoConnect();
            SqlConnection conn = daoConnect.SqlConnect();
            List<Employees> employeeList = new List<Employees>();
            employeeList = this.getAllData();
            Employees orderData = employeeList.Single(m => m.EmployeeID == EmployeeID);

            return orderData;
        }
    }
}