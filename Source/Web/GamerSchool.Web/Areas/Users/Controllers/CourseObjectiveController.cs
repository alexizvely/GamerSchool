namespace GamerSchool.Web.Areas.Users.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using GamerSchool.Common;
    using GamerSchool.Common.Extensions;
    using GamerSchool.Data.Models;
    using GamerSchool.Services.Data.Contracts;
    using GamerSchool.Web.Controllers;
    using GamerSchool.Web.Infrastructure.Constants;
    using GamerSchool.Web.Infrastructure.Mapping;
    using GamerSchool.Web.Infrastructure.UploadHelpers;
    using GamerSchool.Web.ViewModels.GameCourse;

    public class CourseObjectiveController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly ICoursePlansService objectives;
        private readonly IUsersService users;

        public CourseObjectiveController(ICoursePlansService objectives, IUsersService users)
        {
            this.objectives = objectives;
            this.users = users;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCourseInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var newCourse = this.Mapper.Map<CoursePlan>(model);

                newCourse.CreatorId = currentUserId;

                var result = this.objectives.Create(newCourse);

                return this.RedirectToAction("CourseObjective", "Academy", new { area = string.Empty, id = result });
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var art = this.objectives.GetById(id)
            .To<GameCourseInputModel>()
            .FirstOrDefault();

            return this.View(art);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameCourseInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var updatedCourse = this.Mapper.Map<CoursePlan>(model);

                this.objectives.Update(model.Id, updatedCourse);

                return this.RedirectToAction("CourseObjective", "Academy", new { area = string.Empty, id = model.Id });
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy(int id)
        {
            this.objectives.Destroy(id, this.UserProfile.Id);

            return this.RedirectToAction("Index", "Academy", new { area = "Users", id = 1 });
        }
    }
}
