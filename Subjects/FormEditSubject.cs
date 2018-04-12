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

namespace Subjects
{
    public enum FormSqlOperation { Insert, Update };

    public partial class FormEditSubject : Form
    {
        private string connectionString;

        public FormEditSubject(string connectionString, FormSqlOperation sqlOperation)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        public FormEditSubject(SqlConnection connection, FormSqlOperation sqlOperation, DataGridViewRow rowToUpdate)
        {

        }

        private void FormEditSubject_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //TODO test povinnych hodnot! pokud OK -> provest prikaz


            try
            {
                string insertQuery = "INSERT INTO Subjekt VALUES (@Ico, @Nazev, @Ulice, @Obec, @Psc, @Poznamka, @Vlozeno)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    connection.Open();
                    //TODO validace záznamů, data typy, stejný záznamy - test PK jestli existuje?
                    //TODO ošetřit existující klíč - pohledat na netu jak se dělá?
                    //if (w.ShowDialog(this) == DialogResult.OK)
                    //{
                    //    DoSomething();
                    //}

                    SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@Ico", icoTextBox.Text),
                    new SqlParameter("@Nazev", nazevTextBox.Text),
                    new SqlParameter("@Ulice", uliceTextBox.Text),
                    new SqlParameter("@Obec", obecTextBox.Text),
                    new SqlParameter("@Psc", pscTextBox.Text),
                    new SqlParameter("@Poznamka", poznamkaTextBox.Text),
                    new SqlParameter("@Vlozeno", DateTime.Now)
                };
                    command.Parameters.AddRange(sqlParameters);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
