using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeFrom
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "om" && txtPassword.Text == "ovi")
            {
                MDI mdi=new MDI();
                mdi.Show();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPassword.Clear();
        }
    }
}
