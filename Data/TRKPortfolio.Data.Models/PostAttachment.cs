namespace TRKPortfolio.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PostAttachment : AttachmentBaseModel
    {
        [Required]
        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
