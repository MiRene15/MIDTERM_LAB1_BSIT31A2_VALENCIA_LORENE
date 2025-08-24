using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class AuthorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var authors = AuthorService.Instance.GetAuthors();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var vm = AuthorService.Instance.GetAuthorDetails(id);
            return View(vm);
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("_AddAuthorPartial");
        }

        [HttpPost]
        public IActionResult Add(AddAuthorViewModel vm)
        {
            var id = AuthorService.Instance.CreateAuthor(vm);
            return Ok(new { id });
        }

        [HttpGet]
        public IActionResult EditModal(Guid id)
        {
            var author = AuthorService.Instance.GetAuthors(true).FirstOrDefault(a => a.Id == id);
            if (author == null) return NotFound();
            var details = AuthorService.Instance.GetAuthorDetails(id);
            var vm = new EditAuthorViewModel
            {
                Id = details.Id,
                Name = details.Name,
                Biography = details.Biography,
                BirthDate = details.BirthDate,
                ProfileImageUrl = details.ProfileImageUrl
            };
            return PartialView("_EditAuthorPartial", vm);
        }

        [HttpPost]
        public IActionResult Edit(EditAuthorViewModel vm)
        {
            AuthorService.Instance.UpdateAuthor(vm);
            return Ok();
        }

        [HttpGet]
        public IActionResult DeleteModal(Guid id)
        {
            var author = AuthorService.Instance.GetAuthors(true).FirstOrDefault(a => a.Id == id);
            if (author == null) return NotFound();
            return PartialView("_DeleteAuthorPartial", author);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            AuthorService.Instance.DeleteAuthor(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Archive(Guid id)
        {
            AuthorService.Instance.ArchiveAuthor(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Restore(Guid id)
        {
            AuthorService.Instance.RestoreAuthor(id);
            return RedirectToAction("Index");
        }
    }
}
