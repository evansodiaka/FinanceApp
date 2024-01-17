using FinanceMentor1.Server.Storage;
using FinanceMentor1.Shared;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace FinanceMentor1.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EarningsController: ControllerBase
    {
        private readonly IRepository<Earning> _earningRepository;

        public EarningsController (IRepository<Earning> earningRepository)
        {
            _earningRepository = earningRepository;
        }

        [HttpGet]
        public IEnumerable<Earning> Get()
        {
            return _earningRepository.GetAll().OrderBy(earning => earning.Date);
        }

        [HttpPost]
        public void Post (Earning earning)
        {
             _earningRepository.Add(earning);
        }

    }
}
