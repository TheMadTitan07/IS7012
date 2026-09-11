namespace RecruitCatFieldao.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public List<Position>? Positions { get; set; } /*assumption is a candidate can be eligible for 0 or more positions*/
    }
}
