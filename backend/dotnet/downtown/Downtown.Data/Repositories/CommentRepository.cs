using Downtown.Core.Models;
using Downtown.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Downtown.Data.Repositories
{
    public class CommentRepository : BaseDataEntityRepository<Comment, DataComment>, ICommentRepository
    {
        public CommentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Comment[]> GetByEventId(int eventId)
        {
            var result = await this.UnitOfWork.GetAllQuery<DataComment>().Where(x => x.EventId == eventId).ToArrayAsync();

            return result.Select(x => this.ToModel(x)).ToArray();
        }
    }
}
