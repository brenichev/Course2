using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsTest
{
    public partial class EditForm : Form
    {
        //string connectionString = @"Data Source=DESKTOP-P8ARIFA\SQLEXPRESS;Initial Catalog=EventsTest;Integrated Security=True";
        string currentTable = "Events";

        public EditForm()
        {
            InitializeComponent();
            FillTableEvents();
        }

        private void FillTableEvents()
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    SqlDataAdapter SDA = new SqlDataAdapter($"SELECT idEvents, EventName, EventTypes.EventType, Ages.Age, EventForms.EventForm, EventLink, EventDesc FROM Events JOIN EventTypes ON Typeid = idType JOIN Ages ON Events.Ageid = Ages.idAge JOIN EventForms ON Events.Formid = EventForms.idForm", cnn);
                    DataTable data = new DataTable();
                    SDA.Fill(data);
                    dataGridView1.DataSource = data;
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        private void FillTableStages()
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string EventId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    //string EventId = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                    SqlDataAdapter SDA2 = new SqlDataAdapter($"select StageNumber, StageName, Adresses.Adress, DateStart, DateFinish, StageCost, StageDesc, Managers.ManagerFIO from Stages JOIN Adresses on Stages.AdressId = Adresses.idAdress JOIN Managers on Stages.ManagerId = Managers.idManager WHERE EventId = {EventId}", cnn);
                    DataTable data = new DataTable();
                    SDA2.Fill(data);
                    dataGridView2.DataSource = data;
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillTableEvents();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FillTableStages();
        }
    }
}
