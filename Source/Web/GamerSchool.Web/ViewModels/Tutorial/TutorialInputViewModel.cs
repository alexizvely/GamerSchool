namespace GamerSchool.Web.ViewModels.Tutorial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using GamerSchool.Data.Common;
    using GamerSchool.Data.Models;
    using GamerSchool.Web.Infrastructure.Mapping;
    using GamerSchool.Web.ViewModels.Image;

    public class TutorialInputViewModel : IMapTo<Tutorial>, IMapFrom<Tutorial>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinInteractiveEntityTitleLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxInteractiveEntityTitleLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Title { get; set; }

        [MaxLength(ValidationConstants.MaxInteractiveEntityDescriptionLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        [AllowHtml]
        public string Description { get; set; }

        // [HiddenInput(DisplayValue = false)]
        public TutorialType Type { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string AuthorId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string AuthorName { get; set; }

        [NotMapped]
        // [ValidateFile(ErrorMessage = "Please select a JPEG image smaller than 1MB")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        [HiddenInput(DisplayValue = false)]
        public IEnumerable<ImageViewModel> Images { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Tutorial, TutorialInputViewModel>()
                 .ForMember(x => x.Images, opt => opt
                     .MapFrom(x => x.Images.Where(y => !y.IsDeleted).OrderByDescending(y => y.CreatedOn).ToList()))
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}
