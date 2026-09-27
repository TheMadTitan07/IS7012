using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.CollectionItemPages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<CollectionItem> CollectionItem { get; set; } = default!;

    public async Task OnGetAsync()
    {
        CollectionItem = await _context.CollectionItem
            .Include(ci => ci.Collection)
            .Include(ci => ci.MediaItem)
            .Include(ci => ci.MediaItem.MediaFormat)
            .Include(ci => ci.MediaItem.MediaType).ToListAsync();
    }
}
