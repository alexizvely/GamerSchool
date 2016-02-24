namespace GamerSchool.Services.Data
{
    using System.Linq;

    using GamerSchool.Data.Common.Repositories;
    using GamerSchool.Data.Models;
    using GamerSchool.Services.Data.Contracts;
    using GamerSchool.Common.Extensions;

    public class TutorialsService : ITutorialService
    {
        private readonly IDbRepository<Tutorial, int> articles;
        private readonly IDbRepository<Image, int> image;

        public TutorialsService(IDbRepository<Tutorial, int> articles, IDbRepository<Image, int> image)
        {
            this.articles = articles;
            this.image = image;
        }

        public IQueryable<Tutorial> GetById(int id)
        {
            return this.articles.All()
                .Where(x => x.Id == id);
        }

        public IQueryable<Tutorial> GetAll()
        {
            var result = this.articles.All()
                .OrderByDescending(x => x.CreatedOn);

            return result;
        }

        public IQueryable<Tutorial> GetLatest(int count)
        {
            var result = this.articles.All()
                .OrderByDescending(x => x.CreatedOn)
                .Take(count);

            return result;
        }

        public IQueryable<Tutorial> GetByUserId(string userId)
        {
            return this.articles.All()
                .Where(x => x.AuthorId == userId)
                .OrderByDescending(x => x.CreatedOn);
        }

        public int Create(string title, string description, string authorId)
        {
            var newEntity = new Tutorial()
            {
                Title = title,
                Description = description,
                AuthorId = authorId
            };

            this.articles.Add(newEntity);

            this.articles.Save();

            return newEntity.Id;
        }

        public int Create(Tutorial article)
        {
            this.articles.Add(article);

            this.articles.Save();

            return article.Id;
        }

        public void Update(int id, string title, string description)
        {
            var entityToUpdate = this.articles.GetById(id);

            entityToUpdate.Title = title;
            entityToUpdate.Description = description;

            this.articles.Save();
        }

        public void Update(int id, Tutorial article)
        {
            var entityToUpdate = this.articles.GetById(id);

            entityToUpdate.Title = article.Title;
            entityToUpdate.Description = article.Description;
            entityToUpdate.Images = article.Images;
            entityToUpdate.Type = article.Type;

            this.articles.Save();
        }

        public void Destroy(int id, string userId)
        {
            var entityToDelete = this.articles.GetById(id);

            if (entityToDelete != null)
            {
                this.articles.Delete(entityToDelete);
                this.articles.Save();
            }
        }
    }
}
