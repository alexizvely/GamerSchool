namespace GamerSchool.Services.Data
{
    using System;
    using System.Linq;
    using GamerSchool.Data.Common.Repositories;
    using GamerSchool.Data.Models;
    using GamerSchool.Services.Data.Contracts;

    public class GameCoursesService : IGameCoursesService
    {
        private readonly IDbRepository<GameCourse, int> courses;
        private readonly IDbRepository<ApplicationUser, string> users;

        public GameCoursesService(IDbRepository<GameCourse, int> courses, IDbRepository<ApplicationUser, string> users)
        {
            this.courses = courses;
            this.users = users;
        }

        public IQueryable<GameCourse> GetById(int id)
        {
            return this.courses.All()
              .Where(x => x.Id == id);
        }

        public IQueryable<GameCourse> GetAll()
        {
            var result = this.courses.All()
             .OrderByDescending(x => x.CreatedOn);

            return result;
        }

        public IQueryable<GameCourse> GetLatest(int count)
        {
            var result = this.courses.All()
             .OrderByDescending(x => x.CreatedOn)
             .Take(count);

            return result;
        }

        public IQueryable<GameCourse> GetByTrainerId(string userId)
        {
            return this.courses.All()
              .Where(x => x.Coaches.Any(y => y.Id == userId))
              .OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<GameCourse> GetByStudentId(string userId)
        {
            return this.courses.All()
         .Where(x => x.Traineis.Any(y => y.Id == userId))
         .OrderByDescending(x => x.CreatedOn);
        }

        public int Create(GameCourse course)
        {
            this.courses.Add(course);

            this.courses.Save();

            return course.Id;
        }

        public void Update(int id, GameCourse course)
        {
            var entityToUpdate = this.courses.GetById(id);

            entityToUpdate.Title = course.Title;
            entityToUpdate.Description = course.Description;
            entityToUpdate.Images = course.Images;
            entityToUpdate.Coaches = course.Coaches;
            entityToUpdate.Traineis = course.Traineis;

            this.courses.Save();
        }

        public void AddTrainerToCourse(int courseId, string userId)
        {
            var courseToUpdate = this.courses.GetById(courseId);
            var trainer = this.users.GetById(userId);

            courseToUpdate.Coaches.Add(trainer);

            this.courses.Save();
        }

        public void Destroy(int id, string userId)
        {
            var entityToDelete = this.courses.GetById(id);

            if (entityToDelete != null)
            {
                this.courses.Delete(entityToDelete);
                this.courses.Save();
            }
        }
    }
}
