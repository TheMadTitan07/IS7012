using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.MediaItemPages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<MediaItem> MediaItem { get; set; } = default!;

    public async Task OnGetAsync()
    {
        MediaItem = await _context.MediaItem.Include(mi => mi.MediaFormat).Include(mi => mi.MediaType).ToListAsync();
    }
}
