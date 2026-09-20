using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatFieldao.Models
{
    public class JobTitle
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Position is required")]
        [DisplayName("Position")]
        public string Title { get; set; }

        [Range(typeof(decimal), "0", "9999999999.99")]
        [DisplayName("Minimum Salary")]
        public decimal MinimumSalary { get; set;  }

        [Range(typeof(decimal), "0", "9999999999.99")]
        [DisplayName("Maximum Salary")]
        public decimal MaximumSalary { get; set; }
        public List<Candidate> Candidates { get; set; }

    }
}
