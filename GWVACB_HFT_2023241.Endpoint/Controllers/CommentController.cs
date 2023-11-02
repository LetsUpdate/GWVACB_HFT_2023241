using System.Collections.Generic;
using GWVACB_HFT_2023241.Logic;
using GWVACB_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;

namespace GWVACB_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentLogic _logic;

        public CommentController(ICommentLogic logic)
        {
            _logic = logic;
        }

        // GET: api/Comment
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _logic.GetAll();
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public Comment Get(int id)
        {
            return _logic.GetById(id);
        }


        // POST: api/Comment
        [HttpPost]
        public void Create([FromBody] Comment author)
        {
            _logic.Create(author);
        }

        // PUT: api/Comment/5
        [HttpPut]
        public void Update([FromBody] Comment u)
        {
            _logic.Update(u);
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.Delete(id);
        }
    }
    
}