namespace Library_Management.Models
{
    public class AuthorListViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ProfileImageUrl { get; set; }
        public bool IsArchived { get; set; }
        public int BooksCount { get; set; }
    }

    public class AddAuthorViewModel
    {
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ProfileImageUrl { get; set; }
    }

    public class EditAuthorViewModel : AddAuthorViewModel
    {
        public Guid Id { get; set; }
    }

    public class AuthorDetailsViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ProfileImageUrl { get; set; }
        public IEnumerable<BookListViewModel> Books { get; set; } = Enumerable.Empty<BookListViewModel>();
    }
}
