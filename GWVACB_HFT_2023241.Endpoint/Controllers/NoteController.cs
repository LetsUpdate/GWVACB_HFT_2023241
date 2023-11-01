using System.Collections.Generic;
using GWVACB_HFT_2023241.Logic;
using GWVACB_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;

namespace GWVACB_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteLogic _logic;

        public NoteController(INoteLogic logic)
        {
            _logic = logic;
        }

        // GET: api/Note
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return _logic.GetAll();
        }

        // GET: api/Note/5
        [HttpGet("{id}")]
        public Note Get(int id)
        {
            return _logic.GetById(id);
        }


        // POST: api/Note
        [HttpPost]
        public void Create([FromBody] Note user)
        {
            _logic.Create(user);
        }

        // PUT: api/Note/5
        [HttpPut]
        public void Update([FromBody] Note u)
        {
            _logic.Update(u);
        }

        // DELETE: api/Note/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.Delete(id);
        }
    }
}