namespace GamerSchool.Services.Data.Contracts
{
    using System.Linq;
    using GamerSchool.Data.Models;

    public interface ICommentsService
    {
        Comment AddNew(Comment toAdd);

        IQueryable<Comment> AllByEntity(int id);

        void DeleteCommentById(int id);
    }
}
