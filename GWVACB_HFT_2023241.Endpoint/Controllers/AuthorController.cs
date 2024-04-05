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
    public class AuthorController : ControllerBase
    {
        private readonly IauthorLogic _logic;

        private readonly IHubContext<SignalRHub> _hub;

        public AuthorController(IauthorLogic logic, IHubContext<SignalRHub> hub)
        {
            _logic = logic;
            _hub = hub;
        }

        // GET: api/Author
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _logic.GetAll();
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return _logic.GetById(id);
        }


        // POST: api/Author
        [HttpPost]
        public void Create([FromBody] Author author)
        {
            _logic.Create(author);
            _hub.Clients.All.SendAsync("AuthorCreated", author);    
     
        }

        // PUT: api/Author/5
        [HttpPut]
        public void Update([FromBody] Author u)
        {
            _logic.Update(u);
            _hub.Clients.All.SendAsync("AuthorUpdated", u);
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var author = _logic.GetById(id);
            _logic.Delete(id);
            _hub.Clients.All.SendAsync("AuthorDeleted", author);
        }
    }
}