using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Category
{
    private string name;
    private List<Products> products;

    public Category(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }
    public List<Products> Products
    {
        get { return this.products; }
        set { this.products = value; }
    }
}

