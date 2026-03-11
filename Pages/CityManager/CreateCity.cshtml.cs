using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class CreateCityModel : PageModel
{
    [BindProperty]
    public string CityName { get; set; }
    
    public string? SubmittedCity { get; set; }

    public void OnGet() { }

    public void OnPost()
    {
        SubmittedCity = CityName;
    }
}