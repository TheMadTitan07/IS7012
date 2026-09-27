using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.CollectionItemPages;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
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

        var collectionitem = await _context.CollectionItem.FirstOrDefaultAsync(m => m.Id == id);
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var collectionitem = await _context.CollectionItem.FindAsync(id);
        if (collectionitem != null)
        {
            CollectionItem = collectionitem;
            _context.CollectionItem.Remove(CollectionItem);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
