using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.CollectionPages;

[Authorize]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public EditModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [BindProperty]
    public Collection Collection { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var collection = await _context.Collection.FirstOrDefaultAsync(m => m.Id == id);
        if (collection is null)
        {
            return NotFound();
        }
        Collection = collection;

        ViewData["CollectionItemId"] = new SelectList(
            _context.CollectionItem.Select (ci => new
            {
                ci.Id,
                DisplayText = $"{ci.MediaItem.Title} - {ci.MediaItem.MediaType.Type}"
            }),
            "Id",
            $"DisplayText"
            );

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        string currentUserID = _userManager.GetUserId(User);

        Collection.ApplicationUserId = currentUserID;

        ModelState.Remove("Collection.CollectionItems");
        ModelState.Remove("Collection.ApplicationUser");
        ModelState.Remove("Collection.ApplicationUserId");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Collection).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CollectionExists(Collection.Id))
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

    private bool CollectionExists(int id)
    {
        return _context.Collection.Any(e => e.Id == id);
    }
}
