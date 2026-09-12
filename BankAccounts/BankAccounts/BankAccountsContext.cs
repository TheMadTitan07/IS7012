using Microsoft.EntityFrameworkCore;

public class BankAccountsContext(DbContextOptions<BankAccountsContext> options) : DbContext(options)
{
    public DbSet<BankAccounts.Models.BankAccount> BankAccount { get; set; } = default!;
    public DbSet<BankAccounts.Models.AccountHolder> AccountHolder { get; set; } = default!;

}
