namespace TRKPortfolio.Web.ViewModels.Posts.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Web.ViewModels.Administration.Posts.ViewModel;
    using TRKPortfolio.Web.ViewModels.Attachments.ViewModel;
    using TRKPortfolio.Web.ViewModels.Comments.InputModel;
    using TRKPortfolio.Web.ViewModels.Comments.ViewModel;

    public class PostCommentInputModel
    {
        public CreateCommentInputModel Comment { get; set; }

        public PostViewModel Post { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public string Attachments { get; set; }
    }
}
