using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;

namespace CalculatorApi
{
    public class DatabaseDiagnosticsNOEF : IDiagnostics
    {
        public void Log(string stringBeingLogged)
        {            
            string sqlString = "INSERT INTO " +
                "Logs " +
                "(" +
                "logs_date," +
                "logs_time," +
                "logs_content)" +
                "VALUES " +
                "(" +
                "@l_date," +
                "@l_time," +
                "@l_content)";
            string s = ConfigurationManager.ConnectionStrings["CalculatorContext2"].ConnectionString;
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand(sqlString, con);
            cmd.Parameters.AddWithValue("@l_date", DateTime.Now);
            cmd.Parameters.AddWithValue("@l_time", DateTime.Now.TimeOfDay);
            cmd.Parameters.AddWithValue("@l_content", stringBeingLogged);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
            

    }
}
