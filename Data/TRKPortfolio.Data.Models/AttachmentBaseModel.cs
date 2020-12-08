namespace TRKPortfolio.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TRKPortfolio.Data.Common.Models;

    public class AttachmentBaseModel : BaseDeletableModel<string>
    {
        public AttachmentBaseModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Extention { get; set; }
    }
}
