using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class CreateCityModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; }

    public string? SubmittedCity { get; set; }

    public void OnGet() { }

    public void OnPost()
    {
        if (!ModelState.IsValid)
            return;

        SubmittedCity = Input.CityName;
    }
    
    public class InputModel
    {
        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        public string CityName { get; set; }
    }
}