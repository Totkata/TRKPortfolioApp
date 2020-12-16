namespace TRKPortfolio.Data.Models
{
    using System.Collections.Generic;

    public class Comment : CommentBaseModel
    {
        public Comment()
        {
            this.Replies = new HashSet<Reply>();
        }

        public ICollection<Reply> Replies { get; set; }
    }
}
