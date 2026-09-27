using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.MediaFormatPages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<MediaFormat> MediaFormat { get; set; } = default!;

    public async Task OnGetAsync()
    {
        MediaFormat = await _context.MediaFormat.Include(mf => mf.MediaItems).ToListAsync();
    }
}
