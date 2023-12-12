namespace ARMLikarny.Forms
{
    partial class DellDoctors
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
            this.EnterOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DellDoctor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // EnterOK
            // 
            this.EnterOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterOK.Location = new System.Drawing.Point(75, 102);
            this.EnterOK.Name = "EnterOK";
            this.EnterOK.Size = new System.Drawing.Size(371, 43);
            this.EnterOK.TabIndex = 31;
            this.EnterOK.Text = "Звільнити";
            this.EnterOK.UseVisualStyleBackColor = true;
            this.EnterOK.Click += new System.EventHandler(this.EnterOK_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(-1, -2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(523, 29);
            this.label2.TabIndex = 18;
            this.label2.Text = "Звільнити працівника";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(34, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 174);
            this.label1.TabIndex = 17;
            // 
            // DellDoctor
            // 
            this.DellDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DellDoctor.FormattingEnabled = true;
            this.DellDoctor.Location = new System.Drawing.Point(75, 48);
            this.DellDoctor.Name = "DellDoctor";
            this.DellDoctor.Size = new System.Drawing.Size(371, 28);
            this.DellDoctor.TabIndex = 32;
            // 
            // DellDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(524, 212);
            this.Controls.Add(this.DellDoctor);
            this.Controls.Add(this.EnterOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DellDoctors";
            this.Text = "DellDoctors";
            this.Load += new System.EventHandler(this.DellDoctors_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EnterOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DellDoctor;
    }
}