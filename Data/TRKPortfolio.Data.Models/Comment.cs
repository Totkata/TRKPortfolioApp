namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class Comment : CommentBaseModel
    {
        public Comment()
        {
            this.Replies = new HashSet<Reply>();
        }

        public ICollection<Reply> Replies { get; set; }
    }
}
