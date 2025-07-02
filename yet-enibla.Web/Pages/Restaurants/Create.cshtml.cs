using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using yet_enibla.Web.Data;
using yet_enibla.Web.Models;

namespace yet_enibla.Web.Pages.Restaurants;

public class Create : PageModel
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<Create> _logger;

    public Create(AppDbContext dbContext, ILogger<Create> logger)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public void OnGet()
    {
    }

    [BindProperty] public Restaurant CreateRestaurantValue { get; set; } = new();

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return Page();

        try
        {
            _logger.LogInformation(CreateRestaurantValue.ToJson());
            Debug.Assert(_dbContext.Restaurants != null, "_dbContext.Restaurants != null, the table exists");

            await _dbContext.Restaurants.AddAsync(CreateRestaurantValue);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("An error occured while creating the restaurant: {Message}", e.Message);

            // TODO: here we will add a toast message on the frontend, for now just return to the page
            return Page();
        }

        return RedirectToPage("/index");
    }
}
