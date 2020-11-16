namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            this.CommentLikes = new HashSet<CommentLike>();
            this.Replies = new HashSet<Comment>();
        }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string Text { get; set; }

        public int? ReplyCommentId { get; set; }

        public virtual Comment ReplyComment { get; set; }

        public virtual ICollection<CommentLike> CommentLikes { get; set; }

        public virtual ICollection<Comment> Replies { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
