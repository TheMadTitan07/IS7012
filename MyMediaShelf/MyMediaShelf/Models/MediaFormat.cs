using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyMediaShelf.Models
{
    public class MediaFormat
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Format must be 15 characters or less")]
        [DisplayName("Format/Platform")]
        public string Format { get; set; }
        public List<MediaItem>? MediaItems { get; set; }
    }
}
