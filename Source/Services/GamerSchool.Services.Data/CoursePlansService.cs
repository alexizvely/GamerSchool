namespace GamerSchool.Services.Data
{

    using System.Linq;
    using GamerSchool.Data.Common.Repositories;
    using GamerSchool.Data.Models;
    using GamerSchool.Services.Data.Contracts;

    public class CoursePlansService : ICoursePlansService
    {
        private readonly IDbRepository<CoursePlan, int> objectives;

        public CoursePlansService(IDbRepository<CoursePlan, int> objectives)
        {
            this.objectives = objectives;
        }

        public IQueryable<CoursePlan> GetById(int id)
        {
            return this.objectives.All()
             .Where(x => x.Id == id);
        }

        public IQueryable<CoursePlan> GetAll()
        {
            var result = this.objectives.All()
          .OrderByDescending(x => x.CreatedOn);

            return result;
        }

        public IQueryable<CoursePlan> GetByCreatorId(string userId)
        {
            return this.objectives.All()
               .Where(x => x.CreatorId == userId)
               .OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<CoursePlan> GetByCourseId(int courseId)
        {
            // TODO:
            return null;
            //    this.objectives.All()
            //.Where(x => x.CourseId == courseId)
            //.OrderByDescending(x => x.CreatedOn);
        }

        public int Create(CoursePlan objective)
        {
            this.objectives.Add(objective);

            this.objectives.Save();

            return objective.Id;
        }

        public void Update(int id, CoursePlan objective)
        {
            var entityToUpdate = this.objectives.GetById(id);

            entityToUpdate.Title = objective.Title;
            entityToUpdate.Description = objective.Description;
            entityToUpdate.Lessons = objective.Lessons;

            this.objectives.Save();
        }

        public void AddToCourse(int courseId, int objectiveId)
        {
            var objective = this.objectives.GetById(objectiveId);

            // objective.CourseId = courseId;

            this.objectives.Save();
        }

        public void Destroy(int id, string userId)
        {
            var entityToDelete = this.objectives.GetById(id);

            if (entityToDelete != null)
            {
                this.objectives.Delete(entityToDelete);
                this.objectives.Save();
            }
        }
    }
}
