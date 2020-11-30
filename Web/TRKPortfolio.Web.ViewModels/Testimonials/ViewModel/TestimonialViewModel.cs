using System;
using System.Collections.Generic;
using System.Text;
using TRKPortfolio.Data.Models;
using TRKPortfolio.Services.Mapping;

namespace TRKPortfolio.Web.ViewModels.Testimonials.ViewModel
{
    public class TestimonialViewModel : IMapFrom<Project>
    {
        public string CustomerUsername { get; set; }

        public string TestimonialText { get; set; }
    }
}
