namespace GamerSchool.Web.ViewModels.GameCourse
{
    using System;
    using System.Linq;
    using AutoMapper;
    using GamerSchool.Data.Models;
    using Infrastructure.Mapping;

    public class SimpleGameCourseViewModel : IMapFrom<GameCourse>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
    }
}
