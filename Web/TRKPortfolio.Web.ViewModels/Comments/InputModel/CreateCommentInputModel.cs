namespace TRKPortfolio.Web.ViewModels.Comments.InputModel
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCommentInputModel
    {
        public int PostId { get; set; }

        public int CommentId { get; set; }

        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 5, ErrorMessage = "Content text must be between 5 and 250 (Including) symbols!")]
        public string Text { get; set; }
    }
}
