using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.MediaItemPages;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {

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

    [BindProperty]
    public MediaItem MediaItem { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("MediaItem.MediaType");
        ModelState.Remove("MediaItem.MediaFormat");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.MediaItem.Add(MediaItem);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
