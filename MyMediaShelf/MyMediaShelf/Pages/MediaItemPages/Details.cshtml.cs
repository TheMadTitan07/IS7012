using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.MediaItemPages;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public MediaItem MediaItem { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var mediaitem = await _context.MediaItem.Include(mi => mi.MediaType).Include(mi => mi.MediaFormat).FirstOrDefaultAsync(m => m.Id == id);
        if (mediaitem is null)
        {
            return NotFound();
        }
        else
        {
            MediaItem = mediaitem;
        }

        return Page();
    }
}
