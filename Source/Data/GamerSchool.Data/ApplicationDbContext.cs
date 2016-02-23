namespace GamerSchool.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using GamerSchool.Data.Common.Models;
    using GamerSchool.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Tutorial> Tutorials { get; set; }

        public IDbSet<TutorialComment> TutorialComments { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<GameCourse> GameCourses { get; set; }

        public IDbSet<GameLessons> GameLessons { get; set; }

        public IDbSet<CoursePlan> CoursePlans { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Address> Addresses { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Merchendise> Merchendies { get; set; }

        public IDbSet<Purchase> Purchases { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
