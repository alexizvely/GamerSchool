namespace GamerSchool.Services.Data.Contracts
{
    using System.Linq;
    using GamerSchool.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> All();

        Category Create(Category categoryToAdd);

        Category Update(int id, string newName);
    }
}
