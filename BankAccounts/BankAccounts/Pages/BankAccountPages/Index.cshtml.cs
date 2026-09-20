using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankAccounts.Models;

namespace BankAccounts.Pages.BankAccountPages;

public class IndexModel : PageModel
{
    private readonly BankAccountsContext _context;

    public IndexModel(BankAccountsContext context)
    {
        _context = context;
    }

    public IList<BankAccount> BankAccount { get; set; } = default!;

    public async Task OnGetAsync()
    {
        BankAccount = await _context.BankAccount.Include(b => b.AccountHolder).ToListAsync();
    }
}
