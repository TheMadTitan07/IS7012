using System.ComponentModel.DataAnnotations;

namespace MyMediaShelf.Models
{
    public class MediaType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Type must be 15 characters or less")]
        public string Type { get; set; }
        public List<MediaItem>? MediaItems { get; set; }
    }
}
