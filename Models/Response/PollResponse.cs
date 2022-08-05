using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace encuestas.Models.Response
{
    public class PollResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Options {get; set;}
        public string Token { get; set; }
        public string Finish { get; set; }
        public UserResponse Author { get; set; }

    }
}
