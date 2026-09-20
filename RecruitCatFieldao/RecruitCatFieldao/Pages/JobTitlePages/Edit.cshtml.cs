using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.JobTitlePages;

public class EditModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;

    public EditModel(RecruitCatFieldaoContext context)
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
        JobTitle = jobtitle;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("JobTitle.Candidates");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(JobTitle).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!JobTitleExists(JobTitle.Id))
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

    private bool JobTitleExists(int id)
    {
        return _context.JobTitle.Any(e => e.Id == id);
    }
}
