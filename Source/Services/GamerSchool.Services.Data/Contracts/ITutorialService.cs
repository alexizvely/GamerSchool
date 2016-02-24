namespace GamerSchool.Services.Data.Contracts
{
    using System.Linq;
    using GamerSchool.Data.Models;

    public interface ITutorialService
    {
        IQueryable<Tutorial> GetById(int id);

        IQueryable<Tutorial> GetAll();

        IQueryable<Tutorial> GetByUserId(string userId);

        IQueryable<Tutorial> GetLatest(int count);

        int Create(string title, string description, string authorId);

        int Create(Tutorial article);

        void Update(int id, string title, string description);

        void Update(int id, Tutorial article);

        void Destroy(int id, string userId);
    }
}
