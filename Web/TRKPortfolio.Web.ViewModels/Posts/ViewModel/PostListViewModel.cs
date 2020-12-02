namespace TRKPortfolio.Web.ViewModels.Posts.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Web.ViewModels.Administration.Posts.ViewModel;

    public class PostListViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
