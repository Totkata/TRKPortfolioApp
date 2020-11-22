namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class Paragraph : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
