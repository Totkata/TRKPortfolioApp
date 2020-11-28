namespace TRKPortfolio.Web.ViewModels.Testimonials.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreateTestimonialInputModel
    {
        public string Text { get; set; }

        public byte WorkQualityRating { get; set; }

        public byte SkillRating { get; set; }

        public byte DeadlineRating { get; set; }

        public byte CooperatingRating { get; set; }

        public byte AvaliabilityRating { get; set; }

        public byte ComunicationRating { get; set; }
    }
}