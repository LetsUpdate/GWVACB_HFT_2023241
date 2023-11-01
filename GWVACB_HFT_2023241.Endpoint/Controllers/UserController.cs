using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWVACB_HFT_2023241.Logic;
using GWVACB_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GWVACB_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        IUserLogic _logic;

        public UserController(IUserLogic logic)
        {
            _logic = logic;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return this._logic.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _logic.GetById(id);
        }
        

        // POST: api/User
        [HttpPost]
        public void Create([FromBody] User user)
        {
            _logic.Create(user);
        }

        // PUT: api/User/5
        [HttpPut]
        public void Update([FromBody] User u)
        {
            _logic.Update(u);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.Delete(id);
        }
    }
}
