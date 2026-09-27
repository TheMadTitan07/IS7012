using MyMediaShelf.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyMediaShelf.Models
{
    public class Collection
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Collection name must be 100 characters or less")]
        public string Name { get; set; }
        [StringLength(300, ErrorMessage = "Collection description should be 300 characters or less")]
        public string? Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date Started")]
        public DateTime DateStarted { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public List<CollectionItem> CollectionItems { get; set; }
    }
}
