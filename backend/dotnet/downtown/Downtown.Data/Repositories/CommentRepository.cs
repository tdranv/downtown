using Downtown.Core.Models;
using Downtown.Data.Entities;
using System;

namespace Downtown.Data.Repositories
{
    public class CommentRepository : BaseRepository<Comment, DataComment>, ICommentRepository
    {
        public CommentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override DataComment ToDataEntity(Comment model)
        {
            throw new NotImplementedException();
        }

        protected override Comment ToModel(DataComment entity)
        {
            throw new NotImplementedException();
        }
    }
}
