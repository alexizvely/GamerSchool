using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerSchool.Data.Models
{ 

    public class GameCourse : InteractiveEntity
    {
        private ICollection<ApplicationUser> trainee;
        private ICollection<ApplicationUser> coaches;
        private ICollection<CoursePlan> objectives;

        public GameCourse()
        {
            this.trainee = new HashSet<ApplicationUser>();
            this.coaches = new HashSet<ApplicationUser>();
            this.objectives = new HashSet<CoursePlan>();
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<ApplicationUser> Traineis
        {
            get { return this.trainee; }
            set { this.trainee = value; }
        }

        public virtual ICollection<ApplicationUser> Coaches
        {
            get { return this.trainers; }
            set { this.trainers = value; }
        }

        public virtual ICollection<CourseObjective> Objectives
        {
            get { return this.objectives; }
            set { this.objectives = value; }
        }
    }
}
