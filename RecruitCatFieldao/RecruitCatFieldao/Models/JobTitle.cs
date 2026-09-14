namespace RecruitCatFieldao.Models
{
    public class JobTitle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal MinimumSalary { get; set;  }
        public decimal MaximumSalary { get; set; }
        public List<Candidate> Candidates { get; set; }

    }
}
