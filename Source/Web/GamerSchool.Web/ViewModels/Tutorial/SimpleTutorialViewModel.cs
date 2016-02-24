namespace GamerSchool.Web.ViewModels.Tutorial
{
    using System;
    using AutoMapper;
    using GamerSchool.Data.Models;
    using Infrastructure.Mapping;

    public class SimpleTutorialViewModel : IMapFrom<Tutorial>, IMapTo<Tutorial>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Tutorial, SimpleTutorialViewModel>();
        }
    }
}
