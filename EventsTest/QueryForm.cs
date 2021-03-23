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
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
            FillComboFields();
        }

        private void FillComboFields()
        {
            DataTable fields = new DataTable();
            fields.Columns.Add("Value", typeof(string));
            fields.Columns.Add("Display", typeof(string));

            fields.Rows.Add("EventName", "Название мероприятия");
            fields.Rows.Add("EventTypes.EventType", "Тип мероприятия");
            FieldsComboBox.DataSource = fields;
            FieldsComboBox.DisplayMember = "Display";
            FieldsComboBox.ValueMember = "Value";

            OperationComboBox.Items.AddRange(new string[] { "=", "!=", ">", "<" });
            OperationComboBox.SelectedIndex = 0;

            radioButton1.Checked = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string s = "";
            if (listBox1.Items.Count != 0)
                if (radioButton1.Checked)
                    s = radioButton1.Text + " ";
                else
                    s = radioButton2.Text + " ";
            s += FieldsComboBox.SelectedValue + " " + OperationComboBox.SelectedItem + " " + textBox1.Text;
            listBox1.Items.Add(s);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
