
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(947, 188);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 270);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(947, 215);
            this.dataGridView2.TabIndex = 15;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 491);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(111, 35);
            this.BackButton.TabIndex = 16;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // MembersButton
            // 
            this.MembersButton.Location = new System.Drawing.Point(129, 491);
            this.MembersButton.Name = "MembersButton";
            this.MembersButton.Size = new System.Drawing.Size(111, 35);
            this.MembersButton.TabIndex = 17;
            this.MembersButton.Text = "Участники";
            this.MembersButton.UseVisualStyleBackColor = true;
            this.MembersButton.Click += new System.EventHandler(this.MembersButton_Click);
            // 
            // ManagerButton
            // 
            this.ManagerButton.Location = new System.Drawing.Point(255, 491);
            this.ManagerButton.Name = "ManagerButton";
            this.ManagerButton.Size = new System.Drawing.Size(111, 35);
            this.ManagerButton.TabIndex = 18;
            this.ManagerButton.Text = "Организатор";
            this.ManagerButton.UseVisualStyleBackColor = true;
            // 
            // ResetEvents
            // 
            this.ResetEvents.Location = new System.Drawing.Point(12, 230);
            this.ResetEvents.Name = "ResetEvents";
            this.ResetEvents.Size = new System.Drawing.Size(111, 34);
            this.ResetEvents.TabIndex = 19;
            this.ResetEvents.Text = "Все мероприятия";
            this.ResetEvents.UseVisualStyleBackColor = true;
            this.ResetEvents.Click += new System.EventHandler(this.ResetEvents_Click);
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 538);
            this.Controls.Add(this.ResetEvents);
            this.Controls.Add(this.ManagerButton);
            this.Controls.Add(this.MembersButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ViewForm";
            this.Text = "ViewForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button MembersButton;
        private System.Windows.Forms.Button ManagerButton;
        private System.Windows.Forms.Button ResetEvents;
    }
}