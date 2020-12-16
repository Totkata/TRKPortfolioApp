namespace TRKPortfolio.Web.ViewModels.Comments.InputModel
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCommentInputModel
    {
        public int PostId { get; set; }

        public int CommentId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Comment must be between 2 and 100 symbols!")]
        public string Text { get; set; }
    }
}
