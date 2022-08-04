using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace encuestas.Common
{
    public class Connection
    {
        public SqlConnection connect()
        {
           
            string strConn = @"user=DESKTOP-1V90MKP\lenovo 1597; password=validpassword; server=DESKTOP-1V90MKP; Trusted_Connection=yes; Database=encuestas; connection timeout=30";

            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                if (conn.State.Equals(ConnectionState.Closed))
                {
                    conn.Open();
                }
                else
                {
                    conn.Close();
                }
            }
            catch (Exception)
            {
                return null;
            }

            return conn;

        }
    }
}
