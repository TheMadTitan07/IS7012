using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.CollectionItemPages;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public CollectionItem CollectionItem { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var collectionitem = await _context.CollectionItem.Include(ci => ci.Collection).Include(ci => ci.MediaItem).FirstOrDefaultAsync(m => m.Id == id);
        if (collectionitem is null)
        {
            return NotFound();
        }
        else
        {
            CollectionItem = collectionitem;
        }

        return Page();
    }
}
