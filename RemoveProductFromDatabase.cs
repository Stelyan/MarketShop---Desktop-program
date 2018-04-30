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
    public partial class RemoveProductFromDatabase : Form
    {
        public RemoveProductFromDatabase()
        {
            InitializeComponent();
        }

        private void removeProduct_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products"))
            {
                List<string> products = new List<string>();
                string[] getProductsFromDatabase = File.ReadAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products");
                string productName = getProductName.Text;

                for (int i = 0; i < getProductsFromDatabase.Length; i++)
                {
                    products.Add(getProductsFromDatabase[i]);
                }
                for (int i = 0; i < products.Count; i++)
                {
                    string[] split = products[i].Split();
                    if (productName == split[1])
                    {
                        products.RemoveAt(i);
                    }
                }

                File.WriteAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products", products);
            }
            else
                MessageBox.Show("You don't have database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
