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
    public partial class Form1 : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-P8ARIFA\SQLEXPRESS;Initial Catalog=EventsTest;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            EditForm form2 = new EditForm();
            form2.Show();
        }
    }
}
