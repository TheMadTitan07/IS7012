using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class AccountHolder
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string? MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Account Holder")]
        public String FullName
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

        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateOnly DateOfBirth { get; set; }

        [DisplayName("SSN")]
        public string SocialSecurityNumber { get; set; }
        public  List<BankAccount>? BankAccounts { get; set; }
    }
}
