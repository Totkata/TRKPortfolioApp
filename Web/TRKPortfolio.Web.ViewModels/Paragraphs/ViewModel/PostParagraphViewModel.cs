namespace TRKPortfolio.Web.Views.Paragraphs.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;

    public class PostParagraphViewModel : IMapFrom<PostParagraph>
    {
        public string ParagraphTitle { get; set; }

        public string ParagraphContent { get; set; }

        public string ParagraphPath { get; set; }
    }
}
