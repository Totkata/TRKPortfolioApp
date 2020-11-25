namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class Testimonial : BaseDeletableModel<int>
    {
        public string Text { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
