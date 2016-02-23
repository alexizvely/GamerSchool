namespace GamerSchool.Services.Data
{
    using System.Linq;
    using GamerSchool.Data.Common.Repositories;
    using GamerSchool.Data.Models;
    using GamerSchool.Services.Data.Contracts;

    public class MerchendisesService : IMerchendisesService
    {
        private readonly IDbRepository<Merchendise, int> items;

        public MerchendisesService(IDbRepository<Merchendise, int> items)
        {
            this.items = items;
        }

        public IQueryable<Merchendise> GetById(int id)
        {
            return this.items.All()
             .Where(x => x.Id == id);
        }

        public IQueryable<Merchendise> GetAll()
        {
            var result = this.items.All()
                .OrderByDescending(x => x.CreatedOn);

            return result.AsQueryable();
        }

        public IQueryable<Merchendise> GetByUserId(string userId)
        {
            return this.items.All()
              .Where(x => x.SellerId == userId)
              .OrderByDescending(x => x.CreatedOn);
        }

        public int Create(string title, string description, string sellerId, decimal price, int availability)
        {
            var newEntity = new Merchendise()
            {
                Title = title,
                Description = description,
                SellerId = sellerId,
                PriceUSD = price,
                Availability = availability
            };

            this.items.Add(newEntity);

            this.items.Save();

            return newEntity.Id;
        }

        public int Create(Merchendise item)
        {
            this.items.Add(item);

            this.items.Save();

            return item.Id;
        }

        public void Update(int id, string title, string description, decimal prise, int availability)
        {
            var entityToUpdate = this.items.GetById(id);

            entityToUpdate.Title = title;
            entityToUpdate.Description = description;
            entityToUpdate.PriceUSD = prise;
            entityToUpdate.Availability = availability;

            this.items.Save();
        }

        public void Update(int id, Merchendise item)
        {
            var entityToUpdate = this.items.GetById(id);

            entityToUpdate.Title = item.Title;
            entityToUpdate.Description = item.Description;
            entityToUpdate.PriceUSD = item.PriceUSD;
            entityToUpdate.Availability = item.Availability;
            entityToUpdate.Images = item.Images;

            this.items.Save();
        }

        public void Destroy(int id, string userId)
        {
            var entityToDelete = this.items.GetById(id);

            if (entityToDelete != null)
            {
                this.items.Delete(entityToDelete);
                this.items.Save();
            }
        }
    }
}
