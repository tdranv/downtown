using System.ComponentModel.DataAnnotations;

namespace Downtown.Rest.DataContracts
{
    public class CommentCreateModel
    {
        public int EventId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
