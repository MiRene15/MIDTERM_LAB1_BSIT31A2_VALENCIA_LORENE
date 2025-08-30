using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetBooks();
            return View(books);
        }

        public IActionResult AddModal()
        {
            return PartialView("_AddBookPartial");
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _bookService.AddBook(vm);
            return Ok();
        }

        public IActionResult EditModal(Guid id)
        {
            var editBookViewModel = _bookService.GetBookById(id);
            if (editBookViewModel == null)
                return NotFound();

            return PartialView("_EditBookPartial", editBookViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditBookViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _bookService.UpdateBook(vm);
            return Ok();
        }

        public IActionResult DeleteModal(Guid id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            return PartialView("_DeleteBookPartial", book);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            _bookService.DeleteBook(id);
            return Ok();
        }

        public IActionResult Details(Guid id)
        {
            try
            {
                var vm = _bookService.GetBookDetails(id);
                return View(vm);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddCopy(Guid id)
        {
            try
            {
                _bookService.AddCopy(id);
                return RedirectToAction("Details", new { id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult PullOutCopyModal(Guid copyId, Guid bookId)
        {
            ViewBag.BookId = bookId;
            ViewBag.CopyId = copyId;
            return PartialView("_PullOutCopyPartial");
        }

        [HttpPost]
        public IActionResult PullOutCopy(Guid copyId, Guid bookId, string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                return BadRequest("Reason is required");

            _bookService.PullOutCopy(copyId, reason);
            return RedirectToAction("Details", new { id = bookId });
        }

        [HttpPost]
        public IActionResult Archive(Guid id)
        {
            _bookService.ArchiveBook(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Restore(Guid id)
        {
            _bookService.RestoreBook(id);
            return RedirectToAction("Index");
        }
    }
}