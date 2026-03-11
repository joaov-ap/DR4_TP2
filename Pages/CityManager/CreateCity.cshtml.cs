using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class CreateCityModel : PageModel
{
    public string? SubmittedCity { get; set; }

    public void OnGet() { }

    public void OnPost(string cityName)
    {
        SubmittedCity = cityName;
    }
}