using System;
using System.Collections.Generic;

namespace Library_Management.Models.Data;

public partial class TblAuthor
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Biography { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string ProfileImageUrl { get; set; } = null!;

    public bool IsArchived { get; set; }
}
