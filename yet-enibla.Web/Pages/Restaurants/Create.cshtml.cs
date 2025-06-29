using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using yet_enibla.Web.Models;

namespace yet_enibla.Web.Pages.Restaurants;

public class Create : PageModel
{
    public void OnGet() { }

    [BindProperty] public Restaurant Restaurant { get; set; } = new();
    
    public async Task<IActionResult> OnPostAsync()
    {
        WriteLine(Restaurant);
        
        if (!ModelState.IsValid)
            return Page();

        return RedirectToPage("/Restaurants/Index");
    }
}
