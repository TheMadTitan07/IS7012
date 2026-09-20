using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.CompanyPages;

public class IndexModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;

    public IndexModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    public IList<Company> Company { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Company = await _context.Company.Include(c => c.Industry).Include(c => c.JobTitle).Include(c => c.Candidates).ToListAsync();
    }
}
