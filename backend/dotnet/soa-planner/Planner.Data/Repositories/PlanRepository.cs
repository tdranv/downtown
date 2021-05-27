using Planner.Core.Models;
using Planner.Data.Entities;

namespace Planner.Data.Repositories
{
    public class PlanRepository : BaseDataEntityRepository<Plan, DataPlan>, IPlanRepository
    {
        public PlanRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}