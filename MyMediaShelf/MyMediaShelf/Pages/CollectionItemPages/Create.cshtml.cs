using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.CollectionItemPages;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public CreateModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task OnGetAsync()
    {
        string currentUserId = _userManager.GetUserId(User);

        ViewData["MediaItemId"] = new SelectList(
            _context.MediaItem
            .Select(mi => new
            {
                mi.Id,
                DisplayText = $"{mi.Title} - {mi.MediaType.Type}"
            }),
            "Id",
            "DisplayText"
            );

        ViewData["CollectionId"] = new SelectList(
            await _context.Collection.Where(c => c.ApplicationUserId == currentUserId).ToListAsync(),
            "Id",
            "Name"
            );

    }

    [BindProperty]
    public CollectionItem CollectionItem { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("CollectionItem.MediaItem");
        ModelState.Remove("CollectionItem.Collection");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.CollectionItem.Add(CollectionItem);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
