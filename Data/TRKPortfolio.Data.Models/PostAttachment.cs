namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PostAttachment : AttachmentBaseModel
    {
        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
