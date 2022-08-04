using encuestas.Common;
using encuestas.Models.Response;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace encuestas.Models.Dal
{
    public class UserDal
    {
        public List<UserResponse> GetUsers() { 
            List<UserResponse> users = new List<UserResponse>();
            Connection conn=new Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn.connect();
            cmd.CommandText = "select * from users";
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserResponse user = new UserResponse();
                user.Id = int.Parse(reader["id"].ToString());
                user.Name = reader["username"].ToString();
                user.Email = reader["email"].ToString();
                user.Password = reader["password"].ToString(); 
                users.Add(user);
            }
            conn.connect();
            return users;


        }
    }
}
