using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.JobTitlePages;

public class DetailsModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;
    public DetailsModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    public JobTitle JobTitle { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var jobtitle = await _context.JobTitle.Include(j => j.Candidates).FirstOrDefaultAsync(m => m.Id == id);
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
}
