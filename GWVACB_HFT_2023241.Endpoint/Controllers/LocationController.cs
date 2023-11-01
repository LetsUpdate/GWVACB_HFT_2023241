using System.Collections.Generic;
using GWVACB_HFT_2023241.Logic;
using GWVACB_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;

namespace GWVACB_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationLogic _logic;

        public LocationController(ILocationLogic logic)
        {
            _logic = logic;
        }

        // GET: api/Location
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return _logic.GetAll();
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public Location Get(int id)
        {
            return _logic.GetById(id);
        }


        // POST: api/Location
        [HttpPost]
        public void Create([FromBody] Location user)
        {
            _logic.Create(user);
        }

        // PUT: api/Location/5
        [HttpPut]
        public void Update([FromBody] Location u)
        {
            _logic.Update(u);
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.Delete(id);
        }
    }
    
}