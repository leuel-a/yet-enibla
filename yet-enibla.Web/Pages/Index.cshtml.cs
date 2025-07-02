using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using yet_enibla.Web.Data;
using yet_enibla.Web.Models;

namespace yet_enibla.Web.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<IndexModel> _logger;

    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;
    public int Limit { get; set; } = 8;
    public int Total { get; set; }


    public IndexModel(AppDbContext dbContext, ILogger<IndexModel> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IList<Restaurant> Restaurants { get; set; } = null!;

    public async Task OnGetAsync()
    {
        try
        {
            Debug.Assert(_dbContext.Restaurants != null, "_dbContext.Restaurants != null, the table exists"); ;

            var query = _dbContext.Restaurants.AsNoTracking();
            Total = await query.CountAsync();

            Restaurants = await _dbContext.Restaurants.Skip((CurrentPage - 1) * Limit).Take(Limit).ToListAsync();
            _logger.LogInformation("Retrieved {Count} restaurants.", Restaurants.Count);
        }
        catch (Exception e)
        {
            _logger.LogError("Unexpected error retrieving restaurants: {Message}", e.Message);
            Restaurants = new List<Restaurant>();
        }
    }
}
