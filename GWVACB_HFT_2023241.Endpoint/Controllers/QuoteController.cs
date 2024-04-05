using System.Collections.Generic;
using GWVACB_HFT_2023241.Endpoint.Services;
using GWVACB_HFT_2023241.Logic;
using GWVACB_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GWVACB_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteLogic _logic;
        private readonly IHubContext<SignalRHub> _hub;

        public QuoteController(IQuoteLogic logic, IHubContext<SignalRHub> hub)
        {
            _logic = logic;
            _hub = hub;
        }

        // GET: api/Quote
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _logic.GetAll();
        }

        // GET: api/Quote/5
        [HttpGet("{id}")]
        public Quote Get(int id)
        {
            return _logic.GetById(id);
        }


        // POST: api/Quote
        [HttpPost]
        public void Create([FromBody] Quote author)
        {
            _logic.Create(author);
            _hub.Clients.All.SendAsync("QuoteCreated", author);
        }

        // PUT: api/Quote/5
        [HttpPut]
        public void Update([FromBody] Quote u)
        {
            _logic.Update(u);
            _hub.Clients.All.SendAsync("QuoteUpdated", u);
        }

        // DELETE: api/Quote/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var quote = _logic.GetById(id);
            _logic.Delete(id);
            _hub.Clients.All.SendAsync("QuoteDeleted", quote);
        }
    }
}