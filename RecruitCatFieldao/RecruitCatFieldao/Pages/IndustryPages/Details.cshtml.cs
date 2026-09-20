using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.IndustryPages;

public class DetailsModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;
    public DetailsModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    public Industry Industry { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var industry = await _context.Industry.Include(i => i.Companies).Include(i => i.Candidates).FirstOrDefaultAsync(m => m.Id == id);
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
}
