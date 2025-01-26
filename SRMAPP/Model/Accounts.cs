
using System.Globalization;

namespace SRMAPP.Model;
public class Accounts
{
    private string Name;
    private double AccountSize;
    private double Risk;

    //Dummy constructor
    public Accounts()
    {
        this.Name = "My Account";
        this.AccountSize = 1000;
        this.Risk = 1;
    }
    public Accounts(string Name, double AccountSize, double Risk)
    {
        this.Name = Name;
        this.AccountSize = AccountSize;
        this.Risk = Risk;
    }

}