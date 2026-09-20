using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatFieldao.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Company is required")]
        [DisplayName("Company")]
        public string Name { get; set; }

        [DisplayName("Actively Recruiting?")]
        public bool IsActivelyRecruiting { get; set; }

        [Required(ErrorMessage = "Position recruiting for is required")]
        [DisplayName("Recruiting For")]
        public string CurrentlyRecruitingPosition { get; set; }

        [Phone]
        [Required(ErrorMessage = "Phone number is required")]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        public string Email {  get; set; }

        [Range(typeof(decimal),"0", "9999999999.99")]
        [DisplayName("Minimum Salary")]
        public decimal MinimumSalary { get; set; }

        [Range(typeof(decimal), "0", "9999999999.99")]
        [DisplayName("Maximum Salary")]
        public decimal MaximumSalary {  get; set; }
        public List<Candidate> Candidates { get; set; }
        public Industry Industry { get; set; }
        public int IndustryId { get; set; }
        public JobTitle JobTitle { get; set; }
        public int JobTitleId { get; set; }
    }
}
