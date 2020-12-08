namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class Rating : BaseModel<int>
    {
        public int TestimonialId { get; set; }

        public virtual Testimonial Testimonial { get; set; }

        public byte WorkRating { get; set; }

        public byte SkillRating { get; set; }

        public byte DeadlineRating { get; set; }

        public byte CooperatingRating { get; set; }

        public byte AvaliabilityRating { get; set; }

        public byte ComunicationRating { get; set; }
    }
}
