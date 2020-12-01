namespace TRKPortfolio.Web.ViewModels.Index.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Web.ViewModels.Administration.Posts.ViewModel;
    using TRKPortfolio.Web.ViewModels.Testimonials.ViewModel;

    public class IndexViewModel
    {
        public IEnumerable<TestimonialViewModel> Testimonials { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
