using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatFieldao.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(100)]
        [DisplayName("Middle Name")]
        public string? MiddleName { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Candidate")]
        public string FullName
        {
            get
            {
                if (!string.IsNullOrEmpty(MiddleName))
                {
                    return $"{LastName}, {FirstName} {MiddleName}";
                }
                else
                {
                    return $"{LastName}, {FirstName}";
                }
            }
        }

        [DisplayName("Available?")]
        public bool IsAvailable { get; set; }

        [Range(typeof(decimal),"0", "9999999999.99")]
        [DisplayName("Current Salary")]
        public decimal? CurrentSalary { get; set; } /*candidate can choose not to list current salary*/

        [Range(typeof(decimal), "0", "9999999999.99")]
        [DisplayName("Target Salary")]
        public decimal TargetSalary { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [Phone]
        [Required(ErrorMessage = "Phone number is required")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        public string EmailAddress { get; set; }

        public Company? Company {  get; set; }
        public int? CompanyId { get; set; }
        public JobTitle JobTitle { get; set; }
        public int JobTitleId { get; set; }
        public Industry Industry { get; set; }
        public int IndustryId { get; set; }
    }
}
