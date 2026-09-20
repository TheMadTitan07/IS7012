using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.CompanyPages;

public class DetailsModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;
    public DetailsModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    public Company Company { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var company = await _context.Company.Include(c => c.Candidates).Include(c => c.Industry).Include(c => c.JobTitle).FirstOrDefaultAsync(m => m.Id == id);
        if (company is null)
        {
            return NotFound();
        }
        else
        {
            Company = company;
        }

        return Page();
    }
}
