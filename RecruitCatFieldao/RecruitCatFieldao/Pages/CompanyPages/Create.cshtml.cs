using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.CompanyPages;

public class CreateModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;

    public CreateModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["JobTitleId"] = new SelectList(
        _context.JobTitle,
        "Id",
        "Title"
        );

        ViewData["IndustryId"] = new SelectList(
        _context.Industry,
        "Id",
        "Name"
        );

        return Page();
    }

    [BindProperty]
    public Company Company { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("Company.Candidates");
        ModelState.Remove("Company.Industry");
        ModelState.Remove("Company.JobTitle");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Company.Add(Company);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
