namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TestimonialAttachment
    {
        public int TestimonialId { get; set; }

        public virtual Testimonial Testimonial { get; set; }

        public string AttachmentId { get; set; }

        public Attachment Attachment { get; set; }
    }
}
