
namespace GamerSchool.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    using Common.Models;

    public class GameLesson : InteractiveEntity
    {
        [MaxLength(ValidationConstants.MaxLessonYoutubeVideoIdLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string VideoTutorialId { get; set; }

        public bool IsPrivate { get; set; }

        public string CoachId { get; set; }

        public virtual ApplicationUser Coach { get; set; }
    }
}
