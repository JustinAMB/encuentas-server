using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace encuestas.Models
{
    public class Resp
    {
        public int Status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public Resp()
        {
            this.Status = 0;
        }
    }
}
