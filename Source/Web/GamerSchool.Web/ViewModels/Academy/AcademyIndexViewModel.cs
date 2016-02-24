namespace GamerSchool.Web.ViewModels.Academy
{
    using System.Collections.Generic;

    using Common;
    using GameCourse;

    public class AcademyIndexViewModel
    {
        public PaginationViewModel PaginationModel { get; set; }

        public IEnumerable<GameCourseViewModel> Courses { get; set; }
    }
}
