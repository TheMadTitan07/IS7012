using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankAccounts.Models;

namespace BankAccounts.Pages.BankAccountPages;

public class DetailsModel : PageModel
{
    private readonly BankAccountsContext _context;
    public DetailsModel(BankAccountsContext context)
    {
        _context = context;
    }

    public BankAccount BankAccount { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? bankaccountid)
    {
        if (bankaccountid is null)
        {
            return NotFound();
        }

        var bankaccount = await _context.BankAccount.FirstOrDefaultAsync(m => m.BankAccountId == bankaccountid);
        if (bankaccount is null)
        {
            return NotFound();
        }
        else
        {
            BankAccount = bankaccount;
        }

        return Page();
    }
}
