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
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private INoteLogic _logic;

        public AnalysisController(INoteLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public List<NameVaule> GetNoteCountByUser()
        {
            throw new NotImplementedException();
        }
    }
}