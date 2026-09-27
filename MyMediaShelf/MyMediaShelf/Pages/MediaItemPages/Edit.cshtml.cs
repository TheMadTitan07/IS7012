using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.MediaItemPages;

[Authorize]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
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

        var mediaitem = await _context.MediaItem.Include(mi => mi.MediaType).Include(mi => mi.MediaFormat).FirstOrDefaultAsync(m => m.Id == id);
        if (mediaitem is null)
        {
            return NotFound();
        }
        MediaItem = mediaitem;

        ViewData["MediaTypeId"] = new SelectList(
            _context.MediaType,
            "Id",
            "Type"
            );

        ViewData["MediaFormatId"] = new SelectList(
            _context.MediaFormat,
            "Id",
            "Format"
            );

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("MediaItem.MediaType");
        ModelState.Remove("MediaItem.MediaFormat");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(MediaItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MediaItemExists(MediaItem.Id))
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

    private bool MediaItemExists(int id)
    {
        return _context.MediaItem.Any(e => e.Id == id);
    }
}
