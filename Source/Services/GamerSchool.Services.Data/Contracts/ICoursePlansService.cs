namespace GamerSchool.Services.Data.Contracts
{
    using System.Linq;
    using GamerSchool.Data.Models;

    public interface ICoursePlansService
    {
        IQueryable<CoursePlan> GetById(int id);

        IQueryable<CoursePlan> GetAll();

        IQueryable<CoursePlan> GetByCreatorId(string userId);

        IQueryable<CoursePlan> GetByCourseId(int courseId);

        int Create(CoursePlan course);

        void Update(int id, CoursePlan course);

        void AddToCourse(int courseId, int objectiveId);

        void Destroy(int id, string userId);
    }
}
