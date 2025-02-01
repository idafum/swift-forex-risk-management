
using System.Globalization;

namespace SRMAPP.Model;
public class Account
{
    public string Name { get; set; }
    public double AccountSize { get; set; }
    public double Risk { get; set; }

    public Account()
    {
        Name = "FTM01";
    }
    public Account(string Name, double AccountSize, double Risk)
    {
        this.Name = Name;
        this.AccountSize = AccountSize;
        this.Risk = Risk;
    }

}