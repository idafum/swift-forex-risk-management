using SQLite;

namespace Risk2.Data.Models;

[Table("user")]
public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    [Unique, MaxLength(10)]
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    //SQLite required a paremeterless constructor
    public User() { }
}