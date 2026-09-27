using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.MediaTypePages;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
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
        else
        {
            MediaType = mediatype;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var mediatype = await _context.MediaType.FindAsync(id);
        if (mediatype != null)
        {
            MediaType = mediatype;
            _context.MediaType.Remove(MediaType);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
