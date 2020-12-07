namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class Project : BaseDeletableModel<int>
    {
        public Project()
        {
            this.ProjectCategories = new HashSet<ProjectCategory>();
            this.ProjectSkills = new HashSet<ProjectSkill>();
            this.ProjectLikes = new HashSet<ProjectLike>();
            this.ProjectSaves = new HashSet<ProjectSave>();
            this.Paragraphs = new HashSet<ProjectParagraph>();
            this.Attachments = new HashSet<ProjectAttachment>();
        }

        public string Title { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        // Visiable only for admin
        public int Views { get; set; }

        public virtual ICollection<ProjectParagraph> Paragraphs { get; set; }

        public virtual ICollection<ProjectAttachment> Attachments { get; set; }

        public Testimonial Testimonial { get; set; }

        // If price is 0.00 display ProBono
        public double Price { get; set; }

        public virtual ICollection<ProjectCategory> ProjectCategories { get; set; }

        // ToDo: Create ProjectSkill / Replace with ProjectSkill
        public virtual ICollection<ProjectSkill> ProjectSkills { get; set; }

        public virtual ICollection<ProjectLike> ProjectLikes { get; set; }

        public virtual ICollection<ProjectSave> ProjectSaves { get; set; }
    }
}
