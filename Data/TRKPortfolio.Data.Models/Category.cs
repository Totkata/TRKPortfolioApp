namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.PostCategories = new HashSet<PostCategory>();
            this.ProjectCategories = new HashSet<ProjectCategory>();
        }

        public string Name { get; set; }

        public ICollection<PostCategory> PostCategories { get; set; }

        public virtual ICollection<ProjectCategory> ProjectCategories { get; set; }
    }
}
