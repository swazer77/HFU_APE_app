using SQLite;

namespace MLZ2025.Shared.Model;

[Table("Movie")]
public class DbMovie
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }

    public required string Title { get; set; } = null!;

    public required Genre Genre { get; set; }

    public required int Year { get; set; }

    public required int Rating { get; set; }
}

[Table("Genre")]
public class Genre
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public required string Name { get; set; } = null!;
}
