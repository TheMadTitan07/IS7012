namespace RecruitCatFieldao.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool IsActivelyRecruiting { get; set; }
        public string CurrentlyRecruitingPosition { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyEmail {  get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary {  get; set; }
        public List<Candidate> Candidates { get; set; }
        public Industry Industry { get; set; }
        public int IndustryId { get; set; }
        public JobTitle JobTitle { get; set; }
        public int JobTitleId { get; set; }
    }
}
