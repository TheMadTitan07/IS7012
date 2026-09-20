using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.CandidatePages;

public class CreateModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;

    public CreateModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {

        ViewData["CompanyId"] = new SelectList(
            _context.Company,
            "Id",
            "Name"
            );

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
    public Candidate Candidate { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("Candidate.Company");
        ModelState.Remove("Candidate.Industry");
        ModelState.Remove("Candidate.JobTitle");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Candidate.Add(Candidate);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
