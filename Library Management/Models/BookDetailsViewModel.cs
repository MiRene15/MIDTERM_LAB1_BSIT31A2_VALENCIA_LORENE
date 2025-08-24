namespace Library_Management.Models
{
    public class BookDetailsViewModel
    {
        public Guid BookId { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorProfileImageUrl { get; set; }

        public IEnumerable<BookCopyViewModel> Copies { get; set; } = Enumerable.Empty<BookCopyViewModel>();
    }

    public class BookCopyViewModel
    {
        public Guid Id { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Condition { get; set; }
        public string? Source { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? PulloutDate { get; set; }
        public string? PulloutReason { get; set; }
        public bool IsPulledOut => PulloutDate != null;
    }
}
