namespace GamerSchool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;
    using Common.Models;

    public class Purchase : BaseModel<int>
    {
        private ICollection<Merchendise> items;

        public Purchase()
        {
            this.items = new HashSet<Merchendise>();
        }

        public PurchaseStatus Status { get; set; }

        [MaxLength(ValidationConstants.MaxPurchaseCommentLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Comment { get; set; }

        public string BuyerId { get; set; }

        public virtual ApplicationUser Buyer { get; set; }

        public string SellerId { get; set; }

        public virtual ApplicationUser Seller { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Merchendise> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
    }
}
