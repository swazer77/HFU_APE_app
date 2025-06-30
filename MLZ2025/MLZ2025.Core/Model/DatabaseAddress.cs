using System.Runtime.InteropServices.JavaScript;
using SQLite;

namespace MLZ2025.Core.Model
{
    [Table("Address")]
    public class DatabaseAddress
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string ZipCode { get; set; } = "";

        public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
