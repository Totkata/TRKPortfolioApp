using System;
using System.Collections.Generic;
using System.Text;
using TRKPortfolio.Data.Models;
using TRKPortfolio.Services.Mapping;

namespace TRKPortfolio.Web.ViewModels.Attachments.ViewModel
{
    public class AttachmentViewModel : IMapFrom<PostAttachment>
    {
        public string Id { get; set; }

        public string Extention { get; set; }
    }
}
