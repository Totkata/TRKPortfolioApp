namespace TRKPortfolio.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProjectAttachment : AttachmentBaseModel
    {
        [Required]
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
