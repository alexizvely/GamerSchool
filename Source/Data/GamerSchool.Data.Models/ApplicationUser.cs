namespace GamerSchool.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GamerSchool.Data.Common;
    using GamerSchool.Data.Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity, ITKeyEntity<string>
    {

        private ICollection<Tutorial> tutorials;
        private ICollection<GameLesson> gameLessons;
        private ICollection<GameCourse> coursesCouaching;
        private ICollection<GameCourse> coursesTraining;
        private ICollection<Comment> comments;
        private ICollection<Like> likes;
        private ICollection<Merchendise> merchendise;
        private ICollection<Purchase> purchases;
        private ICollection<Address> addresses;


        public ApplicationUser()
        {
            this.tutorials = new HashSet<Tutorial>();
            this.comments = new HashSet<Comment>();
            this.coursesCouaching = new HashSet<GameCourse>();
            this.coursesTraining = new HashSet<GameCourse>();
            this.likes = new HashSet<Like>();
            this.merchendise = new HashSet<Merchendise>();
            this.purchases = new HashSet<Purchase>();
            this.addresses = new HashSet<Address>();
        }

        [MaxLength(ValidationConstants.MaxUserNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string FirstName { get; set; }

        [MaxLength(ValidationConstants.MaxUserNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual City City { get; set; }

        public int? CountryId { get; set; }

        public virtual ICollection<Tutorial> Articles
        {
            get { return this.tutorials; }
            set { this.tutorials = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<GameCourse> CoursesTraining
        {
            get { return this.coursesCouaching; }
            set { this.coursesCouaching = value; }
        }

        public virtual ICollection<GameCourse> CoursesStuding
        {
            get { return this.coursesTraining; }
            set { this.coursesTraining = value; }
        }

        public virtual ICollection<Merchendise> SellingItems
        {
            get { return this.merchendise; }
            set { this.merchendise = value; }
        }

        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<Purchase> Purchases
        {
            get { return this.purchases; }
            set { this.purchases = value; }
        }

        public virtual ICollection<Address> Addresses
        {
            get { return this.addresses; }
            set { this.addresses = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
