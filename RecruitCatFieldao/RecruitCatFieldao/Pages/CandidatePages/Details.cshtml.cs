using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.CandidatePages;

public class DetailsModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;
    public DetailsModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    public Candidate Candidate { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var candidate = await _context.Candidate.FirstOrDefaultAsync(m => m.Id == id);
        if (candidate is null)
        {
            return NotFound();
        }
        else
        {
            Candidate = candidate;
        }

        return Page();
    }
}
