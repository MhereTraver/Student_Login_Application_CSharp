using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282Milestone_2.DataAccessLayer
{
    internal class DataHandler
    {
        string connection = "Server=.;Initial Catalog=BCITversity;Integrated Security=SSPI";
        
        public void UpdateStudent()
        {

        }
        public void DeleteStudent(int ID)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("spDeleteInfor", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentNumber",ID);
                connect.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public DataTable SearchStudent(int studentID)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("spSearchInfor",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentNumber",studentID);
                conn.Open();
                DataTable dt = new DataTable();

                using (SqlDataReader readData =cmd.ExecuteReader())
                {
                    dt.Load(readData);
                    return dt;
                }
            }
        }
        //Displaying Data From the Database Using Stored Procedures
        public DataTable DisplayStudent()
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlDataAdapter adapter = new SqlDataAdapter("spDisplayData", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable tableData = new DataTable();

            adapter.Fill(tableData);
            return tableData;
        }
    }
}
