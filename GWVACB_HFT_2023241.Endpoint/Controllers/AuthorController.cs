using System.Collections.Generic;
using GWVACB_HFT_2023241.Logic;
using GWVACB_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;

namespace GWVACB_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IauthorLogic _logic;

        public AuthorController(IauthorLogic logic)
        {
            _logic = logic;
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
        }

        // PUT: api/Author/5
        [HttpPut]
        public void Update([FromBody] Author u)
        {
            _logic.Update(u);
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.Delete(id);
        }
    }
}