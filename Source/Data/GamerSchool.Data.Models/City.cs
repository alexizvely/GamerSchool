namespace GamerSchool.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Common.Models;

    public class City : BaseModel<int>
    {
        [Required]
        [MinLength(ValidationConstants.MinCityNameLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxCityNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Name { get; set; }

    }
}
