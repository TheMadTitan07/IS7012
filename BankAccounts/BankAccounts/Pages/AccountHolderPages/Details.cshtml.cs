using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankAccounts.Models;

namespace BankAccounts.Pages.AccountHolderPages;

public class DetailsModel : PageModel
{
    private readonly BankAccountsContext _context;
    public DetailsModel(BankAccountsContext context)
    {
        _context = context;
    }

    public AccountHolder AccountHolder { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var accountholder = await _context.AccountHolder.Include(x => x.BankAccounts).FirstOrDefaultAsync(m => m.Id == id);
        if (accountholder is null)
        {
            return NotFound();
        }
        else
        {
            AccountHolder = accountholder;
        }

        return Page();
    }
}
