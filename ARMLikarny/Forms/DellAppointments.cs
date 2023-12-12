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

namespace ARMLikarny.Forms
{
    public partial class DellAppointments : Form
    {
        private ConnectionDB dbconnection;
        private SqlConnection connection;
        public DellAppointments()
        {
            InitializeComponent();
            dbconnection = new ConnectionDB();
            connection = dbconnection.GetConnection();
        }

        private void DellAppointments_Load(object sender, EventArgs e)
        {
            DellAppointment.Items.Clear();
            var cmd = new SqlCommand("SELECT app.AppointmentID, pat.LastName, doc.LastName, app.AppointmentDate\r\nFROM Appointments as app\r\nINNER JOIN Doctors as doc ON app.DoctorID = doc.DoctorID\r\nINNER JOIN Patients as pat ON app.PatientID = pat.PatientID", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetInt32(0).ToString();
                string surnamePat = reader.GetString(1);
                string surnameDoc = reader.GetString(2);
                string AppDate = reader.GetDateTime(3).ToString("yyyy-MM-dd HH:mm:ss");
                string comboBoxItem = $"{id} {surnamePat} {surnameDoc} {AppDate}";
                DellAppointment.Items.Add(comboBoxItem);
            }
            reader.Close();
        }

        private void EnterOK_Click(object sender, EventArgs e)
        {
            string combotxt = DellAppointment.Text;
            string[] words2 = combotxt.Split(' ');
            string id = words2[0];

            if (DellAppointment.SelectedItem != null)
            {
                var cmd = new SqlCommand("DellAppointments", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                DellAppointment.Items.Remove(DellAppointment.SelectedItem);
                MessageBox.Show("Запис на прийом видалено", "Успіх", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Помилка у видаленні запису на прийом", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
