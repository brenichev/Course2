using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsTest
{
    public partial class EditForm1 : Form
    {
        public EditForm1()
        {
            InitializeComponent();
            TypeComboLoad(TypeIdBox);
            AgeComboLoad(AgeComboBox);
            FormComboLoad(FormComboBox);
        }
        private string EventId;
        private string EventSql = "SELECT idEvents, EventName, EventTypes.EventType, Ages.Age, EventForms.EventForm, EventLink, EventDesc FROM Events JOIN EventTypes ON Typeid = idType JOIN Ages ON Events.Ageid = Ages.idAge JOIN EventForms ON Events.Formid = EventForms.idForm";

        private void TypeComboLoad(ComboBox comboBox)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"SELECT EventType FROM EventTypes";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int ColIndex = reader.GetOrdinal("EventType");
                            comboBox.Items.Clear();
                            while (reader.Read())
                            {                                
                                string row = reader.GetString(ColIndex);
                                comboBox.Items.Add(row);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

        }

        private void AgeComboLoad(ComboBox comboBox)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"SELECT Age FROM Ages";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int ColIndex = reader.GetOrdinal("Age");
                            comboBox.Items.Clear();
                            while (reader.Read())
                            {                                
                                string row = reader.GetString(ColIndex);
                                comboBox.Items.Add(row);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

        }

        private void FormComboLoad(ComboBox comboBox)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"SELECT EventForm FROM EventForms";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int ColIndex = reader.GetOrdinal("EventForm");
                            comboBox.Items.Clear();
                            while (reader.Read())
                            {                                
                                string row = reader.GetString(ColIndex);
                                comboBox.Items.Add(row);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

        }

        private void Savebutton1_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"INSERT INTO Events VALUES('{EventName.Text}',{TypeIdBox.SelectedIndex + 1},{AgeComboBox.SelectedIndex + 1},{FormComboBox.SelectedIndex + 1},'{EventLink.Text}','{EventDesc.Text}');";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    Savebutton1.BackColor = Color.Green;
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Savebutton1_MouseLeave(object sender, EventArgs e)
        {
            Savebutton1.BackColor = Color.Transparent;
        }

        private void FillTableEvents(DataGridView dataGrid, string sql)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    //SqlDataAdapter SDA = new SqlDataAdapter($@"SELECT idEvents, EventName, EventTypes.EventType, Ages.Age, EventForms.EventForm, EventLink, EventDesc FROM Events JOIN EventTypes ON Typeid = idType JOIN Ages ON Events.Ageid = Ages.idAge JOIN EventForms ON Events.Formid = EventForms.idForm", cnn);
                    SqlDataAdapter SDA = new SqlDataAdapter(sql, cnn);
                    DataTable data = new DataTable();
                    SDA.Fill(data);
                    dataGrid.DataSource = data;
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            FillTableEvents(dataGridView1, EventSql);
            TypeComboLoad(TypeIdBox2);
            AgeComboLoad(AgeComboBox2);
            FormComboLoad(FormComboBox2);
            FillTextBoxes();
        }

        private void DeleteButton1_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string EventId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string sql = $"DELETE FROM Events WHERE idEvents = {EventId}";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    FillTableEvents(dataGridView1, EventSql);
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillTextBoxes();
        }

        private void FillTextBoxes()
        {
            EventName2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            EventId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                string sql = $"SELECT Typeid, Ageid, Formid FROM Events WHERE idEvents = {EventId}";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TypeIdBox2.SelectedIndex = (int)reader.GetValue(0) - 1;
                            AgeComboBox2.SelectedIndex = (int)reader.GetValue(1) - 1;
                            FormComboBox2.SelectedIndex = (int)reader.GetValue(2) - 1;
                        }
                    }
                }
            }
            //TypeIdBox2.SelectedIndex = 1;
            //AgeComboBox2.SelectedIndex = (int)dataGridView1.SelectedRows[0].Cells[3].Value;
            //FormComboBox2.SelectedIndex = (int)dataGridView1.SelectedRows[0].Cells[4].Value;
            EventLink2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            EventDesc2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void SaveButton2_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"UPDATE Events SET EventName = '{EventName2.Text}', Typeid = {TypeIdBox2.SelectedIndex + 1}, Ageid = {AgeComboBox2.SelectedIndex + 1}, Formid = {FormComboBox2.SelectedIndex + 1}, EventLink = '{EventLink2.Text}', EventDesc = '{EventDesc2.Text}' WHERE idEvents = {EventId};";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    FillTableEvents(dataGridView1, EventSql);
                    FillTextBoxes();
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EventComboLoad(ComboBox comboBox)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"SELECT EventName FROM Events";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int ColIndex = reader.GetOrdinal("EventName");
                            comboBox.Items.Clear();
                            while (reader.Read())
                            {
                                string row = reader.GetString(ColIndex);
                                comboBox.Items.Add(row);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        //select distinct [pole1] from [table] where pole1 like '%combobox.text%'
        // Загружать 50 первых значений, остальные по вводимым символам?
        private void ComboLoad(ComboBox comboBox, string table, string col)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"SELECT {col} FROM {table}";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int ColIndex = reader.GetOrdinal(col);
                            comboBox.Items.Clear();
                            while (reader.Read())
                            {
                                string row = reader.GetString(ColIndex);
                                comboBox.Items.Add(row);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        private void SaveButtonStages1_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    // сменить ComboBox.SelectedIndex на поиск значения в бд |||| ValueMember и Display при загрузке "|||Очистка паока не используется -cboxHour.Items.Clear()
                    string sql = $"INSERT INTO Stages VALUES('{StageNumeric1.Value}',{EventsComboBox1.SelectedIndex + 1},'{StageName}',{AdressComboBox1.SelectedIndex + 1},{dateTimeStart1.Value},{dateTimeFinish1.Value},{CostNumeric1.Value},'{StageDesc1.Text}',{ManagerComboBox1.SelectedIndex + 1});";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    SaveButtonStages1.BackColor = Color.Green;
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tabControl1.SelectedIndex)
            {
                case 1:
                    EventComboLoad(EventsComboBox1);
                    ComboLoad(AdressComboBox1, "Adresses", "Adress");
                    ComboLoad(ManagerComboBox1, "Managers", "ManagerFIO");
                    break;
                case 2:
                    
                    break;
            }
        }

        private void DateLoad(DateTimePicker dateTime, string table, string col)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"SELECT {col} FROM {table}";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int ColIndex = reader.GetOrdinal(col);
                            //dateTimePicker1.Value = 0;
                            while (reader.Read())
                            {
                                var row = Convert.ToDateTime(reader.GetValue(ColIndex));
                                dateTime.Value = row;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tabControl3.SelectedIndex)
            {
                case 1:
                    DateLoad(dateTimeStart2, "Stages", "DateStart");
                    DateLoad(dateTimeFinish2, "Stages", "DateFinish");
                    DateLoad(dateTimeFinish2, "Stages", "DateFinish");
                    break;
            }
        }
    }
}
