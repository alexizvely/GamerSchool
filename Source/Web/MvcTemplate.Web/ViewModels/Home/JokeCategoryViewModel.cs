namespace GameStore.Web.ViewModels.Home
{
    using GameStore.Data.Models;
    using GameStore.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
