using SQLite;

namespace Risk2.Data.Models;

[Table("user")]
public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    [Unique, MaxLength(10)]
    public required string Username { get; set; }
    public required string Password { get; set; }
}