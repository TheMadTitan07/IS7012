namespace RecruitCatFieldao.Models
{
    public class Position
    {
        public int PostionId { get; set; }
        public string PositionTitle { get; set; }
        public string PositionDescription { get; set; }
        public decimal PayRate { get; set; }
        public List<Candidate>? Candidates { get; set; } /*assuming a position has 0 or more candidates*/
        public Company? Company { get; set; } /*assuming a position can belong to only one company*/
        public int? CompanyId { get; set; }

    }
}
