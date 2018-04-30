using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketShopp
{
    public partial class RemoveCategoryFromDatabase : Form
    {
        public RemoveCategoryFromDatabase()
        {
            InitializeComponent();
        }

        private void removeCategory_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Categories") &&
                File.Exists(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products"))
            {
                string category = getCategoryName.Text;
                List<string> categories = new List<string>();
                List<string> products = new List<string>();
                string[] getProductsFromDatabase = File.ReadAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products");
                string[] getCategoriesFromDatabase = File.ReadAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Categories");

                for (int i = 0; i < getCategoriesFromDatabase.Length; i++)
                {
                    categories.Add(getCategoriesFromDatabase[i]);
                }
                for (int i = 0; i < getProductsFromDatabase.Length; i++)
                {
                    products.Add(getProductsFromDatabase[i]);
                }

                for (int i = 0; i < categories.Count; i++)
                {
                    if (category == categories[i])
                    {
                        for (int a = 0; a < products.Count; a++)
                        {
                            string[] split = products[a].Split();

                            if (split[1] == category)
                            {
                                products.RemoveAt(a);
                            }
                        }
                        categories.RemoveAt(i);
                    }
                }

                File.WriteAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Categories", categories);
                File.WriteAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products", products);
            }
            else
                MessageBox.Show("You don't have database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
