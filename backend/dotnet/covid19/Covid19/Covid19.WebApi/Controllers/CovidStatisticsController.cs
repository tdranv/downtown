using Covid19.Services.Models;
using Covid19.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Covid19.WebApi.Controllers
{
    [ApiController]
    [Route("covidStatistics")]
    public class CovidStatisticsController : ControllerBase
    {
        [HttpGet]
        public async Task<ICollection<RegionCovidStatisticsModel>> Get()
        {
            List<RegionCovidStatisticsModel> regionCovidStatistics = (List<RegionCovidStatisticsModel>) await Covid19Service.GetUnitedStateRegionsCovidStatisticsAsync();

            return regionCovidStatistics;
        }
    }
}
