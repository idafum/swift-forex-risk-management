using SQLite;
namespace Risk2.Data.Models;

[Table("account")]
public class Account
{


    public int OwnerID { get; set; } = 0;

    [PrimaryKey, AutoIncrement]
    public int AccountID { get; set; } = 0;

    [MaxLength(3)]
    public string TradingCurrency { get; set; } = string.Empty;

    [Unique]
    public string AccountName { get; set; } = string.Empty;

    public double InitialBalance { get; set; } = 0;

    public double Risk { get; set; } = 0.0;

    public int CurrentBalance { get; set; } = 0;

    public double CurrentState { get; set; } = 0.0;

    //SQLite requires a parameterless constructor
    public Account() { }
}