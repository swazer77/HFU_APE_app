using SQLite;

namespace MLZ2025.Core.Model;

public class Address
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
}
