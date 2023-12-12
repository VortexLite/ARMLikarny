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
    public partial class AddDoctors : Form
    {
        private ConnectionDB dbconnection;
        private SqlConnection connection;
        public AddDoctors()
        {
            InitializeComponent();
            dbconnection = new ConnectionDB();
            connection = dbconnection.GetConnection();
        }

        private void EnterOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FisrtName.Text) &&
                !string.IsNullOrEmpty(Surname.Text) &&
                !string.IsNullOrEmpty(Specialization.Text) &&
                !string.IsNullOrEmpty(ContactInfo.Text) &&
                !string.IsNullOrEmpty(Schedule.Text) &&
                !string.IsNullOrEmpty(Cost.Text))
            {
                string id = "";
                var command = new SqlCommand("SELECT MAX(CAST(DoctorID AS INT)) AS max_id FROM Doctors", connection);
                try
                {
                    id = Convert.ToString(Convert.ToInt32(command.ExecuteScalar().ToString()) + 1);
                }
                catch
                {
                    id = "1";
                }

                var cmd = new SqlCommand("AddDoctors", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@FirstName", FisrtName.Text);
                cmd.Parameters.AddWithValue("@LastName", Surname.Text);
                cmd.Parameters.AddWithValue("@Specialization", Specialization.Text);
                cmd.Parameters.AddWithValue("@ContactInfo", ContactInfo.Text);
                cmd.Parameters.AddWithValue("@Schedule", Schedule.Text);
                cmd.Parameters.AddWithValue("@Cost", Cost.Text);

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
}
