using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARMLikarny.Forms
{
    public partial class Appointments : Form
    {
        private ConnectionDB dbconnection;
        private SqlConnection connection;
        public Appointments()
        {
            InitializeComponent();
            dbconnection = new ConnectionDB();
            connection = dbconnection.GetConnection();
        }

        private void Appointments_Load(object sender, EventArgs e)
        {
            ComboDoc.Items.Clear();
            var cmd = new SqlCommand("SELECT DoctorID ,LastName, FirstName, Specialization, Cost FROM Doctors", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetInt32(0).ToString();
                string surname = reader.GetString(1);
                string name = reader.GetString(2);
                string spec = reader.GetString(3);
                string cost = reader.GetString(4);
                string comboBoxItem = $"{id} {surname} {name} {spec} {cost}";
                ComboDoc.Items.Add(comboBoxItem);
            }
            reader.Close();

            ComboPat.Items.Clear();
            cmd = new SqlCommand("SELECT PatientID, LastName, FirstName, DateOfBirth, ContactInfo FROM Patients", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetInt32(0).ToString();
                string surname = reader.GetString(1);
                string name = reader.GetString(2);
                string dates = reader.GetDateTime(3).ToString("yyyy-MM-dd");
                string contct = reader.GetString(4);
                string comboBoxItem = $"{id} {surname} {name} {dates} {contct}";
                ComboPat.Items.Add(comboBoxItem);
            }
            reader.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = DateTime.Now; // Замість DateTime.Now можна використати значення за замовчуванням, якщо потрібно

            using (var calendarForm = new CalendarForm(selectedDateTime))
            {
                if (calendarForm.ShowDialog() == DialogResult.OK)
                {
                    selectedDateTime = calendarForm.SelectedDateTime;

                    // Запис обраної дати та часу у форматі "yyyy-MM-dd HH:mm:ss" у мітку (label)
                    DateOut.Text = selectedDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }

        private void EnterOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DateOut.Text) &&
                !string.IsNullOrEmpty(ComboDoc.Text) &&
                !string.IsNullOrEmpty(ComboPat.Text))
            {
                string id = "";
                var command = new SqlCommand("SELECT MAX(CAST(AppointmentID AS INT)) AS max_id FROM Appointments", connection);
                try
                {
                    id = Convert.ToString(Convert.ToInt32(command.ExecuteScalar().ToString()) + 1);
                }
                catch
                {
                    id = "1";
                }
                string[] words = ComboDoc.Text.Split(' ');
                string idDoc = words[0];

                string[] words2 = ComboPat.Text.Split(' ');
                string idPat = words2[0];

                string dates = DateOut.Text;
                var cmd = new SqlCommand("AddAppointments", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@datet", DateOut.Text);
                cmd.Parameters.AddWithValue("@idDoc", idDoc);
                cmd.Parameters.AddWithValue("@idPat", idPat);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Лікар найнятий", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Помилка у введені даних", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class CalendarForm : Form
    {
        private DateTimePicker dateTimePicker;
        private Button okButton;

        public DateTime SelectedDateTime { get; private set; }

        public CalendarForm(DateTime initialDateTime)
        {
            InitializeComponent();

            // Встановлюємо початкове значення для DateTimePicker
            dateTimePicker.Value = initialDateTime;
        }

        private void InitializeComponent()
        {
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Налаштування DateTimePicker
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateTimePicker.ShowUpDown = true;

            // Налаштування okButton
            this.okButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okButton.Text = "OK";
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);

            // Налаштування CalendarForm
            this.ClientSize = new System.Drawing.Size(250, 150);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.dateTimePicker);
            this.ResumeLayout(false);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Запам'ятовування обраної дати та часу
            SelectedDateTime = dateTimePicker.Value;
        }
    }
}
