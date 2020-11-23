namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.PostCategories = new HashSet<PostCategory>();
            this.Comments = new HashSet<Comment>();
            this.PostLikes = new HashSet<PostLike>();
            this.PostSaves = new HashSet<PostSave>();
            this.PostParagraphs = new HashSet<PostParagraph>();
        }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public int Views { get; set; }

        public virtual ICollection<PostParagraph> PostParagraphs { get; set; }

        public virtual ICollection<PostCategory> PostCategories { get; set; }

        public virtual ICollection<PostSave> PostSaves { get; set; }

        public virtual ICollection<PostLike> PostLikes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
