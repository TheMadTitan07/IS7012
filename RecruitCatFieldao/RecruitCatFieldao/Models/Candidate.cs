namespace RecruitCatFieldao.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool IsAvailable { get; set; }
        public decimal? CurrentSalary { get; set; } /*candidate can choose not to list current salaray*/
        public decimal TargetSalary { get; set; }
        public DateOnly? StartDate { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Company? Company {  get; set; }
        public int? CompanyId { get; set; }
        public JobTitle JobTitle { get; set; }
        public int JobTitleId { get; set; }
        public Industry Industry { get; set; }
        public int IndustryId { get; set; }
    }
}
