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
    [Route("[controller]/[Action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IQuoteLogic _logic;

        public StatController(IQuoteLogic logic)
        {
            _logic = logic;
        }


        [HttpGet]
        public NameValue GetMostPopularQuote()
        {
            return _logic.GetMostPopularQuote();
        }

        //Stats of quotes
        [HttpGet]
        public List<NameValue> GetQuoteCountByAuthor()
        {
            return _logic.GetQuoteCountByAuthor();
        }

}
}