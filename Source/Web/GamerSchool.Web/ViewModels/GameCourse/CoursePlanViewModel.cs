using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerSchool.Web.ViewModels.GameCourse
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using Ganss.XSS;
    using GamerSchool.Data.Common;
    using GamerSchool.Data.Models;
    using GamerSchool.Web.Infrastructure.Mapping;
    using GamerSchool.Web.ViewModels.Lesson;

    public class CoursePlanViewModel : IMapFrom<CoursePlan>, IHaveCustomMappings
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

        public string CreatorName { get; set; }

        public virtual ICollection<LessonViewModel> Lessons { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<CoursePlan, CoursePlanViewModel>()
            .ForMember(x => x.CreatorName, opt => opt.MapFrom(x => x.Creator.UserName));
        }
    }
}
