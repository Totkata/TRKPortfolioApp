namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class CommentBaseModel : BaseDeletableModel<int>
    {
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string Text { get; set; }

        // Questionable?
        // public virtual ICollection<CommentLike> CommentLikes { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
