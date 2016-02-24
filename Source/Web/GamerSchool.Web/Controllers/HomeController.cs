namespace GamerSchool.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Services.Data.Contracts;
    using Services.Web;
    using ViewModels.GameCourse;
    using ViewModels.Tutorial;
    using Infrastructure.Mapping;
    public class HomeController : BaseController
    {
        private const int ItemCount = 5;
        private const int TimeForCache = 5 * 60;

        private ICacheService cacheService;
        private IGameCoursesService courseService;
        private ITutorialService tutorialService;

        public HomeController(ICacheService cacheService, IGameCoursesService courseService, ITutorialService tutorialService)
        {
            this.cacheService = cacheService;
            this.courseService = courseService;
            this.tutorialService = tutorialService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetTutorialsPartial()
        {
            var articlesData =
                this.cacheService.Get(
                    "Tutorials",
                    () => this.tutorialService
                        .GetLatest(ItemCount)
                        .To<SimpleTutorialViewModel>()
                        .ToList(),
                    TimeForCache);

            return this.PartialView("_PartialSimpleTutorialView", articlesData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetGameCoursePartial()
        {
            var productsData =
                this.cacheService.Get(
                    "GameCourses",
                    () => this.courseService
                        .GetLatest(ItemCount)
                        .To<SimpleGameCourseViewModel>()
                        .ToList(),
                    TimeForCache);

            return this.PartialView("_PartialGameCourseSimpleView", productsData);
        }
    }
}
