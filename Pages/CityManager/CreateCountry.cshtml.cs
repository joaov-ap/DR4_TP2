using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class CreateCountryModel : PageModel
{
    [BindProperty]
    public List<InputModel> Input { get; set; }

    public List<Country> SubmittedCountries { get; set; }

    public void OnGet()
    {
        for (int i = 0; i < 5; i++)
            Input.Add(new InputModel());
    }

    public void OnPost()
    {
        for (int i = 0; i < Input.Count; i++)
        {
            var name = Input[i].CountryName;
            var code = Input[i].CountryCode;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(code))
            {
                if (char.ToUpper(name[0]) != char.ToUpper(code[0]))
                {
                    ModelState.AddModelError(
                        $"Input[{i}].CountryCode",
                        "O código deve começar com a mesma letra que o nome do país."
                    );
                }
            }
        }

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