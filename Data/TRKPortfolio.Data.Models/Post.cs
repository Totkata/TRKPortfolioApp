namespace TRKPortfolio.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TRKPortfolio.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.PostLikes = new HashSet<PostLike>();
            this.PostSaves = new HashSet<PostSave>();
            this.Paragraphs = new HashSet<PostParagraph>();
            this.Attachments = new HashSet<PostAttachment>();
            this.PostCategories = new HashSet<PostCategory>();
        }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 60 (including) symbols!")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(500, MinimumLength = 25, ErrorMessage = "Description must be between 25 and 500 (including) symbols!")]
        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public int Views { get; set; }

        public virtual ICollection<PostAttachment> Attachments { get; set; }

        public virtual ICollection<PostParagraph> Paragraphs { get; set; }

        public virtual ICollection<PostCategory> PostCategories { get; set; }

        public virtual ICollection<PostSave> PostSaves { get; set; }

        public virtual ICollection<PostLike> PostLikes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
