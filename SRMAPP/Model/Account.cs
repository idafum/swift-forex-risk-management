
using System.Globalization;

namespace SRMAPP.Model;
public class Account
{
    public string Name { get; set; }
    public double AccountSize { get; set; }
    public double Risk { get; set; }

    //Dummy constructor
    public Account()
    {
        this.Name = "My Account";
        this.AccountSize = 1000;
        this.Risk = 1;
    }
    public Account(string Name, double AccountSize, double Risk)
    {
        this.Name = Name;
        this.AccountSize = AccountSize;
        this.Risk = Risk;
    }

}