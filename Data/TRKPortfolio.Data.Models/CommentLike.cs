namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class CommentLike : BaseModel<int>
    {
        public int CommentId { get; set; }

        public Comment Comment { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public bool IsSaved { get; set; }
    }
}
