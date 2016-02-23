namespace GamerSchool.Web.ViewModels.Image
{
    using System.Web.Mvc;
    using GamerSchool.Data.Models;
    using GamerSchool.Web.Infrastructure.Mapping;

    public class ImageViewModel : IMapFrom<Image>, IMapTo<Image>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string OriginalFileName { get; set; }

        public string UrlPath { get; set; }
    }
}
