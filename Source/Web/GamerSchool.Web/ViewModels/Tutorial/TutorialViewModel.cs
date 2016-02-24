namespace GamerSchool.Web.ViewModels.Tutorial
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
    using GamerSchool.Web.ViewModels.Image;
    using Ganss.XSS;

    public class TutorialViewModel : IMapFrom<Tutorial>, IHaveCustomMappings
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedOn { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? ModifiedOn { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string SanitizedDescription
        {
            get
            {
                var sanitizer = new HtmlSanitizer();
                sanitizer.AllowedAttributes.Add("class");

                return sanitizer.Sanitize(this.Description);
            }
        }

        public string ArticleType { get; set; }

        // [HiddenInput(DisplayValue = false)]
        public string AuthorName { get; set; }

        public string AuthorId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public ICollection<Comment> Comments { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int LikesCount { get; set; }

        [HiddenInput(DisplayValue = false)]
        public ICollection<ImageViewModel> Images { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Tutorial, TutorialViewModel>()
                .ForMember(x => x.LikesCount, opt => opt.MapFrom(x => x.Likes.Any() ? x.Likes.Count() : 0))
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(x => x.Author.Id))
                .ForMember(x => x.ArticleType, opt => opt.MapFrom(x => x.Type.ToString()))
                .ForMember(x => x.Comments, opt => opt
                    .MapFrom(x => x.Comments.Where(y => !y.IsDeleted).OrderByDescending(y => y.CreatedOn).ToList()))
                .ForMember(x => x.Images, opt => opt
                    .MapFrom(x => x.Images.Where(y => !y.IsDeleted).OrderByDescending(y => y.CreatedOn).ToList()));
        }
    }
}
