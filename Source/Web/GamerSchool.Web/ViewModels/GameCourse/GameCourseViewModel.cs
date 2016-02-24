namespace GamerSchool.Web.ViewModels.GameCourse
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using GamerSchool.Data.Common;
    using GamerSchool.Data.Models;
    using GamerSchool.Web.Infrastructure.Mapping;
    using GamerSchool.Web.ViewModels.Comment;
    using GamerSchool.Web.ViewModels.Image;
    using GamerSchool.Web.ViewModels.User;
    using Ganss.XSS;

    public class GameCourseViewModel : IMapFrom<GameCourse>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription
        {
            get
            {
                var sanitizer = new HtmlSanitizer();
                sanitizer.AllowedAttributes.Add("class");

                return sanitizer.Sanitize(this.Description);
            }
        }

        public virtual ICollection<CommentViewModel> Comments { get; set; }

        public int LikesCount { get; set; }

        public virtual ICollection<ImageViewModel> Images { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<UserViewModel> Students { get; set; }

        public ICollection<UserViewModel> Trainers { get; set; }

        public ICollection<CoursePlan> Objectives { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<GameCourse, GameCourseViewModel>()
               .ForMember(x => x.LikesCount, opt => opt.MapFrom(x => x.Likes.Any() ? x.Likes.Count() : 0));
        }
    }
}
