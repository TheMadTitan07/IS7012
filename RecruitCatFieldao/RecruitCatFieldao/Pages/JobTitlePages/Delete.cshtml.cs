using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.JobTitlePages;

public class DeleteModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;

    public DeleteModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    [BindProperty]
    public JobTitle JobTitle { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var jobtitle = await _context.JobTitle.FirstOrDefaultAsync(m => m.Id == id);
        if (jobtitle is null)
        {
            return NotFound();
        }
        else
        {
            JobTitle = jobtitle;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var jobtitle = await _context.JobTitle.FindAsync(id);
        if (jobtitle != null)
        {
            JobTitle = jobtitle;
            _context.JobTitle.Remove(JobTitle);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
