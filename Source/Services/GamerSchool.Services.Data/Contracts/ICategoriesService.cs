namespace GamerSchool.Services.Data.Contracts
{
    using System.Linq;

    public interface ICategoriesService
    {
        IQueryable<Category> All();

        Category Create(Category categoryToAdd);

        Category Update(int id, string newName);
    }
}
