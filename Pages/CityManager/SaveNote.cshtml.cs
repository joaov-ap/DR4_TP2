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
    public List<string> FileNames { get; set; }
    public string? SelectedFileContent { get; set; }
    public string? SelectedFileName { get; set; }

    public void OnGet(string? fileName)
    {
        LoadFileList();

        if (fileName is not null)
        {
            var filePath = Path.Combine(_env.WebRootPath, "files", fileName);
            if (System.IO.File.Exists(filePath))
            {
                SelectedFileName = fileName;
                SelectedFileContent = System.IO.File.ReadAllText(filePath);
            }
        }
    }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            LoadFileList();
            return;
        }

        var timestamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");
        var fileName = $"note-{timestamp}.txt";
        var folder = Path.Combine(_env.WebRootPath, "files");

        Directory.CreateDirectory(folder);

        var filePath = Path.Combine(folder, fileName);
        System.IO.File.WriteAllText(filePath, Input.Content);

        SavedFileName = fileName;
        LoadFileList();
    }

    private void LoadFileList()
    {
        var folder = Path.Combine(_env.WebRootPath, "files");
        if (!Directory.Exists(folder))
            return;

        FileNames = Directory
            .GetFiles(folder, "*.txt")
            .Select(Path.GetFileName)
            .Where(f => f is not null)
            .Cast<string>()
            .ToList();
    }

    public class InputModel
    {
        [Required(ErrorMessage = "O conteúdo não pode ser vazio.")]
        public string Content { get; set; }
    }
}