namespace TRKPortfolio.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TRKPortfolio.Data.Common.Models;

    public class CommentBaseModel : BaseDeletableModel<int>
    {
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Comment must be between 2 and 150 symbols!")]
        public string Text { get; set; }

        // Questionable?
        // public virtual ICollection<CommentLike> CommentLikes { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
