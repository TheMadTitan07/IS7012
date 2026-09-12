namespace BankAccounts.Models
{
    public class AccountHolder
    {
        public int AccountHolderId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string SocialSecurityNumber { get; set; }
        public  List<BankAccount>? BankAccounts { get; set; }
    }
}
