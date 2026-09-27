using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.CollectionPages;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Collection Collection { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var collection = await _context.Collection
            .Include(c => c.CollectionItems)
                .ThenInclude(ci => ci.MediaItem)
                   .ThenInclude(ci => ci.MediaType)
            .Include(c => c.CollectionItems)
                .ThenInclude(ci => ci.MediaItem)
                   .ThenInclude(ci => ci.MediaFormat)
            .Include(c => c.ApplicationUser)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (collection is null)
        {
            return NotFound();
        }
        else
        {
            Collection = collection;
        }

        return Page();
    }
}
