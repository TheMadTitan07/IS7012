using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatFieldao.Models;

namespace RecruitCatFieldao.Pages.IndustryPages;

public class IndexModel : PageModel
{
    private readonly RecruitCatFieldaoContext _context;

    public IndexModel(RecruitCatFieldaoContext context)
    {
        _context = context;
    }

    public IList<Industry> Industry { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Industry = await _context.Industry.ToListAsync();
    }
}
