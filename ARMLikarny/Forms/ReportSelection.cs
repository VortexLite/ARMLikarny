using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARMLikarny.Forms
{
    public partial class ReportSelection : Form
    {
        private ConnectionDB dbconnection;
        private SqlConnection connection;
        public ReportSelection()
        {
            InitializeComponent();
            dbconnection = new ConnectionDB();
            connection = dbconnection.GetConnection();
        }

        private void ReportSelection_Load(object sender, EventArgs e)
        {
            ReportsCombo.Items.Clear();
            ReportsCombo.Items.Add("Працівники в лікарні");
            ReportsCombo.Items.Add("Пацієнти");

            ReportsCombo.SelectedIndex = 0;
        }

        private void EnterOK_Click(object sender, EventArgs e)
        {
            switch (ReportsCombo.SelectedItem)
            {
                case "Працівники в лікарні":
                    var RepDoc = new Report_Doctors();
                    RepDoc.ShowDialog();
                    break;

                case "Пацієнти":
                    var RepPat = new Report_Patient();
                    RepPat.ShowDialog();
                    break;
            }
        }
    }
}
