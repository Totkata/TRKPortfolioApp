namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class AttachmentBaseModel : BaseDeletableModel<string>
    {
        public AttachmentBaseModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Extention { get; set; }
    }
}
