namespace GamerSchool.Services.Data
{
    using System;
    using System.Linq;
    using GamerSchool.Data.Common.Repositories;
    using GamerSchool.Data.Models;
    using GamerSchool.Services.Data.Contracts;

    public class CommentsService : ICommentsService
    {
        private readonly IDbRepository<Comment, int> comments;

        public CommentsService(IDbRepository<Comment, int> comments)
        {
            this.comments = comments;
        }

        public Comment AddNew(Comment toAdd)
        {
            this.comments.Add(toAdd);
            this.comments.Save();

            return toAdd;
        }

        public IQueryable<Comment> AllByEntity(int id)
        {
            return this.comments.All()
                .Where(c => c.EntityId == id)
                .OrderByDescending(c => c.CreatedOn);
        }

        public void DeleteCommentById(int id)
        {
            var entityToDelete = this.comments.GetById(id);

            this.comments.Delete(entityToDelete);
            this.comments.Save();
        }
    }
}
