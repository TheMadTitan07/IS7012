using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyMediaShelf.Models
{
    public class CollectionItem
    {
        public int Id { get; set; }
        [DisplayName("Collection Item loaned?")]
        public bool IsLoaned { get; set; }
        [DisplayName("Date loaned")]
        [DataType(DataType.Date)]
        public DateTime? LoanedDate { get; set; }
        [DisplayName("Date Added to Collection")]
        [DataType(DataType.Date)]
        public DateTime? DateAdded {  get; set; }
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }
        public int MediaItemId { get; set; }
        public MediaItem MediaItem { get; set; }
    }
}
