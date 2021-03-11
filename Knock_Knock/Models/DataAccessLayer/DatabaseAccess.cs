using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Knock_Knock.Models.DataAccessLayer
{
    public class DatabaseAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlTransaction transaction;

        public DatabaseAccess() {
            connection = getConnection();
        }

        protected DataTable offlineSelection(string query) 
        {
            command = new SqlCommand();
            DataTable result = new DataTable();
            SqlDataReader rdr = null;
            try
            {
                command.Connection = connection;
                command.CommandText = query;

                connection.Open();
                rdr = command.ExecuteReader();
                result.Load(rdr);
                connection.Close();
                return result;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("offline selection error query= " + query + " error message ="+e.Message);
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                return null;
            }
        }

        protected DataTable onlineSelection(string query, SqlParameter[] parameters)
        {
            command = new SqlCommand();
            DataTable result = new DataTable();
            SqlDataReader rdr = null;
            try
            {
                command.Connection = connection;
                command.CommandText = query;

                if(parameters!=null)
                    foreach(SqlParameter param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                connection.Open();
                rdr = command.ExecuteReader();
                result.Load(rdr);
                connection.Close();

                return result;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("online selection error query= " + query + " error message =" + e.Message);
                if (connection.State==ConnectionState.Open)
                    connection.Close();
                return null;
            }
        }

        protected int onlineOperation(string query,SqlParameter[] parameters)
        {
            command = new SqlCommand();
            int effectedRow;
            try
            {
                command.Connection = connection;
                command.CommandText = query;

                if(parameters!=null)
                    foreach(SqlParameter param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                connection.Open();
                effectedRow = command.ExecuteNonQuery();
                connection.Close();
                return effectedRow;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("online operation error query= " + query + " error message =" + e.Message);
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                return -1;
            }
        }

        protected object offlineScaler(string query)
        {
            command = new SqlCommand();
            object result;
            try
            {
                command.Connection = connection;
                command.CommandText = query;

                connection.Open();
                result = command.ExecuteScalar();
                connection.Close();
                return result;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("offline scalar error query= " + query + " error message =" + e.Message);
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                return -1;
            }
        }

        protected object onlineScaler(string query,SqlParameter[] parameters)
        {
            command = new SqlCommand();
            object result;
            try
            {
                command.Connection = connection;
                command.CommandText = query;

                if (parameters != null)
                    foreach (SqlParameter param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                connection.Open();
                result = command.ExecuteScalar();
                connection.Close();
                return result;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("online scaler error query= " + query + " error message =" + e.Message);
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                return -1;
            }
        }

        private SqlConnection getConnection()
        {
            try
            {
                return new SqlConnection(WebConfigurationManager.OpenWebConfiguration("/web.config").ConnectionStrings.ConnectionStrings["local"].ConnectionString);
            }
            catch (SqlException ){
                return null;
            }
        }
    }
}