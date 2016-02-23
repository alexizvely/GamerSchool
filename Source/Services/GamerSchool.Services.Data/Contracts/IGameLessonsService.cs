namespace GamerSchool.Services.Data.Contracts
{
    using System.Linq;
    using GamerSchool.Data.Models;

    public interface IGameLessonsService
    {
        IQueryable<GameLesson> GetById(int id);

        IQueryable<GameLesson> GetAll();

        IQueryable<GameLesson> GetByTrainerId(string userId);

        IQueryable<GameLesson> GetByCourseId(int courseId);

        IQueryable<GameLesson> GetByCourseObjectiveId(int courseObjectiveId);

        int Create(GameLesson lesson);

        void Update(int id, GameLesson lesson);

        void AddToCourseObjective(int id, int courseObjectiveId);

        void Destroy(int id, string userId);
    }
}
