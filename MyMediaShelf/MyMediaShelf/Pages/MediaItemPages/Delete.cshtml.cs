using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.MediaItemPages;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public MediaItem MediaItem { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var mediaitem = await _context.MediaItem.Include(mi => mi.MediaFormat).Include(mi => mi.MediaType).FirstOrDefaultAsync(m => m.Id == id);
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var mediaitem = await _context.MediaItem.FindAsync(id);
        if (mediaitem != null)
        {
            MediaItem = mediaitem;
            _context.MediaItem.Remove(MediaItem);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
