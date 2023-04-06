using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CrudAppUsingADO.Models
{
    public class EmployeDB
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public List<EmployeeClass1> getEmployee()
        {
            List<EmployeeClass1> EmployeeList = new List<EmployeeClass1>();
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spShowData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader(); 
            while (dr.Read())
            {
                EmployeeClass1 emp = new EmployeeClass1();
                emp.id = Convert.ToInt32(dr.GetValue(0).ToString());
                emp.First_Name = dr.GetValue(1).ToString();
                emp.Last_Name = dr.GetValue(2).ToString();
                emp.Degination = dr.GetValue(3).ToString();
                emp.Age  = Convert.ToInt32(dr.GetValue(4).ToString());
                emp.Salary = Convert.ToInt32(dr.GetValue(5).ToString());
                EmployeeList.Add(emp);
            }
            conn.Close();
            return EmployeeList;    
        }
        public bool AddEmployee(EmployeeClass1 emp)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@First_Name", emp.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", emp.Last_Name);
            cmd.Parameters.AddWithValue("@Degination", emp.Degination);
            cmd.Parameters.AddWithValue("@Age", emp.Age);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            conn.Open();
            int a= cmd.ExecuteNonQuery();
            conn.Close();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateEmployee(EmployeeClass1 emp)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", emp.id);
            cmd.Parameters.AddWithValue("@First_Name", emp.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", emp.Last_Name);
            cmd.Parameters.AddWithValue("@Degination", emp.Degination);
            cmd.Parameters.AddWithValue("@Age", emp.Age);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteEmployee(int id)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            conn.Close();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}