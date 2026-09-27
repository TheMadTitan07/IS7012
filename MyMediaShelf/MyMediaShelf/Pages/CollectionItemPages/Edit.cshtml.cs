using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.CollectionItemPages;

[Authorize]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public CollectionItem CollectionItem { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var collectionitem = await _context.CollectionItem
            .Include(ci => ci.Collection)
            .Include(ci => ci.MediaItem)
            .Include(ci => ci.MediaItem.MediaType)
            .Include(ci => ci.MediaItem.MediaFormat)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (collectionitem is null)
        {
            return NotFound();
        }
        CollectionItem = collectionitem;

        int collectionId = CollectionItem.CollectionId;

        ViewData["MediaItemId"] = new SelectList(
            _context.MediaItem
            .Include(mi => mi.MediaType)
            .Where(mi => mi.Id == CollectionItem.MediaItemId || !_context.CollectionItem
                .Any(ci => ci.CollectionId == collectionId 
                    && ci.MediaItemId == mi.Id))
            .Select(mi => new
            {
                mi.Id,
                DisplayText = $"{mi.Title} - {mi.MediaType.Type}"
            }),
            "Id",
            "DisplayText"
            );

        ViewData["CollectionId"] = new SelectList(
            _context.Collection,
            "Id",
            "Name"
            );

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("CollectionItem.MediaItem");
        ModelState.Remove("CollectionItem.Collection");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(CollectionItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CollectionItemExists(CollectionItem.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool CollectionItemExists(int id)
    {
        return _context.CollectionItem.Any(e => e.Id == id);
    }
}
