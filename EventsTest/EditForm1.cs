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
            ComboLoad(TypeIdBox, "EventTypes", "idType", "EventType");
            ComboLoad(AgeComboBox, "Ages", "idAge", "Age");
            ComboLoad(FormComboBox, "EventForms", "idForm", "EventForm");
        }
        private string EventId;
        private string StageId;
        private string ManagerId;
        private string MemberId;
        private string ListId;
        private string EventSql = "SELECT idEvents, EventName, EventTypes.EventType, Ages.Age, EventForms.EventForm, EventLink, EventDesc FROM Events JOIN EventTypes ON Typeid = idType JOIN Ages ON Events.Ageid = Ages.idAge JOIN EventForms ON Events.Formid = EventForms.idForm";
        private string StagesSql = "SELECT idStage, StageNumber, Events.EventName, StageName, Adresses.Adress, DateStart, DateFinish, StageCost, StageDesc, Managers.ManagerFIO FROM Stages JOIN Events ON EventId = idEvents JOIN Adresses ON AdressId = idAdress JOIN Managers ON ManagerId = idManager";
        private string ManagersSql = "SELECT idManager, ManagerFIO, ManagerAlias, ManagerTypes.ManagerType, ManagerLink, ManagerDesc FROM Managers JOIN ManagerTypes ON ManagerTypeId = idManagerType";
        private string MembersSql = "SELECT idMember, MemberFIO, MemberAlias, MemberTypes.MemberType, MemberLink, MemberDesc FROM Members JOIN MemberTypes ON MemberTypeId = idMemberType";
        private string ListSql = "SELECT idPart, Stages.StageName, Members.MemberFIO FROM ParticipationList JOIN Stages ON StageId = idStage JOIN Members ON MemberId = idMember";

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

        private void FillTable(DataGridView dataGrid, string sql)
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

        /*private void FillTableStages(DataGridView dataGrid, string sql)
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
        }*/

        private void EventsControl_Click(object sender, EventArgs e)
        {
            FillTable(dataGridView1, EventSql);
            ComboLoad(TypeIdBox2, "EventTypes", "idType", "EventType");
            ComboLoad(AgeComboBox2, "Ages", "idAge", "Age");
            ComboLoad(FormComboBox2, "EventForms", "idForm", "EventForm");
            FillTextBoxesEvents();
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
                    FillTable(dataGridView1, EventSql);
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillTextBoxesEvents();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillTextBoxesStages();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillTextBoxesManagers();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillTextBoxesMembers();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillTextBoxesList();
        }


        private void FillTextBoxesEvents()
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

        private void FillTextBoxesStages()
        {
            StageId = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            StageNumeric2.Value = (int)dataGridView2.SelectedRows[0].Cells[1].Value;
            EventsComboBox2.SelectedIndex = EventsComboBox2.FindString(dataGridView2.SelectedRows[0].Cells[2].Value.ToString());
            StageName2.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            AdressComboBox2.SelectedValue = AdressComboBox2.FindString(dataGridView2.SelectedRows[0].Cells[4].Value.ToString()) + 1;
            dateTimeStart2.Value = Convert.ToDateTime(dataGridView2.SelectedRows[0].Cells[5].Value);
            dateTimeFinish2.Value = Convert.ToDateTime(dataGridView2.SelectedRows[0].Cells[6].Value);
            CostNumeric2.Value = int.Parse(dataGridView2.SelectedRows[0].Cells[7].Value.ToString());
            StageDesc2.Text = dataGridView2.SelectedRows[0].Cells[8].Value.ToString();
            ManagerComboBox2.SelectedValue = ManagerComboBox2.FindString(dataGridView2.SelectedRows[0].Cells[9].Value.ToString()) + 1;
        }

        private void FillTextBoxesManagers()
        {
            ManagerId = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            ManagerFIO1.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            ManagerAlias1.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
            ManagerTypeCombo1.SelectedIndex = ManagerTypeCombo1.FindString(dataGridView3.SelectedRows[0].Cells[3].Value.ToString());
            ManagerLink1.Text = dataGridView3.SelectedRows[0].Cells[4].Value.ToString();
            ManagerDesc1.Text = dataGridView3.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void FillTextBoxesMembers()
        {
            MemberId = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
            MemberFIO1.Text = dataGridView4.SelectedRows[0].Cells[1].Value.ToString();
            MemberAlias1.Text = dataGridView4.SelectedRows[0].Cells[2].Value.ToString();
            MemberTypeCombo1.SelectedIndex = ManagerTypeCombo1.FindString(dataGridView3.SelectedRows[0].Cells[3].Value.ToString());
            MemberLink1.Text = dataGridView4.SelectedRows[0].Cells[4].Value.ToString();
            MemberDesc1.Text = dataGridView4.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void FillTextBoxesList()
        {
            ListId = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
            EventListCombo1.SelectedIndex = EventListCombo1.FindString(dataGridView5.SelectedRows[0].Cells[1].Value.ToString());
            MemberListCombo1.SelectedIndex = MemberListCombo1.FindString(dataGridView5.SelectedRows[0].Cells[2].Value.ToString());
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
                    FillTable(dataGridView1, EventSql);
                    FillTextBoxesEvents();
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //select distinct [pole1] from [table] where pole1 like '%combobox.text%'
        // Загружать 50 первых значений, остальные по вводимым символам?
        private void ComboLoad(ComboBox comboBox, string table, string id, string col)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"SELECT {id}, {col} FROM {table}";
                    SqlDataAdapter SDA = new SqlDataAdapter(sql, cnn);
                    DataTable data = new DataTable();
                    SDA.Fill(data);
                    comboBox.DisplayMember = col;
                    comboBox.ValueMember = id;
                    comboBox.DataSource = data;
                    /*SqlCommand cmd = new SqlCommand(sql, cnn);
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
                    }*/
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
            if (DateTime.Compare(dateTimeStart1.Value, dateTimeFinish1.Value) <= 0)
                using (var cnn = new SqlConnection())
                {
                    cnn.ConnectionString = Form1.connectionString;
                    cnn.Open();
                    try
                    {
                        // сменить ComboBox.SelectedIndex на поиск значения в бд |||| ValueMember и Display при загрузке "|||Очистка паока не используется -cboxHour.Items.Clear()
                        string sql = $"INSERT INTO Stages VALUES('{StageNumeric1.Value}',{EventsComboBox1.SelectedIndex + 1},'{StageName1.Text}',{AdressComboBox1.SelectedValue},'{dateTimeStart1.Value}','{dateTimeFinish1.Value}',{CostNumeric1.Value},'{StageDesc1.Text}',{ManagerComboBox1.SelectedValue});";
                        SqlCommand cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        SaveButtonStages1.BackColor = Color.Green;
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось сохранить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            else
                MessageBox.Show("Дата начала наступает позже, чем дата конца мероприятия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (MainTables.SelectedIndex)
            {
                case 1:
                    ComboLoad(EventsComboBox1, "Events", "idEvents", "EventName");
                    ComboLoad(AdressComboBox1, "Adresses", "idAdress", "Adress");
                    ComboLoad(ManagerComboBox1, "Managers", "idMAnager", "ManagerFIO");
                    FillTable(dataGridView2, StagesSql);
                    break;
                case 2:

                    break;
            }
        }

        private void StagesControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (MainTables.SelectedIndex)
            {
                case 1:
                    ComboLoad(EventsComboBox1, "Events", "idEvents", "EventName");
                    ComboLoad(AdressComboBox1, "Adresses", "idAdress", "Adress");
                    ComboLoad(ManagerComboBox1, "Managers", "idMAnager", "ManagerFIO");
                    FillTable(dataGridView2, StagesSql);
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
            switch (StagesControl.SelectedIndex)
            {
                case 1:
                    DateLoad(dateTimeStart2, "Stages", "DateStart");
                    DateLoad(dateTimeFinish2, "Stages", "DateFinish");
                    //DateLoad(dateTimeFinish2, "Stages", "DateFinish");
                    break;
            }
        }

        private void SaveButtonStages2_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(dateTimeStart2.Value, dateTimeFinish2.Value) <= 0)
                using (var cnn = new SqlConnection())
                {
                    cnn.ConnectionString = Form1.connectionString;
                    cnn.Open();
                    try
                    {
                        string sql = $"UPDATE Stages SET StageNumber = '{StageNumeric2.Value}', EventId = {EventsComboBox2.SelectedValue}, StageName = '{StageName2.Text}', AdressId = {AdressComboBox2.SelectedValue}, DateStart = '{dateTimeStart2.Value}', DateFinish = '{dateTimeFinish2.Value}', StageCost = {CostNumeric2.Value}, StageDesc = '{StageDesc2.Text}', ManagerId = {ManagerComboBox2.SelectedValue} WHERE idStage = {StageId};";
                        SqlCommand cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        FillTable(dataGridView2, StagesSql);
                        FillTextBoxesStages();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            else
                MessageBox.Show("Дата начала наступает позже, чем дата конца мероприятия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DeleteButtonStages_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    StageId = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    string sql = $"DELETE FROM Stages WHERE idStage = {StageId}";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    FillTable(dataGridView2, StagesSql);
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (MainTables.SelectedIndex)
            {
                case 0:
                    break;

                case 1:
                    ComboLoad(EventsComboBox1, "Events", "idEvents", "EventName");
                    ComboLoad(AdressComboBox1, "Adresses", "idAdress", "Adress");
                    ComboLoad(ManagerComboBox1, "Managers", "idMAnager", "ManagerFIO");

                    ComboLoad(EventsComboBox2, "Events", "idEvents", "EventName");
                    ComboLoad(AdressComboBox2, "Adresses", "idAdress", "Adress");
                    ComboLoad(ManagerComboBox2, "Managers", "idMAnager", "ManagerFIO");
                    FillTable(dataGridView2, StagesSql);
                    break;
                case 2:
                    ComboLoad(ManagerTypeCombo1, "ManagerTypes", "idManagerType", "ManagerType");

                    FillTable(dataGridView3, ManagersSql);
                    break;
                case 3:
                    ComboLoad(MemberTypeCombo1, "MemberTypes", "idMemberType", "MemberType");
                    FillTable(dataGridView4, MembersSql);
                    break;

                case 4:
                    ComboLoad(EventListCombo1, "Stages", "idStage", "StageName");
                    ComboLoad(MemberListCombo1, "Members", "idMember", "MemberFIO");
                    FillTable(dataGridView5, ListSql);
                    break;
            }
        }

        private void SaveButtonStages1_MouseLeave(object sender, EventArgs e)
        {
            Savebutton1.BackColor = Color.Transparent;
        }

        private void SaveButtonManager1_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"INSERT INTO Managers VALUES('{ManagerFIO1.Text}','{ManagerAlias1.Text}',{ManagerTypeCombo1.SelectedValue},'{ManagerLink1.Text}','{ManagerDesc1.Text}');";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    SaveButtonStages1.BackColor = Color.Green;
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            FillTable(dataGridView3, ManagersSql);
        }

        private void SaveButtonManager1_MouseLeave(object sender, EventArgs e)
        {
            Savebutton1.BackColor = Color.Transparent;
        }

        private void DeleteButtonManager1_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    ManagerId = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                    string sql = $"DELETE FROM Managers WHERE idManager = {ManagerId}";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    FillTable(dataGridView3, ManagersSql);
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateButtonManager2_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"UPDATE Managers SET ManagerFIO = '{ManagerFIO1.Text}', ManagerAlias = '{ManagerAlias1.Text}', ManagerTypeId = {ManagerTypeCombo1.SelectedValue}, ManagerLink = '{ManagerLink1.Text}', ManagerDesc = '{ManagerDesc1.Text}' WHERE idManager = {ManagerId};";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    FillTable(dataGridView3, ManagersSql);
                    FillTextBoxesMembers();
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveButtonMember1_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"INSERT INTO Members VALUES('{MemberFIO1.Text}','{MemberAlias1.Text}',{MemberTypeCombo1.SelectedValue},'{MemberLink1.Text}','{MemberDesc1.Text}');";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    SaveButtonStages1.BackColor = Color.Green;
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            FillTable(dataGridView4, MembersSql);
        }



        private void SaveButtonMember1_MouseLeave(object sender, EventArgs e)
        {
            Savebutton1.BackColor = Color.Transparent;
        }

        private void DeleteFromTable(DataGridView dataGrid, string Table, string idCol, string sqlFillData)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string Id = dataGrid.SelectedRows[0].Cells[0].Value.ToString();
                    string sql = $"DELETE FROM {Table} WHERE {idCol} = {Id}";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    FillTable(dataGrid, sqlFillData);
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DeleteButtonMember1_Click(object sender, EventArgs e)
        {
            DeleteFromTable(dataGridView4, "Members", "idMember", MembersSql);
        }

        //2 таблицы - 1ая мероприятия, по щелчку на мероприятие заполняется этапы + в комбо бокс тоже этапы этого мероприятия
        private void SaveButtonList1_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"INSERT INTO ParticipationList VALUES({EventListCombo1.SelectedValue},{MemberListCombo1.SelectedValue});";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    SaveButtonStages1.BackColor = Color.Green;
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            FillTable(dataGridView5, ListSql);
        }

        private void DeleteButtonList1_Click(object sender, EventArgs e)
        {
            DeleteFromTable(dataGridView5, "ParticipationList", "idPart", ListSql);
        }

        private void UpdateButtonList1_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    string sql = $"UPDATE ParticipationList SET StageId = {EventListCombo1.SelectedValue}, MemberId = {MemberListCombo1.SelectedValue}  WHERE idPart = {ListId};";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    FillTable(dataGridView5, ListSql);
                    FillTextBoxesList();
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Очистка полей после добавления нового значения
        //Проверка, существуют ли такие поля как номер этапа...
    }
}
