namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class ProjectLike : BaseModel<int>
    {
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public bool IsSaved { get; set; }
    }
}
