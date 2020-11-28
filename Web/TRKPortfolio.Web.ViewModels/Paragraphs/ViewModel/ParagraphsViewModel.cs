namespace TRKPortfolio.Web.Views.Paragraphs.ViewModel
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;

    public class ParagraphsViewModel : IMapFrom<ProjectParagraph>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
