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
            if(idString != "")
            FillTableWhere(dataGridView2, $"select idStage, StageNumber, StageName, Adresses.Adress, DateStart, DateFinish, StageCost, StageDesc, Managers.ManagerFIO from Stages JOIN Adresses on Stages.AdressId = Adresses.idAdress JOIN Managers on Stages.ManagerId = Managers.idManager WHERE EventId = @id", idString);
        }

        private void MembersButton_Click(object sender, EventArgs e)
        {
            string idString2 = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            FillTableWhere(dataGridView2, @"SELECT idMember, MemberFIO, MemberAlias, MemberTypes.MemberType, MemberLink, MemberDesc FROM Members JOIN MemberTypes ON MemberTypeId = idMemberType JOIN ParticipationList ON idMember = MemberId WHERE StageId = @id", idString2);
        }

        private void ResetEvents_Click(object sender, EventArgs e)
        {
            FillTable(dataGridView1, "SELECT idEvents, EventName, EventTypes.EventType, Ages.Age, EventForms.EventForm, EventLink, EventDesc FROM Events JOIN EventTypes ON Typeid = idType JOIN Ages ON Events.Ageid = Ages.idAge JOIN EventForms ON Events.Formid = EventForms.idForm");
        }

    }
}
