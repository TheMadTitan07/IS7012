using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.CollectionPages;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Collection Collection { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var collection = await _context.Collection.Include(c => c.CollectionItems).Include(c =>c.ApplicationUser).FirstOrDefaultAsync(m => m.Id == id);
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var collection = await _context.Collection.FindAsync(id);
        if (collection != null)
        {
            Collection = collection;
            _context.Collection.Remove(Collection);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
