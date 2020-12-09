namespace TRKPortfolio.Web.ViewModels.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;

    public class ReplyViewModel : IMapFrom<Reply>
    {
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
