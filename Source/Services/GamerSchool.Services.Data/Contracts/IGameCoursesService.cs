namespace GamerSchool.Services.Data.Contracts
{
    using System.Linq;
    using GamerSchool.Data.Models;

    public interface IGameCoursesService
    {
        IQueryable<GameCourse> GetById(int id);

        IQueryable<GameCourse> GetAll();

        IQueryable<GameCourse> GetLatest(int count);

        IQueryable<GameCourse> GetByTrainerId(string userId);

        IQueryable<GameCourse> GetByStudentId(string userId);

        int Create(GameCourse course);

        void Update(int id, GameCourse course);

        void AddTrainerToCourse(int courseId, string userId);

        void Destroy(int id, string userId);
    }
}
