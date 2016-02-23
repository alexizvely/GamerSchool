namespace GamerSchool.Services.Data
{
    using System.Linq;
    using GamerSchool.Data.Common.Repositories;
    using GamerSchool.Data.Models;
    using GamerSchool.Services.Data.Contracts;

    public class GameLessonsService : IGameLessonsService
    {
        private readonly IDbRepository<GameLesson, int> lessons;

        public GameLessonsService(IDbRepository<GameLesson, int> lessons)
        {
            this.lessons = lessons;
        }

        public IQueryable<GameLesson> GetById(int id)
        {
            return this.lessons.All()
                            .Where(x => x.Id == id);
        }

        public IQueryable<GameLesson> GetAll()
        {
            var result = this.lessons.All()
                                .OrderByDescending(x => x.CreatedOn);

            return result;
        }

        public IQueryable<GameLesson> GetByTrainerId(string userId)
        {
            return this.lessons.All()
                            .Where(x => x.CoachId == userId)
                            .OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<GameLesson> GetByCourseId(int courseId)
        {
            //TODO:
            return null;
            //return this.lessons.All()
            //              .Where(x => x.CourseObjective.CourseId == courseId)
            //              .OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<GameLesson> GetByCourseObjectiveId(int courseObjectiveId)
        {
            //TODO:
            return null;

            //return this.lessons.All()
            //              .Where(x => x.CourseObjectiveId == courseObjectiveId)
            //              .OrderByDescending(x => x.CreatedOn);
        }

        public int Create(GameLesson lesson)
        {
            this.lessons.Add(lesson);

            this.lessons.Save();

            return lesson.Id;
        }

        public void Update(int id, GameLesson lesson)
        {
            var entityToUpdate = this.lessons.GetById(id);

            entityToUpdate.Title = lesson.Title;
            entityToUpdate.Description = lesson.Description;
            entityToUpdate.VideoTutorialId = lesson.VideoTutorialId;

            this.lessons.Save();
        }

        public void AddToCourseObjective(int id, int courseObjectiveId)
        {
            var lesson = this.lessons.GetById(id);

            // TODO:
            // lesson.CourseObjectiveId = courseObjectiveId;

            this.lessons.Save();
        }

        public void Destroy(int id, string userId)
        {
            var entityToDelete = this.lessons.GetById(id);

            if (entityToDelete != null)
            {
                this.lessons.Delete(entityToDelete);
                this.lessons.Save();
            }
        }
    }
}
