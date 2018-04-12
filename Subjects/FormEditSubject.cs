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
            icoTextBox.Text = rowToUpdate.Cells["Ico"].ToString();
            nazevTextBox.Text = rowToUpdate.Cells["Ico"].ToString();
            uliceTextBox.Text = rowToUpdate.Cells["Ico"].ToString();
            obecTextBox.Text = rowToUpdate.Cells["Ico"].ToString();
            pscTextBox.Text = rowToUpdate.Cells["Ico"].ToString();
            poznamkaTextBox.Text = rowToUpdate.Cells["Ico"].ToString();
        }

        private void FormEditSubject_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // data validation, show error messages, return if data invalid
            var validationErrors = GetValidationErrors();
            if (validationErrors.Count > 0)
            {
                MessageBox.Show(String.Join(Environment.NewLine, validationErrors), "Data Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string insertQuery = "INSERT INTO Subjekt VALUES (@Ico, @Nazev, @Ulice, @Obec, @Psc, @Poznamka, @Vlozeno)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    connection.Open();

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
                MessageBox.Show("Record successfully added.", "Insert Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private List<string> GetValidationErrors()
        {
            var validationErrors = new List<string>();

            //    icoTextBox.Text,
            //    nazevTextBox.Text,
            //    uliceTextBox.Text,
            //    obecTextBox.Text,
            //    pscTextBox.Text,
            //    poznamkaTextBox.Text,

            // Ico
            try
            {
                var ico = UInt32.Parse(icoTextBox.Text);
            }
            catch (Exception exc)
            {
                validationErrors.Add("Enter valid Ico number.");
            }

            // Nazev
            if (nazevTextBox.Text.Length > 60)
            {
                validationErrors.Add("Maximal Nazev length is 60 characters.");
            }

            // Ulice
            if (uliceTextBox.Text.Length > 60)
            {
                validationErrors.Add("Maximal Ulice length is 60 characters.");
            }

            // Obec
            if (obecTextBox.Text.Length > 60)
            {
                validationErrors.Add("Maximal Obec length is 60 characters.");
            }

            // Psc
            try
            {
                var psc = UInt32.Parse(pscTextBox.Text);
            }
            catch (Exception exc)
            {
                validationErrors.Add("Enter valid Psc number.");
            }

            if (pscTextBox.Text.Length > 5)
            {
                validationErrors.Add("Maximal Psc length is 5 characters.");
            }

            return validationErrors;
        }
    }
}
