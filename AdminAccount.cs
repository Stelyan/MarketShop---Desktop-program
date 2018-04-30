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
    public partial class AdminAccount : Form
    {
        List<Category> allCategories = new List<Category>();
        List<Products> allProducts = new List<Products>();

        public AdminAccount()
        {
            InitializeComponent();

            // Check for exixting database
            if (!(File.Exists(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Categories") &&
                File.Exists(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products")))
            {
                File.WriteAllText(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Categories", null);
                File.WriteAllText(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products", null);
            }
        }

        // Add Category block
        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editMenu.DropDown.Hide();
            if (requestPanel.Visible)
            {
                requestPanel.Hide();
                choiseAmountBoxForRequest.Value = 0;
                choiseProductBoxForRequest.Text = null;
            }
            else
                setCategoryPanel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder categName = new StringBuilder();
            string[] categoryName = getCategoryName.Text.Split();
            for (int i = 0; i < categoryName.Length; i++)
            {
                categName.Append(categoryName[i]);
            }
            string finalCategoryName = categName.ToString();

            bool isContains = false;
            if (allCategories.Count > 0)
            {
                foreach (var category in allCategories)
                {
                    if (finalCategoryName == category.Name)
                    {
                        isContains = true;
                        break;
                    }
                }
                if (isContains)
                {
                    MessageBox.Show("You have category with same name!", "Alert", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    Category newCategory = new Category(finalCategoryName);
                    allCategories.Add(newCategory);
                    File.AppendAllText(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Categories", newCategory.Name + "\r\n");
                    selectCategoryBox.Items.Add(newCategory.Name);
                    MessageBox.Show($"Category '{newCategory.Name}' added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    addNewProductToolStripMenuItem1.Enabled = true;
                    removeCategoryToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                Category newCategory = new Category(finalCategoryName);
                allCategories.Add(newCategory);
                File.AppendAllText(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Categories", newCategory.Name + "\r\n");
                selectCategoryBox.Items.Add(newCategory.Name);
                MessageBox.Show($"Category '{newCategory.Name}' added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                addNewProductToolStripMenuItem1.Enabled = true;
                removeCategoryToolStripMenuItem.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setCategoryPanel.Hide();
            getCategoryName.Text = null;
        }
        // End of Category block

        // ------------------------------------

        // Add Product block
        private void addNewProductToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editMenu.DropDown.Hide();
            setProductsPanel.Show();
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder prodName = new StringBuilder();
                string[] productName = getProductName.Text.Split();
                for (int i = 0; i < productName.Length; i++)
                {
                    prodName.Append(productName[i]);
                }
                string finalProductName = prodName.ToString();

                string productCategory = getProductCategory.Text;
                int productAmount = int.Parse(getProductAmount.Text);
                decimal productPrice = decimal.Parse(getProductPrice.Text);
                bool isContains = false;

                if (allProducts.Count > 0)
                {
                    foreach (var product in allProducts)
                    {
                        if (finalProductName == product.Name)
                        {
                            isContains = true;
                            break;
                        }
                    }
                    if (isContains)
                    {
                        MessageBox.Show("You have product with same name!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        foreach (var category in allCategories)
                        {
                            if (productCategory == category.Name)
                            {
                                Products newProduct = new Products(finalProductName, productCategory, productAmount, productPrice);
                                allProducts.Add(newProduct);
                                File.AppendAllText(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products", $"{newProduct.Name} {newProduct.CategoryType} {newProduct.Amount} {newProduct.Price}" + "\r\n");
                                if (category.Products == null)
                                {
                                    category.Products = new List<Products>();
                                    category.Products.Add(newProduct);
                                }
                                else
                                {
                                    category.Products.Add(newProduct);
                                }
                                MessageBox.Show($"Product '{newProduct.Name}' added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                removeProductToolStripMenuItem.Enabled = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    foreach (var category in allCategories)
                    {
                        if (productCategory == category.Name)
                        {
                            Products newProduct = new Products(finalProductName, productCategory, productAmount, productPrice);
                            allProducts.Add(newProduct);
                            File.AppendAllText(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products", $"{newProduct.Name} {newProduct.CategoryType} {newProduct.Amount} {newProduct.Price}" + "\r\n");
                            if (category.Products == null)
                            {
                                category.Products = new List<Products>();
                                category.Products.Add(newProduct);
                            }
                            else
                            {
                                category.Products.Add(newProduct);
                            }
                            MessageBox.Show($"Product '{newProduct.Name}' added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            removeProductToolStripMenuItem.Enabled = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Amount fild and price field must be numbers!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setProductsPanel.Hide();
            getProductName.Text = null;
            getProductCategory.Text = null;
            getProductAmount.Text = null;
            getProductPrice.Text = null;
        }
        // End of Product block

        // ------------------------------------

        // Add products to box
        private void AddProductsToBox()
        {
            string category = selectCategoryBox.Text;
            selectProductBox.Items.Clear();
            foreach (var categ in allCategories)
            {
                if (categ.Name == category && categ.Products != null)
                {
                    foreach (var item in categ.Products)
                    {
                        if (!(selectProductBox.Items.Contains(item.Name)))
                        {
                            selectProductBox.Items.Add(item.Name);
                        }
                    }
                }
            }
        }

        private void selectCategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddProductsToBox();
        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string category = selectCategoryBox.Text;
                string product = selectProductBox.Text;
                string amount = selectAmountBox.Value.ToString();
                foreach (var categ in allCategories)
                {
                    if (categ.Name == category)
                    {
                        foreach (var prod in categ.Products)
                        {
                            if (prod.Name == product)
                            {
                                if (prod.Amount - int.Parse(amount) < 0 || int.Parse(amount) <= 0)
                                {
                                    MessageBox.Show("You don't have enough amount or the selected value is zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                else
                                {
                                    prod.Amount -= int.Parse(amount);

                                    string[] products = File.ReadAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products");

                                    for (int i = 0; i < products.Length; i++)
                                    {
                                        string[] split = products[i].Split();

                                        if (split[0] == product)
                                        {
                                            products[i] = products[i].Replace(split[2], prod.Amount.ToString());
                                        }
                                    }

                                    File.WriteAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products", products);

                                    categoryBox.Items.Add(category);
                                    productBox.Items.Add(product);
                                    amountBox.Items.Add(int.Parse(amount));
                                    priceBox.Items.Add(int.Parse(amount) * prod.Price);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Da si ebe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isAttachedDatabase = false;

            if (isAttachedDatabase)
            {
                MessageBox.Show("You have attached database!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Get categories & products from database
                string[] categories = File.ReadAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Categories");
                string[] products = File.ReadAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products");

                // Add categories from database
                for (int i = 0; i < categories.Length; i++)
                {
                    Category newCategory = new Category(categories[i]);
                    newCategory.Products = new List<Products>();
                    for (int a = 0; a < products.Length; a++)
                    {
                        string[] split = products[a].Split();
                        Products newProduct = new Products(split[0], split[1], int.Parse(split[2]), decimal.Parse(split[3]));
                        if (newProduct.CategoryType == newCategory.Name)
                        {
                            newCategory.Products.Add(newProduct);
                        }
                    }
                    allCategories.Add(newCategory);
                }
                selectCategoryBox.Items.AddRange(categories);

                // Add products from databse
                for (int i = 0; i < products.Length; i++)
                {
                    string[] split = products[i].Split();
                    Products newProduct = new Products(split[0], split[1], int.Parse(split[2]), decimal.Parse(split[3]));
                    allProducts.Add(newProduct);
                }
                addNewProductToolStripMenuItem1.Enabled = true;
                removeCategoryToolStripMenuItem.Enabled = true;
                removeProductToolStripMenuItem.Enabled = true;

                isAttachedDatabase = true;
                MessageBox.Show("Your databse is attached!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void requestButton_Click_1(object sender, EventArgs e)
        {
            if (setCategoryPanel.Visible)
            {
                setCategoryPanel.Hide();
                getCategoryName.Text = null;
                requestPanel.Visible = true;
            }
            else
                requestPanel.Visible = true;

            choiseProductBoxForRequest.Items.Clear();
            if (!(choiseProductBoxForRequest.Items.Contains("")))
            {
                foreach (var product in allProducts)
                {
                    choiseProductBoxForRequest.Items.Add(product.CategoryType + " " + product.Name);
                }
            }
        }

        private void closeRequestPanel_Click(object sender, EventArgs e)
        {
            requestPanel.Hide();
        }

        string[] deliveredProduct;
        int deliveredProductAmount;
        private void sendRequestBtn_Click(object sender, EventArgs e)
        {
            string[] product = choiseProductBoxForRequest.Text.Split();
            int amount = (int)choiseAmountBoxForRequest.Value;

            informationToolStripMenuItem.BackColor = Color.Red;
            deliveryConfirm.Enabled = true;
            deliveredProduct = product;
            deliveredProductAmount = amount;
        }
       
        private void deliveryConfirm_Click(object sender, EventArgs e)
        {
            informationToolStripMenuItem.DropDown.Hide();

            foreach (var category in allCategories)
            {
                if (deliveredProduct[0] == category.Name)
                {
                    foreach (var product in category.Products)
                    {
                        if (deliveredProduct[1] == product.Name)
                        {
                            product.Amount += deliveredProductAmount;

                            string[] databaseProducts = File.ReadAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products");
                            for (int i = 0; i < databaseProducts.Length; i++)
                            {
                                string[] split = databaseProducts[i].Split();
                                if (split[0] == product.Name)
                                {
                                    databaseProducts[i] = databaseProducts[i].Replace(split[2], product.Amount.ToString());
                                    break;
                                }
                            }
                            File.WriteAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products", databaseProducts);
                            deliveryConfirm.Enabled = false;
                            informationToolStripMenuItem.BackColor = Color.Transparent;
                        }
                    }
                }
            }
        }

        private void removeElementFromTable_Click(object sender, EventArgs e)
        {
            if (categoryBox.SelectedItem != null)
            {
                DialogResult question = MessageBox.Show("Do you want to remove selected item and his values?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (question == DialogResult.Yes)
                {
                    int index = categoryBox.SelectedIndex;
                    decimal amount = (decimal)priceBox.Items[index];
                    string categoryName = (string)categoryBox.Items[index];
                    string productName = (string)productBox.Items[index];
                    string[] products = File.ReadAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products");

                    foreach (var categ in allCategories)
                    {
                        if (categoryName == categ.Name)
                        {
                            foreach (var product in categ.Products)
                            {
                                if (productName == product.Name)
                                {
                                    product.Amount += (int)amount;

                                    for (int i = 0; i < products.Length; i++)
                                    {
                                        string[] split = products[i].Split();

                                        if (split[0] == productName)
                                        {
                                            products[i] = products[i].Replace(split[2], product.Amount.ToString());
                                        }
                                    }
                                    File.WriteAllLines(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products", products);
                                }
                            }
                        }
                    }

                    categoryBox.Items.RemoveAt(index);
                    productBox.Items.RemoveAt(index);
                    amountBox.Items.RemoveAt(index);
                    priceBox.Items.RemoveAt(index);
                }
            }
            else
            {
                MessageBox.Show("You must select any item from Category, to remove all him values!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void removeFromProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setCategoryPanel.Visible)
            {
                setCategoryPanel.Hide();
                getCategoryName.Text = null;
                removeCategoryPanel.Show();
            }
            else if (requestPanel.Visible)
            {
                requestPanel.Hide();
                choiseAmountBoxForRequest.Value = 0;
                choiseProductBoxForRequest.Text = null;
                removeCategoryPanel.Show();
            }
            else if (removeProductPanel.Visible)
            {
                removeProductPanel.Hide();
                getProductNameForRemove.Text = null;
                removeCategoryPanel.Show();
            }
            else
                removeCategoryPanel.Show();
        }

        private void removeCategoryButton_Click(object sender, EventArgs e)
        {
            string category = getCategoryNameForRemove.Text;
            if (allCategories.Count > 0)
            {
                for (int i = 0; i < allCategories.Count; i++)
                {
                    if (category == allCategories[i].Name)
                    {
                        foreach (var product in allCategories[i].Products)
                        {
                            for (int a = 0; a < allProducts.Count; a++)
                            {
                                if (product.Name == allProducts[a].Name)
                                {
                                    allProducts.RemoveAt(a);
                                    break;
                                }
                            }
                        }
                        allCategories.RemoveAt(i);
                    }
                }
                MessageBox.Show("Category removed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("You don't have categories in the program!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void closeRemoveCategoryPanel_Click(object sender, EventArgs e)
        {
            removeCategoryPanel.Hide();
        }

        private void removeFromProgramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (setCategoryPanel.Visible)
            {
                setCategoryPanel.Hide();
                getCategoryName.Text = null;
                removeProductPanel.Show();
            }
            else if (requestPanel.Visible)
            {
                requestPanel.Hide();
                choiseAmountBoxForRequest.Value = 0;
                choiseProductBoxForRequest.Text = null;
                removeProductPanel.Show();
            }
            else if (removeCategoryPanel.Visible)
            {
                removeCategoryPanel.Hide();
                getCategoryNameForRemove.Text = null;
                removeProductPanel.Show();
            }
            else
                removeProductPanel.Show();
        }

        private void removeProductButton_Click(object sender, EventArgs e)
        {
            string product = getProductNameForRemove.Text;
            string productCategory = getProductCategoryForRemove.Text;

            if (allProducts.Count > 0)
            {
                for (int i = 0; i < allProducts.Count; i++)
                {
                    if (product == allProducts[i].Name)
                    {
                        allProducts.RemoveAt(i);
                    }
                }

                for (int i = 0; i < allCategories.Count; i++)
                {
                    if (productCategory == allCategories[i].Name)
                    {
                        for (int a = 0; a < allCategories[i].Products.Count; a++)
                        {
                            if (product == allCategories[i].Products[a].Name)
                            {
                                allCategories[i].Products.RemoveAt(a);
                            }
                        }
                    }
                }

                MessageBox.Show("Product removed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("You don't have products in the program!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void removeFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCategoryFromDatabase removeCategoryFromDatabase = new RemoveCategoryFromDatabase();
            removeCategoryFromDatabase.ShowDialog();
        }

        private void removeFromDatabaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RemoveProductFromDatabase removeProductFromDatabase = new RemoveProductFromDatabase();
            removeProductFromDatabase.ShowDialog();
        }

        private void removeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult question = MessageBox.Show("Do yo want to remove all database?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (question == DialogResult.Yes)
            {
                File.Delete(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Products");
                File.Delete(@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Categories");

                selectCategoryBox.Items.Clear();
            }
        }

        private void databaseInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database_Information databaseInfo = new Database_Information();
            databaseInfo.ShowDialog();
        }

        int count = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            if (categoryBox.Items.Count < 1)
            {
                MessageBox.Show("You dont't have items in the boxes!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {          
                File.WriteAllText($@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Kasof-bon-{count}", "Market shop" + "\r\n");
                for (int a = 0; a < productBox.Items.Count; a++)
                {
                    File.AppendAllText($@"C:\Users\Stelqn\Desktop\Projects and images\MarketShopp\MarketShopp\bin\Debug\Kasof-bon-{count}", $"Product: {productBox.Items[a]} | Amount: {amountBox.Items[a]} | Price: {priceBox.Items[a]}" + "\r\n");
                }
                categoryBox.Items.Clear();
                productBox.Items.Clear();
                amountBox.Items.Clear();
                priceBox.Items.Clear();
                count++;
            }
        }
    }
}
