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
    /// <summary>
    /// Insert/Update subject form
    /// </summary>
    public partial class FormEditSubject : Form
    {
        private string connectionString;
        private DataGridViewRow rowToUpdate;

        public FormEditSubject(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        public FormEditSubject(string connectionString, DataGridViewRow rowToUpdate) : this(connectionString)
        {
            this.rowToUpdate = rowToUpdate;
        }

        private void FormEditSubject_Load(object sender, EventArgs e)
        {
            // if selected row to update passed in constructor, fill in input data
            if (rowToUpdate != null)
            {
                icoTextBox.Text = rowToUpdate.Cells["Ico"].Value.ToString();
                nazevTextBox.Text = rowToUpdate.Cells["Nazev"].Value.ToString();
                uliceTextBox.Text = rowToUpdate.Cells["Ulice"].Value.ToString();
                obecTextBox.Text = rowToUpdate.Cells["Obec"].Value.ToString();
                pscTextBox.Text = rowToUpdate.Cells["Psc"].Value.ToString().Trim();
                poznamkaTextBox.Text = rowToUpdate.Cells["Poznamka"].Value.ToString();
                Text = "Update Subject";
            }
            else
            {
                Text = "Insert Subject";
            }

            // Set focus on first input
            this.ActiveControl = icoTextBox;
        }

        /// <summary>
        /// Insert new record or update existing
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event args</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // data validation, show error messages, return if data invalid
            var validationErrors = GetValidationErrors();
            if (validationErrors.Count > 0)
            {
                MessageBox.Show(String.Join(Environment.NewLine, validationErrors), "Data Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // data valid - execute command
            if (rowToUpdate == null)
                InsertSubject();
            else
                UpdateSubject();
        }

        /// <summary>
        /// Insert new subject, keep form open for additional inserts
        /// </summary>
        private void InsertSubject()
        {
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
                
                // Set focus on first input
                this.ActiveControl = icoTextBox;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Update subject and close edit form
        /// </summary>
        private void UpdateSubject()
        {
            try
            {
                string updateQuery = "UPDATE Subjekt SET Ico = @NewIco, Nazev = @Nazev, Ulice = @Ulice, Obec = @Obec, Psc = @Psc," +
                    "Poznamka = @Poznamka, Vlozeno = @Vlozeno WHERE Ico = @Ico";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    connection.Open();

                    SqlParameter[] sqlParameters = new SqlParameter[] {
                        new SqlParameter("@Ico", rowToUpdate.Cells["Ico"].Value),
                        new SqlParameter("@NewIco", icoTextBox.Text),
                        new SqlParameter("@Nazev", nazevTextBox.Text),
                        new SqlParameter("@Ulice", uliceTextBox.Text),
                        new SqlParameter("@Obec", obecTextBox.Text),
                        new SqlParameter("@Psc", pscTextBox.Text),
                        new SqlParameter("@Poznamka", poznamkaTextBox.Text),
                        new SqlParameter("@Vlozeno", DateTime.Now)
                    };
                    command.Parameters.AddRange(sqlParameters);
                    command.ExecuteNonQuery();
                    Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Get list with user input validation errors
        /// </summary>
        /// <returns>Validation error list</returns>
        private List<string> GetValidationErrors()
        {
            var validationErrors = new List<string>();

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

        private void FormEditSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        /// <summary>
        /// Allow only numbers to be added
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event args</param>
        private void icoTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = icoTextBox.Text;
            if ((System.Text.RegularExpressions.Regex.IsMatch(icoTextBox.Text, "[^0-9]")) &&
              text != String.Empty)
            {
                icoTextBox.Text = text.Remove(text.Length - 1, 1);
            }
            icoTextBox.SelectionStart = icoTextBox.Text.Length;
        }

        /// <summary>
        /// Allow only numbers to be added
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event args</param>
        private void pscTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = pscTextBox.Text;
            if ((System.Text.RegularExpressions.Regex.IsMatch(pscTextBox.Text, "[^0-9]")) &&
              text != String.Empty)
            {
                pscTextBox.Text = text.Remove(text.Length - 1, 1);
            }
            pscTextBox.SelectionStart = pscTextBox.Text.Length;
        }
    }
}
