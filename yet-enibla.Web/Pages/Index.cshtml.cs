using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using yet_enibla.Web.Data;
using yet_enibla.Web.Models;

namespace yet_enibla.Web.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(AppDbContext dbContext, ILogger<IndexModel> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IList<Restaurant> Restaurants { get; set; } = null!;

    public async Task OnGetAsync()
    {
        Debug.Assert(_dbContext.Restaurants != null, "_dbContext.Restaurants != null, the table exists");;
        Restaurants = await _dbContext.Restaurants.ToListAsync();
        _logger.LogInformation("Retrieved {Count} restaurants.", Restaurants.Count);
    }
}
