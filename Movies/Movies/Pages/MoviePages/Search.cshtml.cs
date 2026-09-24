using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movies.Models;
using Movies.Data;

namespace Movies.Pages.MoviePages;

public class SearchModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public SearchModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Movie> Movie { get; set; } = default!;

    public bool SearchCompleted { get; set; }

    public string Query { get; set; }

    public async Task OnGetAsync(string query)
    {
        Query = query;
        if (!string.IsNullOrWhiteSpace(Query))
        {
            SearchCompleted = true;
            Movie = await _context.Movie
                .Where(x => x.Title.StartsWith(Query))
                .ToListAsync();
        }
        else
        {
            SearchCompleted = false;

            Movie = new List<Movie>();
        }
    }
}
