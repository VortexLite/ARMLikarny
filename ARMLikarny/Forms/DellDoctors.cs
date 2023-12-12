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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace ARMLikarny.Forms
{
    public partial class DellDoctors : Form
    {
        private ConnectionDB dbconnection;
        private SqlConnection connection;
        public DellDoctors()
        {
            InitializeComponent();
            dbconnection = new ConnectionDB();
            connection = dbconnection.GetConnection();
        }

        private void DellDoctors_Load(object sender, EventArgs e)
        {
            DellDoctor.Items.Clear();
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
                DellDoctor.Items.Add(comboBoxItem);
            }
            reader.Close();
        }

        private void EnterOK_Click(object sender, EventArgs e)
        {
            string combotxt = DellDoctor.Text;
            string[] words2 = combotxt.Split(' ');
            string id = words2[0];

            if (DellDoctor.SelectedItem != null)
            {
                var cmd = new SqlCommand("DellDoctor", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                DellDoctor.Items.Remove(DellDoctor.SelectedItem);
                MessageBox.Show("Лікаря звільнено", "Успіх", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Помилка у звільнені доктора", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
