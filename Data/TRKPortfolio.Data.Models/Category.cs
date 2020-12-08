namespace TRKPortfolio.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TRKPortfolio.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.PostCategories = new HashSet<PostCategory>();
            this.ProjectCategories = new HashSet<ProjectCategory>();
        }

        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 5)]
        public string Name { get; set; }

        public virtual ICollection<PostCategory> PostCategories { get; set; }

        public virtual ICollection<ProjectCategory> ProjectCategories { get; set; }
    }
}
