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
    public partial class ViewForm : Form
    {
        private string idString = "";
        public ViewForm()
        {
            InitializeComponent();
            FillTable(dataGridView1, "SELECT idEvents, EventName, EventTypes.EventType, Ages.Age, EventForms.EventForm, EventLink, EventDesc FROM Events JOIN EventTypes ON Typeid = idType JOIN Ages ON Events.Ageid = Ages.idAge JOIN EventForms ON Events.Formid = EventForms.idForm");
            ComboLoad(TypeIdBox, "EventTypes", "idType", "EventType");
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
                }
            }
        }

        private void FillTableWhere(DataGridView dataGrid, string sql, string id)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = Form1.connectionString;
                cnn.Open();
                try
                {
                    //string EventId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    //string EventId = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                    SqlDataAdapter SDA2 = new SqlDataAdapter(sql, cnn);
                    SDA2.SelectCommand.Parameters.AddWithValue("@id", id);
                    DataTable data = new DataTable();
                    SDA2.Fill(data);
                    dataGrid.DataSource = data;
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idString = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            FillTableWhere(dataGridView2, $"select idStage, StageNumber, StageName, Adresses.Adress, DateStart, DateFinish, StageCost, StageDesc, Managers.ManagerFIO from Stages JOIN Adresses on Stages.AdressId = Adresses.idAdress JOIN Managers on Stages.ManagerId = Managers.idManager WHERE EventId = @id", idString);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (idString != "")
                FillTableWhere(dataGridView2, $"select idStage, StageNumber, StageName, Adresses.Adress, DateStart, DateFinish, StageCost, StageDesc, Managers.ManagerFIO from Stages JOIN Adresses on Stages.AdressId = Adresses.idAdress JOIN Managers on Stages.ManagerId = Managers.idManager WHERE EventId = @id", idString);
        }

        private void MembersButton_Click(object sender, EventArgs e)
        {
            string idString2 = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            FillTableWhere(dataGridView2, @"SELECT idMember, MemberFIO, MemberAlias, MemberTypes.MemberType, MemberLink, MemberDesc FROM Members JOIN MemberTypes ON MemberTypeId = idMemberType JOIN ParticipationList ON idMember = MemberId WHERE StageId = @id", idString2);
        }
        private void ManagerButton_Click(object sender, EventArgs e)
        {
            string idString2 = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            FillTableWhere(dataGridView2, @"SELECT idManager, ManagerFIO, ManagerAlias, ManagerTypes.ManagerType, ManagerLink, ManagerDesc FROM Managers JOIN ManagerTypes ON ManagerTypeId = idManagerType JOIN Stages ON idManager = ManagerId WHERE idStage = @id", idString2);
            
        }

        private void ResetEvents_Click(object sender, EventArgs e)
        {
            FillTable(dataGridView1, "SELECT idEvents, EventName, EventTypes.EventType, Ages.Age, EventForms.EventForm, EventLink, EventDesc FROM Events JOIN EventTypes ON Typeid = idType JOIN Ages ON Events.Ageid = Ages.idAge JOIN EventForms ON Events.Formid = EventForms.idForm");
        }

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
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        private void TypeIdBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (TypeIdBox.SelectedValue != null)
                idString = TypeIdBox.SelectedValue.ToString();
            FillTableWhere(dataGridView1, "SELECT idEvents, EventName, EventTypes.EventType, Ages.Age, EventForms.EventForm, EventLink, EventDesc FROM Events JOIN EventTypes ON Typeid = idType JOIN Ages ON Events.Ageid = Ages.idAge JOIN EventForms ON Events.Formid = EventForms.idForm WHERE TypeId = @id", idString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(dateTimeStart1.Value, dateTimeFinish1.Value) <= 0)
                using (var cnn = new SqlConnection())
                {
                    cnn.ConnectionString = Form1.connectionString;
                    cnn.Open();
                    try
                    {
                        //string EventId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        //string EventId = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                        SqlDataAdapter SDA2 = new SqlDataAdapter($"SELECT idEvents, EventName, EventTypes.EventType, Ages.Age, EventForms.EventForm, EventLink, EventDesc FROM Events JOIN EventTypes ON Typeid = idType JOIN Ages ON Events.Ageid = Ages.idAge JOIN EventForms ON Events.Formid = EventForms.idForm WHERE idEvents IN (SELECT DISTINCT EventId FROM Stages WHERE DateStart >= '{dateTimeStart1.Value}' AND DateFinish <= '{dateTimeFinish1.Value}')", cnn);
                        DataTable data = new DataTable();
                        SDA2.Fill(data);
                        dataGridView1.DataSource = data;
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось загрузить данные таблицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            else
                MessageBox.Show("Дата начала наступает позже, чем дата конца мероприятия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
