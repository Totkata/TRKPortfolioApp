namespace TRKPortfolio.Web.ViewModels.Administration.Projects.ViewModel
{
    using System;
    using System.Collections.Generic;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;
    using TRKPortfolio.Web.ViewModels.Paragraphs.ViewModel;
    using TRKPortfolio.Web.Views.Paragraphs.ViewModel;

    public class ProjectViewModel : IMapFrom<Project>
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CustomerUsername { get; set; }

        public IEnumerable<ProjectParagraphViewModel> Paragraphs { get; set; }
    }
}
