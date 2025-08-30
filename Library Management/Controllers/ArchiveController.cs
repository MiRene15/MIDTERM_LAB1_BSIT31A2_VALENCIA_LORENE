using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class ArchiveController : Controller
    {
        private readonly IBookService _bookService;

        public ArchiveController(IBookService bookService)
        {
            this._bookService = bookService;
        }


        public IActionResult Index()
        {
            var archivedBooks = _bookService.GetArchivedBooks();
            var archivedAuthors = _bookService.GetArchivedAuthors();
            return View((archivedBooks, archivedAuthors));
        }

        [HttpPost]
        public IActionResult RestoreBook(Guid id)
        {
            _bookService.RestoreBook(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RestoreAuthor(Guid id)
        {
            _bookService.RestoreAuthor(id);
            return RedirectToAction("Index");
        }
    }
}
