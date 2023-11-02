using System.Collections.Generic;
using GWVACB_HFT_2023241.Logic;
using GWVACB_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;

namespace GWVACB_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteLogic _logic;

        public QuoteController(IQuoteLogic logic)
        {
            _logic = logic;
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
        }

        // PUT: api/Quote/5
        [HttpPut]
        public void Update([FromBody] Quote u)
        {
            _logic.Update(u);
        }

        // DELETE: api/Quote/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.Delete(id);
        }
    }
}