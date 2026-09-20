using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankAccounts.Models;

namespace BankAccounts.Pages.AccountHolderPages;

public class IndexModel : PageModel
{
    private readonly BankAccountsContext _context;

    public IndexModel(BankAccountsContext context)
    {
        _context = context;
    }

    public IList<AccountHolder> AccountHolder { get; set; } = default!;

    public async Task OnGetAsync()
    {
        AccountHolder = await _context.AccountHolder.Include(a => a.BankAccounts).ToListAsync();
    }
}
