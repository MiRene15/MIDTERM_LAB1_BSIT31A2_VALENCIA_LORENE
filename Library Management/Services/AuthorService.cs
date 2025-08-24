using Library_Management.Models;

public class AuthorService
{
    private AuthorService() { }

    private static AuthorService? _instance;
    public static AuthorService Instance => _instance ??= new AuthorService();

    public IEnumerable<AuthorListViewModel> GetAuthors(bool includeArchived = false) => BookService.Instance.GetAuthors(includeArchived);
    public AuthorDetailsViewModel GetAuthorDetails(Guid id) => BookService.Instance.GetAuthorDetails(id);
    public Guid CreateAuthor(AddAuthorViewModel vm) => BookService.Instance.CreateAuthor(vm);
    public void UpdateAuthor(EditAuthorViewModel vm) => BookService.Instance.UpdateAuthor(vm);
    public void DeleteAuthor(Guid id) => BookService.Instance.DeleteAuthor(id);
    public void ArchiveAuthor(Guid id) => BookService.Instance.ArchiveAuthor(id);
    public void RestoreAuthor(Guid id) => BookService.Instance.RestoreAuthor(id);
}
