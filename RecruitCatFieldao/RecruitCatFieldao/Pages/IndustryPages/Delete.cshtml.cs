using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.IndustryPages;

public class DeleteModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;

    public DeleteModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Industry Industry { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var industry = await _context.Industry.FirstOrDefaultAsync(m => m.Id == id);
        if (industry is null)
        {
            return NotFound();
        }
        else
        {
            Industry = industry;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var industry = await _context.Industry.FindAsync(id);
        if (industry != null)
        {
            Industry = industry;
            _context.Industry.Remove(Industry);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
