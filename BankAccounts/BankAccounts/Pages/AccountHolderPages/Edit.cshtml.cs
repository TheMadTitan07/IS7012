using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BankAccounts.Models;

namespace BankAccounts.Pages.AccountHolderPages;

public class EditModel : PageModel
{
    private readonly BankAccountsContext _context;

    public EditModel(BankAccountsContext context)
    {
        _context = context;
    }

    [BindProperty]
    public AccountHolder AccountHolder { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var accountholder = await _context.AccountHolder.FirstOrDefaultAsync(m => m.Id == id);
        if (accountholder is null)
        {
            return NotFound();
        }
        AccountHolder = accountholder;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(AccountHolder).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AccountHolderExists(AccountHolder.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool AccountHolderExists(int id)
    {
        return _context.AccountHolder.Any(e => e.Id == id);
    }
}
