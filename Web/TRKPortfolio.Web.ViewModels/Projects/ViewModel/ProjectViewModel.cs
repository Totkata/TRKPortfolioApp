namespace TRKPortfolio.Web.ViewModels.Projects.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;
    using TRKPortfolio.Web.Views.Paragraphs.ViewModel;

    public class ProjectViewModel : IMapFrom<Project>
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CustomerUsername { get; set; }

        public IEnumerable<ParagraphsViewModel> ProjectParagraphs { get; set; }

    }
}
