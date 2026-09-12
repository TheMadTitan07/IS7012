namespace RecruitCatFieldao.Models
{
    public class JobTitle
    {
        public int JobTitleId { get; set; }
        public string Title { get; set; }
        public decimal MinimumSalary { get; set;  }
        public decimal MaximumSalary { get; set; }
        public List<Candidate> Candidates { get; set; }

    }
}
