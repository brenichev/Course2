
namespace EventsTest
{
    partial class ViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.BackButton = new System.Windows.Forms.Button();
            this.MembersButton = new System.Windows.Forms.Button();
            this.ManagerButton = new System.Windows.Forms.Button();
            this.ResetEvents = new System.Windows.Forms.Button();
            this.TypeIdBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimeStart1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFinish1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(194, 50);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1245, 260);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(194, 374);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1245, 298);
            this.dataGridView2.TabIndex = 15;
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.Location = new System.Drawing.Point(194, 680);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(166, 48);
            this.BackButton.TabIndex = 16;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // MembersButton
            // 
            this.MembersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MembersButton.Location = new System.Drawing.Point(369, 680);
            this.MembersButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MembersButton.Name = "MembersButton";
            this.MembersButton.Size = new System.Drawing.Size(166, 48);
            this.MembersButton.TabIndex = 17;
            this.MembersButton.Text = "Участники";
            this.MembersButton.UseVisualStyleBackColor = true;
            this.MembersButton.Click += new System.EventHandler(this.MembersButton_Click);
            // 
            // ManagerButton
            // 
            this.ManagerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ManagerButton.Location = new System.Drawing.Point(558, 680);
            this.ManagerButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ManagerButton.Name = "ManagerButton";
            this.ManagerButton.Size = new System.Drawing.Size(166, 48);
            this.ManagerButton.TabIndex = 18;
            this.ManagerButton.Text = "Организатор";
            this.ManagerButton.UseVisualStyleBackColor = true;
            this.ManagerButton.Click += new System.EventHandler(this.ManagerButton_Click);
            // 
            // ResetEvents
            // 
            this.ResetEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResetEvents.Location = new System.Drawing.Point(194, 318);
            this.ResetEvents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ResetEvents.Name = "ResetEvents";
            this.ResetEvents.Size = new System.Drawing.Size(166, 47);
            this.ResetEvents.TabIndex = 19;
            this.ResetEvents.Text = "Все мероприятия";
            this.ResetEvents.UseVisualStyleBackColor = true;
            this.ResetEvents.Click += new System.EventHandler(this.ResetEvents_Click);
            // 
            // TypeIdBox
            // 
            this.TypeIdBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TypeIdBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TypeIdBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeIdBox.FormattingEnabled = true;
            this.TypeIdBox.Location = new System.Drawing.Point(6, 109);
            this.TypeIdBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TypeIdBox.Name = "TypeIdBox";
            this.TypeIdBox.Size = new System.Drawing.Size(180, 26);
            this.TypeIdBox.TabIndex = 20;
            this.TypeIdBox.SelectionChangeCommitted += new System.EventHandler(this.TypeIdBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "Тип мероприятия";
            // 
            // dateTimeStart1
            // 
            this.dateTimeStart1.CustomFormat = "d-MM-yyyy HH:mm";
            this.dateTimeStart1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStart1.Location = new System.Drawing.Point(6, 168);
            this.dateTimeStart1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeStart1.Name = "dateTimeStart1";
            this.dateTimeStart1.Size = new System.Drawing.Size(183, 24);
            this.dateTimeStart1.TabIndex = 22;
            // 
            // dateTimeFinish1
            // 
            this.dateTimeFinish1.CustomFormat = "d-MM-yyyy HH:mm";
            this.dateTimeFinish1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeFinish1.Location = new System.Drawing.Point(6, 222);
            this.dateTimeFinish1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeFinish1.Name = "dateTimeFinish1";
            this.dateTimeFinish1.Size = new System.Drawing.Size(183, 24);
            this.dateTimeFinish1.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 38);
            this.button1.TabIndex = 24;
            this.button1.Text = "Поиск по дате";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "Дата и время начала";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Дата и время окончания";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Выборка";
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 745);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimeFinish1);
            this.Controls.Add(this.dateTimeStart1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TypeIdBox);
            this.Controls.Add(this.ResetEvents);
            this.Controls.Add(this.ManagerButton);
            this.Controls.Add(this.MembersButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ViewForm";
            this.Text = "ViewForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button MembersButton;
        private System.Windows.Forms.Button ManagerButton;
        private System.Windows.Forms.Button ResetEvents;
        private System.Windows.Forms.ComboBox TypeIdBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimeStart1;
        private System.Windows.Forms.DateTimePicker dateTimeFinish1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}