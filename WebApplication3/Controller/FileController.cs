using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        [Route("File/DownloadFile")]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        [Route("File/DownloadFile")]
        public async Task<IActionResult> DownloadFile(string firstName, string lastName, string fileName)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Створення шляху для збереження файлу
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName + ".txt");

            // Запис імені та прізвища у файл
            var content = $"Ім'я: {firstName}\nПрізвище: {lastName}";
            await System.IO.File.WriteAllTextAsync(filePath, content, Encoding.UTF8);

            // Повернення файлу для завантаження
            return PhysicalFile(filePath, "text/plain", fileName + ".txt");
        }
    }
}
