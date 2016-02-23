namespace GamerSchool.Data.Models
{
    using Common.Models;

    public class Merchendise : InteractiveEntity
    {
        public decimal PriceUSD { get; set; }

        public int Availability { get; set; }

        public string SellerId { get; set; }

        public ApplicationUser Seller { get; set; }
    }
}
