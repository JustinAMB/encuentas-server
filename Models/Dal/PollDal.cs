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
    public class PollDal
    {
        public List<PollResponse> getPolls() { 
            List<PollResponse> polls = new List<PollResponse>();
            Connection conn=new Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn.connect();
            cmd.CommandText = "select POLL.id,options,POLL.token,finish,POLL.name,author,email,username from POLL inner join users on POLL.author = users.id";
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PollResponse poll = new PollResponse();
                poll.Id = int.Parse(reader["id"].ToString());
                poll.Name = reader["name"].ToString();
                poll.Token = reader["token"].ToString();
                poll.Finish= reader["finish"].ToString();
                poll.Options= reader["options"].ToString();
                poll.Author = new UserResponse();
                poll.Author.Id= int.Parse(reader["author"].ToString());
                poll.Author.Email= (reader["email"].ToString());
                poll.Author.Name= (reader["username"].ToString());
                polls.Add(poll);
            }
            conn.connect();
            return polls;
        }
        public PollResponse getPoll(int id) { 
            PollResponse poll = new PollResponse();
            Connection conn=new Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn.connect();
            cmd.CommandText = "select POLL.id,options,POLL.token,finish,POLL.name,author,email,username from POLL inner join users on POLL.author = users.id where POLL.id=@id";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                poll.Id = int.Parse(reader["id"].ToString());
                poll.Name = reader["name"].ToString();
                poll.Token = reader["token"].ToString();
                poll.Finish= reader["finish"].ToString();
                poll.Options= reader["options"].ToString();
                poll.Author = new UserResponse();
                poll.Author.Id= int.Parse(reader["author"].ToString());
                poll.Author.Email= (reader["email"].ToString());
                poll.Author.Name= (reader["username"].ToString());
            }
            conn.connect();
            return poll;
        }
        public PollResponse insertPoll(PollRequest poll) { 
            PollResponse p = new PollResponse();
            Connection conn=new Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn.connect();
            cmd.CommandText = "insertPoll";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@name", poll.Name));
            cmd.Parameters.Add(new SqlParameter("@token", poll.Token));
            cmd.Parameters.Add(new SqlParameter("@finish", poll.Finish));
            cmd.Parameters.Add(new SqlParameter("@options", poll.Options));
            cmd.Parameters.Add(new SqlParameter("@author", poll.Author));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                p.Id = int.Parse(reader["id"].ToString());
                p.Name = reader["name"].ToString();
                p.Token = reader["token"].ToString();
                p.Finish= reader["finish"].ToString();
                p.Options= reader["options"].ToString();
                p.Author = new UserResponse();
                p.Author.Id= int.Parse(reader["author"].ToString());
                p.Author.Email= (reader["email"].ToString());
                p.Author.Name= (reader["username"].ToString());
            }
            conn.connect();
            return p;
        }
            
    }
}
