using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.MediaTypePages;

[Authorize]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public MediaType MediaType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var mediatype = await _context.MediaType.FirstOrDefaultAsync(m => m.Id == id);
        if (mediatype is null)
        {
            return NotFound();
        }
        MediaType = mediatype;

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("MediaType.MediaItems");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(MediaType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MediaTypeExists(MediaType.Id))
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

    private bool MediaTypeExists(int id)
    {
        return _context.MediaType.Any(e => e.Id == id);
    }
}
