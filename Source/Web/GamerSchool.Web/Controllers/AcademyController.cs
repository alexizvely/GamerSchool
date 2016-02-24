namespace GamerSchool.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using GamerSchool.Services.Data.Contracts;
    using GamerSchool.Web.Infrastructure.Mapping;
    using GamerSchool.Web.ViewModels.Common;
    using GamerSchool.Web.ViewModels.Lesson;
    using ViewModels.Academy;
    using ViewModels.GameCourse;

    public class AcademyController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly IGameCoursesService courses;
        private readonly ICoursePlansService plans;
        private readonly IGameLessonsService lessons;

        public AcademyController(IGameCoursesService courses, ICoursePlansService objectives, IGameLessonsService lessons)
        {
            this.courses = courses;
            this.plans = objectives;
            this.lessons = lessons;
        }

        public ActionResult Index(int page = 1)
        {
            // var page = page;
            var allItemsCount = this.courses.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

            var courses = this.courses
                .GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .To<GameCourseViewModel>()
                .ToList();

            var paginationModel = new PaginationViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Path = "/School/Index/"
            };

            var model = new AcademyIndexViewModel()
            {
                PaginationModel = paginationModel,
                Courses = courses
            };

            return this.View(model);
        }

        public ActionResult Course(int id)
        {
            var course = this.courses
              .GetById(id)
              .To<GameCourseViewModel>()
              .FirstOrDefault();

            return this.View("CourseDetails", course);
        }

        public ActionResult Courses(int page)
        {
            var course = this.courses
                .GetById(page)
                .To<GameCourseViewModel>()
                .FirstOrDefault();

            return this.View("CourseDetails", course);
        }

        public ActionResult CourseObjective(int id)
        {
            var objective = this.plans
               .GetById(id)
               .To<CoursePlanViewModel>()
               .FirstOrDefault();

            return this.View("CourseObjectiveDetails", objective);
        }

        public ActionResult CourseObjectives(int page)
        {
            return this.Json(page);
        }

        public ActionResult Lesson(int id)
        {
            var lesson = this.lessons
               .GetById(id)
               .To<LessonViewModel>()
               .FirstOrDefault();

            return this.View("LessonDetails", lesson);
        }

        public ActionResult Lessons(int page)
        {
            return this.Json(page);
        }
    }
}