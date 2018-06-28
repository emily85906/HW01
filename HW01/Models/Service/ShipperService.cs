using HW01.Models.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HW01.Models.Service
{
    public class ShipperService
    {
        public List<Shippers> getAllData()
        {
            DaoConnect daoConnect = new DaoConnect();
            SqlConnection conn = daoConnect.SqlConnect();

            //撰寫SQL語法
            string sql = "Select * From [Sales].Shippers";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Shippers");

            List<Shippers> shipperList = new List<Shippers>();
            shipperList = dataSet.Tables[0].AsEnumerable().Select(
                dataRow => new Shippers()
                {
                    ShipperID = dataRow.Field<int>("ShipperID"),
                    CompanyName = dataRow.Field<String>("CompanyName"),
                    Phone = dataRow.Field<String>("Phone").ToString()
                }).ToList();

            return shipperList;
        }
    }
}