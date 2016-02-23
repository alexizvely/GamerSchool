namespace GamerSchool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data.Common;
    using Data.Common.Models;

    public class CoursePlan : BaseModel<int>
    {
        private ICollection<GameLesson> lessons;

        public CoursePlan()
        {
            this.lessons = new HashSet<GameLesson>();
        }

        [Required]
        [MinLength(ValidationConstants.MinCourseObjectiveNameLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxCourseObjectiveNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Title { get; set; }

        [MaxLength(ValidationConstants.MaxCourseObjectiveDescriptionLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Description { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<GameLesson> Lessons
        {
            get { return this.lessons; }
            set { this.lessons = value; }
        }
    }
}
