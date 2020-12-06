namespace TRKPortfolio.Web.ViewModels.Comments.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;
    using TRKPortfolio.Web.Views.Paragraphs.ViewModel;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Text { get; set; }

        public IEnumerable<ReplyViewModel> Replies { get; set; }
    }
}
