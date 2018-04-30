using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketShopp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string getUsername = usernameBox.Text;
            string getPassword = passwordBox.Text;
            if (getUsername == "Admin")
            {
                if (getPassword == "admin321")
                {
                    this.Hide();
                    AdminAccount adminForm = new AdminAccount();
                    adminForm.ShowDialog();                  
                }
                else
                    MessageBox.Show("Incorrect password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Enter existing account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
