using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.JobTitlePages;

public class CreateModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;

    public CreateModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public JobTitle JobTitle { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("JobTitle.Candidates");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.JobTitle.Add(JobTitle);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
