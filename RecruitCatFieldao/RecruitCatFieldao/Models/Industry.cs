using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatFieldao.Models
{
    public class Industry
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Industry is required")]
        [DisplayName("Industry")]
        public string Name { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Description is required")]
        [DisplayName("Description")]
        public string Description { get; set; }
        public List<Company> Companies { get; set; } 
        public List<Candidate> Candidates { get; set; }

    }
}
