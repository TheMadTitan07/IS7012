using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.JobTitlePages;

public class IndexModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;

    public IndexModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    public IList<JobTitle> JobTitle { get; set; } = default!;

    public async Task OnGetAsync()
    {
        JobTitle = await _context.JobTitle.ToListAsync();
    }
}
