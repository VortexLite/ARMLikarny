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
    public partial class MedicalExamination : Form
    {
        private ConnectionDB dbconnection;
        private SqlConnection connection;
        public MedicalExamination()
        {
            InitializeComponent();
            dbconnection = new ConnectionDB();
            connection = dbconnection.GetConnection();
        }

        private void MedicalExamination_Load(object sender, EventArgs e)
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

        private void EnterOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HealthStatus.Text) &&
                !string.IsNullOrEmpty(Diagnosis.Text) &&
                !string.IsNullOrEmpty(DoctorRecommendations.Text) &&
                !string.IsNullOrEmpty(TestResults.Text))
            {
                string[] words = ComboPat.Text.Split(' ');
                string id = words[0];

                string[] words2 = ComboDoc.Text.Split(' ');
                string cost = words2[4];

                var cmd = new SqlCommand("UpdatePatients", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@HealthStatus", HealthStatus.Text);
                cmd.Parameters.AddWithValue("@Diagnosis", Diagnosis.Text);
                cmd.Parameters.AddWithValue("@DoctorRecommendations", DoctorRecommendations.Text);
                cmd.Parameters.AddWithValue("@TestResults", TestResults.Text);

                cmd.ExecuteNonQuery();

                string idPay = "";
                var command = new SqlCommand("SELECT MAX(CAST(ID_payment AS INT)) AS max_id FROM Payment", connection);
                try
                {
                    idPay = Convert.ToString(Convert.ToInt32(command.ExecuteScalar().ToString()) + 1);
                }
                catch
                {
                    idPay = "1";
                }
                string sum = Convert.ToString(Convert.ToDouble(cost) + 200);
                cmd = new SqlCommand("AddPayment", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idPay);
                cmd.Parameters.AddWithValue("@datet", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@pay", sum);
                cmd.Parameters.AddWithValue("@idPat", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Медичний огляд закінчився", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Помилка у введені даних", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
