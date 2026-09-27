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
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public CreateModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult OnGet()
    {

        return Page();
    }

    [BindProperty]
    public Collection Collection { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
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

        _context.Collection.Add(Collection);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
