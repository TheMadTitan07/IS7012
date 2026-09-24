using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movies.Models;
using Movies.Data;

namespace Movies.Pages.MoviePages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Movie> Movie { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Movie = await _context.Movie.ToListAsync();
    }
}
