namespace GamerSchool.Web.ViewModels.Strategy
{
    using System.Collections.Generic;
    using GamerSchool.Web.ViewModels.Common;
    using Tutorial;

    public class StrategyIndexViewModel
    {
        public PaginationViewModel PaginationModel { get; set; }

        public IEnumerable<TutorialViewModel> ArtArticles { get; set; }
    }
}
