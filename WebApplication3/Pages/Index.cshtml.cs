using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string firstName, string lastName, string fileName)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Створення шляху для збереження файлу
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName + ".txt");

            // Запис імені та прізвища у файл
            var content = $"Ім'я: {firstName}\nПрізвище: {lastName}";
            System.IO.File.WriteAllText(filePath, content, Encoding.UTF8);

            // Повернення файлу для завантаження
            return PhysicalFile(filePath, "text/plain", fileName + ".txt");
        }
    }
}
