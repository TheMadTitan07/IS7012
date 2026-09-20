using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.CompanyPages;

public class EditModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;

    public EditModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Company Company { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var company = await _context.Company.FirstOrDefaultAsync(m => m.Id == id);
        if (company is null)
        {
            return NotFound();
        }
        Company = company;

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

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("Company.Candidates");
        ModelState.Remove("Company.Industry");
        ModelState.Remove("Company.JobTitle");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Company).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CompanyExists(Company.Id))
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

    private bool CompanyExists(int id)
    {
        return _context.Company.Any(e => e.Id == id);
    }
}
