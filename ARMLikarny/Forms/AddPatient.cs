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
    public partial class AddPatient : Form
    {
        private ConnectionDB dbconnection;
        private SqlConnection connection;
        public AddPatient()
        {
            InitializeComponent();
            dbconnection = new ConnectionDB();
            connection = dbconnection.GetConnection();
        }

        private void EnterOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FisrtName.Text) &&
                !string.IsNullOrEmpty(Surname.Text) &&
                !string.IsNullOrEmpty(DateOfBirth.Text) &&
                !string.IsNullOrEmpty(ContactInfo.Text))
            {
                string id = "";
                var command = new SqlCommand("SELECT MAX(CAST(PatientID AS INT)) AS max_id FROM Patients", connection);
                try
                {
                    id = Convert.ToString(Convert.ToInt32(command.ExecuteScalar().ToString()) + 1);
                }
                catch
                {
                    id = "1";
                }
                string dat = DateOfBirth.Text;
                var cmd = new SqlCommand("AddPatient", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@FirstName", FisrtName.Text);
                cmd.Parameters.AddWithValue("@LastName", Surname.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth.Text);
                cmd.Parameters.AddWithValue("@ContactInfo", ContactInfo.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Пацієнт добавлений", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Помилка у введені даних", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
