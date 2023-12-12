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
    public partial class DellPatient : Form
    {
        private ConnectionDB dbconnection;
        private SqlConnection connection;
        public DellPatient()
        {
            InitializeComponent();
            dbconnection = new ConnectionDB();
            connection = dbconnection.GetConnection();
        }

        private void DellPatient_Load(object sender, EventArgs e)
        {
            DellPat.Items.Clear();
            var cmd = new SqlCommand("SELECT PatientID, LastName, FirstName, DateOfBirth, ContactInfo FROM Patients", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetInt32(0).ToString();
                string surname = reader.GetString(1);
                string name = reader.GetString(2);
                string dates = reader.GetDateTime(3).ToString("yyyy-MM-dd");
                string contct = reader.GetString(4);
                string comboBoxItem = $"{id} {surname} {name} {dates} {contct}";
                DellPat.Items.Add(comboBoxItem);
            }
            reader.Close();
        }

        private void EnterOK_Click(object sender, EventArgs e)
        {
            string combotxt = DellPat.Text;
            string[] words2 = combotxt.Split(' ');
            string id = words2[0];

            if (DellPat.SelectedItem != null)
            {

                var cmd = new SqlCommand("dellPatient", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                DellPat.Items.Remove(DellPat.SelectedItem);
                MessageBox.Show("Пацієнта видалено", "Успіх", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Помилка у видаленні", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
