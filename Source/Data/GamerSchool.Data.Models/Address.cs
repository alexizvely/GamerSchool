namespace GamerSchool.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Common;
    using Data.Common.Models;

    public class Address : BaseModel<int>
    {
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinAddressLineLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxAddressLineLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string AddressText { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinTelephoneNumberLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxTelephoneNumberLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string TelephoneNumber { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinRecipientNamesLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxRecipientNamesLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string RecipientNames { get; set; }
    }
}
