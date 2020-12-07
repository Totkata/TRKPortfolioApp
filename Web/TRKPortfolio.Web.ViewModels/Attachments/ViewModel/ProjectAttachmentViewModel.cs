namespace TRKPortfolio.Web.ViewModels.Attachments.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;

    public class ProjectAttachmentViewModel : IMapFrom<ProjectAttachment>
    {
        public string Id { get; set; }

        public string Extention { get; set; }
    }
}
