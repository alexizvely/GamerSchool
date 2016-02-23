namespace GameStore.Services.Data
{
    using System.Linq;

    using GameStore.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}
