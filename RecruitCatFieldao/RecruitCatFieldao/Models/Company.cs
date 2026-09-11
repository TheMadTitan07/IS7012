namespace RecruitCatFieldao.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyEmail {  get; set; }
        public List<Industry> Industries { get; set; } /*assuming a company can have 1 or more industries*/
    }
}
