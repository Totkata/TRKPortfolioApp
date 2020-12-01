namespace TRKPortfolio.Web.ViewModels.Paragraphs.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;

    public class ProjectParagraphViewModel : IMapFrom<ProjectParagraph>
    {
        public string ParagraphTitle { get; set; }

        public string ParagraphContent { get; set; }
    }
}
