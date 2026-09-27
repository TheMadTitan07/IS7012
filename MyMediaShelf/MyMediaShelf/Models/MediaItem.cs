using System.ComponentModel.DataAnnotations;

namespace MyMediaShelf.Models
{
    public class MediaItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Title must be 150 characters or less")]
        public string Title { get; set; }
        public int MediaTypeID { get; set; }
        public MediaType MediaType { get; set;  }
        public int MediaFormatId { get; set; }
        public MediaFormat MediaFormat { get; set; }

    }
}
