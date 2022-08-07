using encuestas.Models.Request;
using encuestas.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace encuestas.Service
{
    public interface IPollService
    {
        PollResponse Create(PollRequest poll);
        List<PollResponse> SearchByAuthor(int author);
        PollResponse SearchById(int poll);
    }
}
