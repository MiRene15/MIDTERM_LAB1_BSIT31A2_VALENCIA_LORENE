using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class ArchiveController : Controller
    {
        public IActionResult Index()
        {
            var archivedBooks = BookService.Instance.GetArchivedBooks();
            var archivedAuthors = BookService.Instance.GetArchivedAuthors();
            return View((archivedBooks, archivedAuthors));
        }

        [HttpPost]
        public IActionResult RestoreBook(Guid id)
        {
            BookService.Instance.RestoreBook(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RestoreAuthor(Guid id)
        {
            BookService.Instance.RestoreAuthor(id);
            return RedirectToAction("Index");
        }
    }
}
