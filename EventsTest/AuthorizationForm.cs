using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsTest
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewForm f2 = new ViewForm();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditForm1 f3 = new EditForm1();
            f3.Show();
        }
    }
}
