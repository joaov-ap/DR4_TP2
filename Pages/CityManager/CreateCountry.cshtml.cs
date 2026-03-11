using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class CreateCountryModel : PageModel
{
    [BindProperty]
    public List<InputModel> Input { get; set; } = new();

    public List<Country> SubmittedCountries { get; set; } = new();

    public void OnGet()
    {
        for (int i = 0; i < 5; i++)
            Input.Add(new InputModel());
    }

    public void OnPost()
    {
        if (!ModelState.IsValid)
            return;

        SubmittedCountries = Input.Select(i => new Country
        {
            CountryName = i.CountryName,
            CountryCode = i.CountryCode
        }).ToList();
    }

    public class InputModel
    {
        [Required(ErrorMessage = "O nome do país é obrigatório.")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "O código do país é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O código deve ter exatamente 2 caracteres.")]
        public string CountryCode { get; set; }
    }
}