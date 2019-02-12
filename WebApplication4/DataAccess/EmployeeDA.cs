using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebApplication4.Models;

namespace WebApplication4.DataAccess
{
    public class EmployeeDA
    {
        public Employee getEmployeeDetails(int id)
        {
            Employee employee = new Employee();

            string query = "SELECT ID,FullName,JobTitle,Age FROM tblEmployee WHERE ID = @ID";
            string connectionStr = "Server=DESKTOP-21NRFEV;Database=TestDB;User ID=test;Password=test";
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter IDParam = new SqlParameter();
            IDParam.ParameterName = "@ID";
            IDParam.Value = id;
            IDParam.DbType = System.Data.DbType.Int32;

            command.Parameters.Add(IDParam);

            SqlDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                employee.id = Convert.ToInt32(rd["ID"]);
                employee.name = Convert.ToString(rd["FullName"]);
                employee.age = Convert.ToInt32(rd["Age"]);
                employee.jobTitle = Convert.ToString(rd["JobTitle"]);
               
            }
            connection.Close();
            return employee;
        }

        public List<Employee> getEmployees()
        {
            
            List<Employee> employees = new List<Employee>();

            string query = "SELECT ID,FullName,JobTitle,Age FROM tblEmployee";
            string connectionStr = "Server=DESKTOP-21NRFEV;Database=TestDB;User ID=test;Password=test";
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                Employee employee = new Employee();
                employee.id = Convert.ToInt32(rd["ID"]);
                employee.name = Convert.ToString(rd["FullName"]);
                employee.age = Convert.ToInt32(rd["Age"]);
                employee.jobTitle = Convert.ToString(rd["JobTitle"]);
                employees.Add(employee);
            }
            connection.Close();
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            string query = "INSERT INTO tblEmployee(FullName,Age,JobTitle) VALUES(@Fullname,@Age,@Jobtitle)";
            string connectionStr = "Server=DESKTOP-21NRFEV;Database=TestDB;User ID=test;Password=test";
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter fullNameParam = new SqlParameter();
            fullNameParam.ParameterName = "@Fullname";
            fullNameParam.Value = employee.name;
            fullNameParam.DbType = System.Data.DbType.String;

            SqlParameter ageParam = new SqlParameter();
            ageParam.ParameterName = "@Age";
            ageParam.Value = employee.age;
            ageParam.DbType = System.Data.DbType.Int32;

            SqlParameter jobTitleParam = new SqlParameter();
            jobTitleParam.ParameterName = "@Jobtitle";
            jobTitleParam.Value = employee.jobTitle;
            jobTitleParam.DbType = System.Data.DbType.String;

            command.Parameters.Add(fullNameParam);
            command.Parameters.Add(ageParam);
            command.Parameters.Add(jobTitleParam);
            

            command.ExecuteNonQuery();

        }

        public void UpdateEmployee(Employee employee)
        {
            string query = "UPDATE tblEmployee SET FullName = @Fullname, JobTitle = @Jobtitle  , Age = @Age WHERE ID = @ID";
            string connectionStr = "Server=DESKTOP-21NRFEV;Database=TestDB;User ID=test;Password=test";
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter fullNameParam = new SqlParameter();
            fullNameParam.ParameterName = "@Fullname";
            fullNameParam.Value = employee.name;
            fullNameParam.DbType = System.Data.DbType.String;

            SqlParameter ageParam = new SqlParameter();
            ageParam.ParameterName = "@Age";
            ageParam.Value = employee.age;
            ageParam.DbType = System.Data.DbType.Int32;

            SqlParameter jobTitleParam = new SqlParameter();
            jobTitleParam.ParameterName = "@Jobtitle";
            jobTitleParam.Value = employee.jobTitle;
            jobTitleParam.DbType = System.Data.DbType.String;

            SqlParameter IDParam = new SqlParameter();
            IDParam.ParameterName = "@ID";
            IDParam.Value = employee.id;
            IDParam.DbType = System.Data.DbType.Int32;

            command.Parameters.Add(fullNameParam);
            command.Parameters.Add(ageParam);
            command.Parameters.Add(jobTitleParam);
            command.Parameters.Add(IDParam);

            command.ExecuteNonQuery();
        }

        public void DeleteEmployee(int id)
        {
            string query = "DELETE FROM tblEmployee WHERE ID = @ID";
            string connectionStr = "Server=DESKTOP-21NRFEV;Database=TestDB;User ID=test;Password=test";
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter IDParam = new SqlParameter();
            IDParam.ParameterName = "@ID";
            IDParam.Value = id;
            IDParam.DbType = System.Data.DbType.Int32;

            command.Parameters.Add(IDParam);

            command.ExecuteNonQuery();
        }
    }
}