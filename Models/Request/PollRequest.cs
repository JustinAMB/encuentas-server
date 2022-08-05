using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace encuestas.Models.Request
{
    public class PollRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Options { get; set; }
        [Required]
        public string Finish { get; set; }
        [Required]
        public int Author { get; set; }
        public string Token { get; set; }
    }
}
