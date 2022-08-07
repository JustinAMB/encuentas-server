using encuestas.Models;
using encuestas.Models.Request;
using encuestas.Models.Response;
using encuestas.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace encuestas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private IPollService _pollService;

        public PollController(IPollService pollService)
        {
            this._pollService = pollService;
        }
       
        [HttpPost]
        public IActionResult Save(PollRequest poll)
        {
            Resp oResp = new Resp();
            try
            {
                oResp.data = _pollService.Create(poll);
                oResp.Status = 1;
                return Ok(oResp);
            }
            catch (Exception e) {
                oResp.message = e.Message;
                return BadRequest(oResp);
            }
           
        }

        

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Resp oResp = new Resp();
            try
            {
                oResp.data = _pollService.SearchById(id);
                oResp.Status = 1;
                return Ok(oResp);
            }
            catch (Exception e)
            {
                oResp.message = e.Message;
                return BadRequest(oResp);
            }
        }
        [HttpGet("author/{id}")]
        public IActionResult GetByAuthor(int id)
        {
            Resp oResp = new Resp();
            try
            {
                oResp.data = _pollService.SearchByAuthor( id);
                oResp.Status = 1;
                return Ok(oResp);
            }
            catch (Exception e)
            {
                oResp.message = e.Message;
                return BadRequest(oResp);
            }
        }







    }
}
