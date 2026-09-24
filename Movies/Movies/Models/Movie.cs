using System.ComponentModel;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DisplayName("Release Year")]
        public int ReleaseYear { get; set; }

        [DisplayName("Worldwide Box Office")]
        public decimal BoxOfficeReceipts { get; set; }

    }
}
