using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyMediaShelf.Models;
using MyMediaShelf.Data;
using Microsoft.AspNetCore.Authorization;

namespace MyMediaShelf.Pages.MediaTypePages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<MediaType> MediaType { get; set; } = default!;

    public async Task OnGetAsync()
    {
        MediaType = await _context.MediaType.Include(mt => mt.MediaItems).ToListAsync();
    }
}
