using encuestas.Models.Dal;
using encuestas.Models.Request;
using encuestas.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace encuestas.Service
{
    public class PollService : IPollService
    {
        private PollDal dal;
        public PollService() {
            this.dal = new PollDal();
        }

        public PollResponse Create(PollRequest poll)
        {
            return dal.insertPoll(poll);
           
        }

        public List<PollResponse> SearchByAuthor(int author)
        {
            return dal.getPollsByAuthor(author);
        }

        public PollResponse SearchById(int poll)
        {
            return dal.getPoll(poll);
        }
    }
}
