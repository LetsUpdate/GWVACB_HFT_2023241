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
    public class AuthorStatController : ControllerBase
    {
        IauthorLogic _logic;

        public AuthorStatController(IauthorLogic logic)
        {
            _logic = logic;
        }


        [HttpGet]
        public List<NameValue> GetQuoteCountByAuthor()
        {
            return _logic.GetQuoteCountByAuthor();
        }
        [HttpGet]
        public List<Quote> GetOldestAuthorQuotes()
        {
            return _logic.GetOldestAuthorQuotes();
        }
        [HttpGet]
        public Author GetAuthorWithMostWords()
        {
            return _logic.GetAuthorWithMostWords();
        }
        [HttpGet]
        public List<NameValue> GetAvgQuoteLengthByAuthor()
        {
            return _logic.GetAvgQuoteLengthByAuthor();
        }

    }
}