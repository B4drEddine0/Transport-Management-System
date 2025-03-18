using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication27
{
    class DB_General : Class1
    {
        public SqlCommand CMD;
        public DB_General()
        {
            CMD = new SqlCommand();
            CMD.Connection = cn;
        }

      
        public void general_query(string query)
        {
            try
            {
                cn.Open();
                CMD.CommandText = query;
                CMD.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // Log or handle exception as needed
                throw new Exception("SQL Error: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }


        public DataTable MyTable(string query)
        {
            try
            {
                cn.Open();
                CMD.CommandText = query;
                SqlDataAdapter myAdapter = new SqlDataAdapter(CMD);
                DataTable mytbl = new DataTable();
                myAdapter.Fill(mytbl);
                return mytbl;
            }
            catch (SqlException ex)
            {
                // Log or handle exception as needed
                throw new Exception("SQL Error: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}