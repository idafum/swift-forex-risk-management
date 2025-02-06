using SQLite;

namespace Risk2.Data.Models;

[Table("user")]
public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Unique, MaxLength(10)]
    public string Username { get; set; }
    public string Password { get; set; }
}