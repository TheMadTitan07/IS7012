using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankAccounts.Models;

namespace BankAccounts.Pages.BankAccountPages;

public class DeleteModel : PageModel
{
    private readonly BankAccountsContext _context;

    public DeleteModel(BankAccountsContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? bankaccountid)
    {
        if (bankaccountid is null)
        {
            return NotFound();
        }

        var bankaccount = await _context.BankAccount.FindAsync(bankaccountid);
        if (bankaccount != null)
        {
            BankAccount = bankaccount;
            _context.BankAccount.Remove(BankAccount);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
