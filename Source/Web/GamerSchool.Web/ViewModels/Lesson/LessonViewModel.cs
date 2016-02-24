namespace GamerSchool.Web.ViewModels.Lesson
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using GamerSchool.Data.Common;
    using GamerSchool.Data.Models;
    using GamerSchool.Web.Infrastructure.Mapping;
    using Ganss.XSS;

    public class LessonViewModel : IMapFrom<GameLesson>, IHaveCustomMappings
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

        [MaxLength(ValidationConstants.MaxLessonYoutubeVideoIdLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string YoutubeVideoId { get; set; }

        public bool IsPrivate { get; set; }

        public string TrainerId { get; set; }

        public string CoachName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<GameLesson, LessonViewModel>()
               .ForMember(x => x.CoachName, opt => opt.MapFrom(x => x.Coach.UserName));
        }
    }
}
