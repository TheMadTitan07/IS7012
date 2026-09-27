using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.MediaTypePages;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

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
}
