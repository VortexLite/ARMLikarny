namespace ARMLikarny
{
    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStripView = new System.Windows.Forms.MenuStrip();
            this.DoctorsView = new System.Windows.Forms.ToolStripMenuItem();
            this.PatientsView = new System.Windows.Forms.ToolStripMenuItem();
            this.AppointmentsView = new System.Windows.Forms.ToolStripMenuItem();
            this.CentralLabel = new System.Windows.Forms.Label();
            this.View = new System.Windows.Forms.Button();
            this.Contr = new System.Windows.Forms.Button();
            this.ReportBtn = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStripView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Controls.Add(this.menuStripView);
            this.panel1.Location = new System.Drawing.Point(111, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 344);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 25);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(490, 316);
            this.dataGridView.TabIndex = 1;
            // 
            // menuStripView
            // 
            this.menuStripView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoctorsView,
            this.PatientsView,
            this.AppointmentsView});
            this.menuStripView.Location = new System.Drawing.Point(0, 0);
            this.menuStripView.Name = "menuStripView";
            this.menuStripView.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStripView.Size = new System.Drawing.Size(490, 24);
            this.menuStripView.TabIndex = 0;
            this.menuStripView.Text = "menuStrip1";
            // 
            // DoctorsView
            // 
            this.DoctorsView.Name = "DoctorsView";
            this.DoctorsView.Size = new System.Drawing.Size(66, 20);
            this.DoctorsView.Text = "Доктори";
            this.DoctorsView.Click += new System.EventHandler(this.DoctorsView_Click);
            // 
            // PatientsView
            // 
            this.PatientsView.Name = "PatientsView";
            this.PatientsView.Size = new System.Drawing.Size(69, 20);
            this.PatientsView.Text = "Пацієнти";
            this.PatientsView.Click += new System.EventHandler(this.PatientsView_Click);
            // 
            // AppointmentsView
            // 
            this.AppointmentsView.Name = "AppointmentsView";
            this.AppointmentsView.Size = new System.Drawing.Size(59, 20);
            this.AppointmentsView.Text = "Записи";
            this.AppointmentsView.Click += new System.EventHandler(this.AppointmentsView_Click);
            // 
            // CentralLabel
            // 
            this.CentralLabel.BackColor = System.Drawing.Color.RoyalBlue;
            this.CentralLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CentralLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CentralLabel.Location = new System.Drawing.Point(-1, 0);
            this.CentralLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CentralLabel.Name = "CentralLabel";
            this.CentralLabel.Size = new System.Drawing.Size(602, 31);
            this.CentralLabel.TabIndex = 1;
            this.CentralLabel.Text = "Перегляд";
            this.CentralLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // View
            // 
            this.View.BackColor = System.Drawing.Color.RoyalBlue;
            this.View.FlatAppearance.BorderSize = 0;
            this.View.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.View.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.View.ForeColor = System.Drawing.SystemColors.Control;
            this.View.Location = new System.Drawing.Point(3, 104);
            this.View.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(106, 30);
            this.View.TabIndex = 2;
            this.View.Text = "Перегляд";
            this.View.UseVisualStyleBackColor = false;
            this.View.Click += new System.EventHandler(this.View_Click);
            // 
            // Contr
            // 
            this.Contr.BackColor = System.Drawing.Color.RoyalBlue;
            this.Contr.FlatAppearance.BorderSize = 0;
            this.Contr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Contr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Contr.ForeColor = System.Drawing.SystemColors.Control;
            this.Contr.Location = new System.Drawing.Point(3, 139);
            this.Contr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Contr.Name = "Contr";
            this.Contr.Size = new System.Drawing.Size(106, 30);
            this.Contr.TabIndex = 3;
            this.Contr.Text = "Управління";
            this.Contr.UseVisualStyleBackColor = false;
            this.Contr.Click += new System.EventHandler(this.Contr_Click);
            // 
            // ReportBtn
            // 
            this.ReportBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.ReportBtn.FlatAppearance.BorderSize = 0;
            this.ReportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReportBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ReportBtn.Location = new System.Drawing.Point(3, 174);
            this.ReportBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReportBtn.Name = "ReportBtn";
            this.ReportBtn.Size = new System.Drawing.Size(106, 30);
            this.ReportBtn.TabIndex = 4;
            this.ReportBtn.Text = "Звіти";
            this.ReportBtn.UseVisualStyleBackColor = false;
            this.ReportBtn.Click += new System.EventHandler(this.ReportBtn_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.RoyalBlue;
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.ForeColor = System.Drawing.SystemColors.Control;
            this.Exit.Location = new System.Drawing.Point(3, 326);
            this.Exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(106, 30);
            this.Exit.TabIndex = 5;
            this.Exit.Text = "Вихід";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlueViolet;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ReportBtn);
            this.Controls.Add(this.Contr);
            this.Controls.Add(this.View);
            this.Controls.Add(this.CentralLabel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed_1);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStripView.ResumeLayout(false);
            this.menuStripView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStripView;
        private System.Windows.Forms.Label CentralLabel;
        private System.Windows.Forms.Button View;
        private System.Windows.Forms.Button Contr;
        private System.Windows.Forms.Button ReportBtn;
        private System.Windows.Forms.ToolStripMenuItem DoctorsView;
        private System.Windows.Forms.ToolStripMenuItem AppointmentsView;
        private System.Windows.Forms.ToolStripMenuItem PatientsView;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button Exit;
    }
}