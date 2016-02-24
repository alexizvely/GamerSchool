
namespace GamerSchool.Web.ViewModels.FPS
{
    using System.Collections.Generic;
    using GamerSchool.Web.ViewModels.Common;
    using Tutorial;

    public class FPSIndexViewModel
    {
        public PaginationViewModel PaginationModel { get; set; }

        public IEnumerable<TutorialViewModel> ArtArticles { get; set; }
    }
}
