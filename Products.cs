using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Products
{
    private string name;
    private string categoryType;
    private int amount;
    private decimal price;

    public Products(string name, string categoryType, int amount, decimal price)
    {
        this.CategoryType = categoryType;
        this.Name = name;
        this.Amount = amount;
        this.Price = price;
    }

    public string CategoryType
    {
        get { return this.categoryType; }
        set { this.categoryType = value;}
    }
    public int Amount
    {
        get { return this.amount; }
        set { this.amount = value; }
    }
    public decimal Price
    {
        get { return this.price; }
        set { this.price = value; }
    }
    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }
}

