using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class SaveNoteModel : PageModel
{
    private readonly IWebHostEnvironment _env;

    public SaveNoteModel(IWebHostEnvironment env)
    {
        _env = env;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public string? SavedFileName { get; set; }

    public void OnGet() { }

    public void OnPost()
    {
        if (!ModelState.IsValid)
            return;

        var timestamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");
        var fileName = $"note-{timestamp}.txt";
        var folder = Path.Combine(_env.WebRootPath, "files");

        Directory.CreateDirectory(folder);

        var filePath = Path.Combine(folder, fileName);
        System.IO.File.WriteAllText(filePath, Input.Content);

        SavedFileName = fileName;
    }

    public class InputModel
    {
        [Required(ErrorMessage = "O conteúdo não pode ser vazio.")]
        public string Content { get; set; }
    }
}