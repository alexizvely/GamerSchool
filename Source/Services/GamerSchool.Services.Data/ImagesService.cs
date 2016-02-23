namespace GamerSchool.Services.Data
{
    using GamerSchool.Data.Common.Repositories;
    using GamerSchool.Data.Models;
    using GamerSchool.Services.Data.Contracts;

    public class ImagesService : IImagesService
    {
        private readonly IDbRepository<Image, int> images;

        public ImagesService(IDbRepository<Image, int> images)
        {
            this.images = images;
        }

        public void Delete(int id)
        {
            var entityToDelete = this.images.GetById(id);

            this.images.Delete(entityToDelete);

            this.images.Save();
        }
    }
}
