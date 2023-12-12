using ARMLikarny.Forms;
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

namespace ARMLikarny
{
    public partial class Form2 : Form
    {
        private ConnectionDB dbconnection;
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private string login;
        public Form2(string login)
        {
            InitializeComponent();
            this.login = login;
            dbconnection = new ConnectionDB();
            connection = dbconnection.GetConnection();
            dataGridView.Hide();
        }

        private void Form2_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            bool hasOpenForms = Application.OpenForms.Cast<Form>().Any(form => form.Visible);

            // Якщо немає відкритих форм, закриваємо програму
            if (!hasOpenForms)
            {
                Application.Exit();
            }
        }

        private void ViewMenuStrip()
        {
            ToolStripMenuItem doctorsView = new ToolStripMenuItem("Доктори");
            ToolStripMenuItem patientsView = new ToolStripMenuItem("Пацієнти");
            ToolStripMenuItem appointmentView = new ToolStripMenuItem("Записи");

            menuStripView.Items.Add(doctorsView);
            menuStripView.Items.Add(appointmentView);
            menuStripView.Items.Add(patientsView);

            doctorsView.Click += DoctorsView_Click;
            appointmentView.Click += AppointmentsView_Click;
            patientsView.Click += PatientsView_Click;
        }

        private void View_Click(object sender, EventArgs e)
        {
            CentralLabel.Text = View.Text;

            menuStripView.Items.Clear();
            dataGridView.ClearSelection();
            dataGridView.Show();

            ViewMenuStrip();
        }

        private void DoctorsView_Click(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            dataGridView.Show();
            dataAdapter = new SqlDataAdapter("SELECT * FROM Doctors_View", connection);

            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Doctors_View");

            dataGridView.DataSource = dataSet.Tables["Doctors_View"];
        }

        private void AppointmentsView_Click(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            dataGridView.Show();
            dataAdapter = new SqlDataAdapter("SELECT AppointmentID as [ID], AppointmentDate as [Дата запису], doc.LastName as [Прізвище лікаря], doc.FirstName as [Ім'я лікаря], \r\npat.LastName as [Прізвище пацієнта], pat.FirstName as [Ім'я пацієнта]\r\nFROM Appointments as app\r\nINNER JOIN Doctors as doc ON app.DoctorID = doc.DoctorID\r\nINNER JOIN Patients as pat ON app.PatientID = pat.PatientID", connection);

            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Appointments");

            dataGridView.DataSource = dataSet.Tables["Appointments"];
        }

        private void PatientsView_Click(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            dataGridView.Show();
            dataAdapter = new SqlDataAdapter("SELECT * FROM Patients_View", connection);

            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Patients_View");

            dataGridView.DataSource = dataSet.Tables["Patients_View"];
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            var auth = new Form1();
            this.Hide();
            auth.ShowDialog();
            
        }

        private void ControlmenuStrip()
        {
            if (login != "Pacient")
            {
                ToolStripMenuItem doctorControl = new ToolStripMenuItem("Доктор");
                ToolStripMenuItem patientControl = new ToolStripMenuItem("Пацієнт");
                ToolStripMenuItem appointmentsControl = new ToolStripMenuItem("Прийом до лікаля");
                ToolStripMenuItem MedicalExamination = new ToolStripMenuItem("Медичний огляд пацієнта");

                ToolStripMenuItem AddDoctor = new ToolStripMenuItem("Найняти лікаря");
                ToolStripMenuItem DellDoctor = new ToolStripMenuItem("Звільнити лікаря");
                ToolStripMenuItem AddPatient = new ToolStripMenuItem("Додати пацієнта");
                ToolStripMenuItem DellPatient = new ToolStripMenuItem("Видалити пацієнта");
                ToolStripMenuItem AddAppointment = new ToolStripMenuItem("Записатися");
                ToolStripMenuItem DellAppointment = new ToolStripMenuItem("Видалити запис");

                doctorControl.DropDownItems.Add(AddDoctor);
                doctorControl.DropDownItems.Add(DellDoctor);
                patientControl.DropDownItems.Add(AddPatient);
                patientControl.DropDownItems.Add(DellPatient);
                appointmentsControl.DropDownItems.Add(AddAppointment);
                appointmentsControl.DropDownItems.Add(DellAppointment);

                menuStripView.Items.Add(doctorControl);
                menuStripView.Items.Add(patientControl);
                menuStripView.Items.Add(appointmentsControl);
                menuStripView.Items.Add(MedicalExamination);

                AddDoctor.Click += AddDoctor_Click;
                DellDoctor.Click += DellDoctor_Click;
                AddPatient.Click += AddPatient_Click;
                DellPatient.Click += DellPatient_Click;
                AddAppointment.Click += AddAppointment_Click;
                DellAppointment.Click += DellAppointment_Click;
                MedicalExamination.Click += MedicalExamination_Click;
            }
            else 
            {
                ToolStripMenuItem appointmentsControl = new ToolStripMenuItem("Прийом до лікаля");
                ToolStripMenuItem AddAppointment = new ToolStripMenuItem("Записатися");
                ToolStripMenuItem DellAppointment = new ToolStripMenuItem("Видалити запис");
                appointmentsControl.DropDownItems.Add(AddAppointment);
                appointmentsControl.DropDownItems.Add(DellAppointment);
                menuStripView.Items.Add(appointmentsControl);
                AddAppointment.Click += AddAppointment_Click;
                DellAppointment.Click += DellAppointment_Click;
            }
        }

        private void Contr_Click(object sender, EventArgs e)
        {
            CentralLabel.Text = Contr.Text;

            menuStripView.Items.Clear();
            dataGridView.ClearSelection();
            dataGridView.Hide();

            ControlmenuStrip();
        }
        private void AddDoctor_Click(object sender, EventArgs e)
        {
            var addDoctor = new AddDoctors();
            addDoctor.ShowDialog();
        }

        private void DellDoctor_Click(object sender, EventArgs e)
        {
            var dellDoctor = new DellDoctors();
            dellDoctor.ShowDialog();
        }

        private void AddPatient_Click(object sender, EventArgs e)
        {
            var addPatient = new AddPatient();
            addPatient.ShowDialog();
        }

        private void DellPatient_Click(object sender, EventArgs e)
        {
            var dellPatient = new DellPatient();
            dellPatient.ShowDialog();
        }

        private void AddAppointment_Click(object sender, EventArgs e)
        {
            var addAppointments = new Appointments();
            addAppointments.ShowDialog();
        }

        private void DellAppointment_Click(object sender, EventArgs e)
        {
            var dellAppointments = new DellAppointments();
            dellAppointments.ShowDialog();
        }

        private void MedicalExamination_Click(object sender, EventArgs e)
        {
            var MedicalExamination = new MedicalExamination();
            MedicalExamination.ShowDialog();
        }

        private void ReportBtn_Click(object sender, EventArgs e)
        {
            var Rep = new ReportSelection();
            Rep.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
