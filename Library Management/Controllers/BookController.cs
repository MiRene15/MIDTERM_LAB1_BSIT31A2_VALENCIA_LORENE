using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            var books = BookService.Instance.GetBooks();
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
            {
                return BadRequest(ModelState);
            }

            BookService.Instance.AddBook(vm);
            return Ok();
        }

        public IActionResult EditModal(Guid id)
        {
            var editBookViewModel = BookService.Instance.GetBookById(id);
            if (editBookViewModel == null)
                return NotFound();

            return PartialView("_EditBookPartial", editBookViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditBookViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BookService.Instance.UpdateBook(vm);
            return Ok();
        }

        public IActionResult DeleteModal(Guid id)
        {
            var book = BookService.Instance.GetBookById(id);
            if (book == null)
                return NotFound();

            return PartialView("_DeletePartial", book);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var book = BookService.Instance.GetBookById(id);
            if (book == null)
                return NotFound();

            BookService.Instance.DeleteBook(id);
            return Ok();
        }

        public IActionResult Details(Guid id)
        {
            var book = BookService.Instance.GetBooks().FirstOrDefault(b => b.BookId == id);
            if (book == null)
                return NotFound();

            return View(book);
        }
    }
}
