using Library_Management.Models;

public interface IBookService
{
    void AddBook(AddBookViewModel book);
    void AddCopy(Guid bookId);
    void ArchiveAuthor(Guid id);
    void ArchiveBook(Guid id);
    Guid CreateAuthor(AddAuthorViewModel vm);
    void DeleteAuthor(Guid id);
    void DeleteBook(Guid id);
    IEnumerable<AuthorListViewModel> GetArchivedAuthors();
    IEnumerable<BookListViewModel> GetArchivedBooks();
    AuthorDetailsViewModel GetAuthorDetails(Guid id);
    IEnumerable<AuthorListViewModel> GetAuthors(bool includeArchived = false);
    EditBookViewModel GetBookById(Guid id);
    BookDetailsViewModel GetBookDetails(Guid id);
    IEnumerable<BookListViewModel> GetBooks(bool includeArchived = false);
    IEnumerable<BookCopyViewModel> GetCopies(Guid bookId);
    void PullOutCopy(Guid copyId, string reason);
    void RestoreAuthor(Guid id);
    void RestoreBook(Guid id);
    void UpdateAuthor(EditAuthorViewModel vm);
}

public class BookDBService : IBookService
{
    public void AddBook(AddBookViewModel book)
    {
        throw new NotImplementedException();
    }

    public void AddCopy(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public void ArchiveAuthor(Guid id)
    {
        throw new NotImplementedException();
    }

    public void ArchiveBook(Guid id)
    {
        throw new NotImplementedException();
    }

    public Guid CreateAuthor(AddAuthorViewModel vm)
    {
        throw new NotImplementedException();
    }

    public void DeleteAuthor(Guid id)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<AuthorListViewModel> GetArchivedAuthors()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BookListViewModel> GetArchivedBooks()
    {
        throw new NotImplementedException();
    }

    public AuthorDetailsViewModel GetAuthorDetails(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<AuthorListViewModel> GetAuthors(bool includeArchived = false)
    {
        throw new NotImplementedException();
    }

    public EditBookViewModel GetBookById(Guid id)
    {
        throw new NotImplementedException();
    }

    public BookDetailsViewModel GetBookDetails(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BookListViewModel> GetBooks(bool includeArchived = false)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BookCopyViewModel> GetCopies(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public void PullOutCopy(Guid copyId, string reason)
    {
        throw new NotImplementedException();
    }

    public void RestoreAuthor(Guid id)
    {
        throw new NotImplementedException();
    }

    public void RestoreBook(Guid id)
    {
        throw new NotImplementedException();
    }

    public void UpdateAuthor(EditAuthorViewModel vm)
    {
        throw new NotImplementedException();
    }
}
