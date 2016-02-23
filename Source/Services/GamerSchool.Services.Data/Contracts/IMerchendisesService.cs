namespace GamerSchool.Services.Data.Contracts
{
    using System.Linq;
    using GamerSchool.Data.Models;

    public interface IMerchendisesService
    {
        IQueryable<Merchendise> GetById(int id);

        IQueryable<Merchendise> GetAll();

        IQueryable<Merchendise> GetByUserId(string userId);

        int Create(string title, string description, string authorId, decimal prise, int availability);

        int Create(Merchendise article);

        void Update(int id, string title, string description, decimal prise, int availability);

        void Update(int id, Merchendise article);

        void Destroy(int id, string userId);
    }
}
