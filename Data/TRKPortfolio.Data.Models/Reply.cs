namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Reply : CommentBaseModel
    {
        public int CommentId { get; set; }

        public Comment Comment { get; set; }
    }
}
