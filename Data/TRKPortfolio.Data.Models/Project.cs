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
            this.ProjectAttachments = new HashSet<ProjectAttachment>();
            this.ProjectCategories = new HashSet<ProjectCategory>();
            this.Skills = new HashSet<Skill>();
            this.ProjectLikes = new HashSet<ProjectLike>();
            this.ProjectSaves = new HashSet<ProjectSave>();
        }

        public string Title { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public virtual ICollection<ProjectAttachment> ProjectAttachments { get; set; }

        public int TestimonialId { get; set; }

        public Testimonial Testimonial { get; set; }

        public double Price { get; set; }

        public virtual ICollection<ProjectCategory> ProjectCategories { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public virtual ICollection<ProjectLike> ProjectLikes { get; set; }

        public virtual ICollection<ProjectSave> ProjectSaves { get; set; }
    }
}
