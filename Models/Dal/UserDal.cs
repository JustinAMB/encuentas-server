using encuestas.Common;
using encuestas.Models.Request;
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
        public UserResponse Insert(AuthRequest user)
        {
            List<UserResponse> users = new List<UserResponse>();
            Connection conn = new Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn.connect();
            cmd.CommandText = "insertUser";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@email", user.Email));
            cmd.Parameters.Add(new SqlParameter("@username", user.Name));
            cmd.Parameters.Add(new SqlParameter("@password",user.Password));
            SqlDataReader reader = cmd.ExecuteReader();
            UserResponse u = new UserResponse();
            if (reader.Read())
            {
                u.Id = int.Parse(reader["id"].ToString());
                u.Name = reader["username"].ToString();
                u.Email = reader["email"].ToString();
                u.Password = reader["password"].ToString();
            }
            conn.connect();
            return u;


        }
    }
}
