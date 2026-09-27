using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.MediaFormatPages;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public MediaFormat MediaFormat { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var mediaformat = await _context.MediaFormat.FirstOrDefaultAsync(m => m.Id == id);
        if (mediaformat is null)
        {
            return NotFound();
        }
        else
        {
            MediaFormat = mediaformat;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var mediaformat = await _context.MediaFormat.FindAsync(id);
        if (mediaformat != null)
        {
            MediaFormat = mediaformat;
            _context.MediaFormat.Remove(MediaFormat);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
