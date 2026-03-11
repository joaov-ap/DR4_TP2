using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class CreateCountryModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; }

    public Country? SubmittedCountry { get; set; }

    public void OnGet() { }

    public void OnPost()
    {
        if (!ModelState.IsValid)
            return;

        SubmittedCountry = new Country
        {
            CountryName = Input.CountryName,
            CountryCode = Input.CountryCode
        };
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