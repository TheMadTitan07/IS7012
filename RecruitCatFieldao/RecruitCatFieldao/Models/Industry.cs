namespace RecruitCatFieldao.Models
{
    public class Industry
    {
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }
        public string IndustryDescription { get; set; }
        public List<Company> Companies { get; set; } 
        public List<Candidate> Candidates { get; set; }

    }
}
