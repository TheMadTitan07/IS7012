using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Data;
using MyMediaShelf.Models;

namespace MyMediaShelf.Pages.CollectionPages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Collection> Collection { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Collection = await _context.Collection.Include(c => c.ApplicationUser).Include(c => c.CollectionItems).ToListAsync();
    }
}
