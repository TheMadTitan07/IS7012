using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }

        [DisplayName("Routing Number")]
        public string RoutingNumber { get; set; }

        [DisplayName("Current Balance")]
        public decimal CurrentBalance { get; set; }

        [DisplayName("Account Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Opened")]
        public DateTime OpenedDate { get; set; }

        [DisplayName("Account Holder")]
        public AccountHolder AccountHolder { get; set; }
        public int AccountHolderId { get; set; }
    }
}
