namespace TRKPortfolio.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TRKPortfolio.Data.Common.Models;

    public class CommentBaseModel : BaseDeletableModel<int>
    {
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [StringLength(maximumLength: 250, MinimumLength = 5, ErrorMessage = "Content text must be between 5 and 250 (Including) symbols!")]
        public string Text { get; set; }

        // Questionable?
        // public virtual ICollection<CommentLike> CommentLikes { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
