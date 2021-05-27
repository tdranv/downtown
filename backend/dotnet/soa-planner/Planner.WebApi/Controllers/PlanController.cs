using Microsoft.AspNetCore.Mvc;
using Planner.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Planner.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("plans")]
    public class PlanController : ControllerBase
    {
        private readonly IPlanRepository planRepository;

        //private readonly string[] RequiredScopes = new string[] { "access_as_user" };

        public PlanController(IPlanRepository planRepository)
        {
            this.planRepository = planRepository ?? throw new ArgumentNullException(nameof(planRepository));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(RequiredScopes);
            var plans = await this.planRepository.GetAllAsync().ConfigureAwait(false);

            return this.Ok(plans);
        }
    }
}
