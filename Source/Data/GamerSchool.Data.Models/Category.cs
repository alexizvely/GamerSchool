﻿namespace GamerSchool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Common.Models;

    public class Category : BaseModel<int>
    {
        private ICollection<InteractiveEntity> entities;

        public Category()
        {
            this.entities = new HashSet<InteractiveEntity>();
        }

        [Required]
        [MinLength(ValidationConstants.MinCategoryNameLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxCategoryNameLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Name { get; set; }

        public virtual ICollection<InteractiveEntity> Entities
        {
            get { return this.entities; }
            set { this.entities = value; }
        }
    }
}
