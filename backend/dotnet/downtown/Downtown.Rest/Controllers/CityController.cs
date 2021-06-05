using Downtown.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Downtown.Rest.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("cities")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository cityRepository;

        //private readonly string[] RequiredScopes = new string[] { "access_as_user" };

        public CityController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(RequiredScopes);
            var plans = await this.cityRepository.GetAllAsync().ConfigureAwait(false);

            return this.Ok(plans);
        }
    }
}
