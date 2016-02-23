namespace GameStore.Services.Data
{
    using System.Linq;

    using GameStore.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);
    }
}
