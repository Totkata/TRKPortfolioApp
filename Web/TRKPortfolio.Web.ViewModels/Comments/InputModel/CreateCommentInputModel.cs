namespace TRKPortfolio.Web.ViewModels.Comments.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreateCommentInputModel
    {
        public int PostId { get; set; }

        public int CommentId { get; set; }

        public string Text { get; set; }
    }
}
