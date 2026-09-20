using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.CandidatePages;

public class IndexModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;

    public IndexModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    public IList<Candidate> Candidate { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Candidate = await _context.Candidate.Include(c => c.Company).Include(c => c.Industry).Include(c => c.JobTitle).ToListAsync();
    }
}
