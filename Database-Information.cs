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
    public partial class Database_Information : Form
    {
        public Database_Information()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] categories = File.ReadAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Categories");

            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(categories);
            }
            else
                listBox1.Items.AddRange(categories);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] products = File.ReadAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products");

            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(products);
            }
            else
            listBox1.Items.AddRange(products);
        }
    }
}
