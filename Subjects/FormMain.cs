using System;
using System.Configuration;
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
    public partial class FormMain : Form
    {

        private string connectionString;
        private SqlConnection connection;
        private SqlDataAdapter adapter;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // get connection string from app config
            connectionString = ConfigurationManager.ConnectionStrings["SubjectDBConnectionString"].ConnectionString;

            //TODO - LINQ to SQL
            //https://docs.microsoft.com/cs-cz/dotnet/framework/data/adonet/sql/linq/

            //factory + DBConnection:
            //https://www.youtube.com/watch?v=OdDkFPO_nto

            // fill datagrids with database data
            RefreshData();

            // set initial column width
            dataGridViewSubject.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridViewContact.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void RefreshData()
        {
            try
            {
                // fill subject and contact dataGridView
                DataSet dataset = new DataSet();
                DataTable dataTableSubject = new DataTable();
                DataTable dataTableContact = new DataTable();
                string querySubjektString = "SELECT *, (select COUNT(*) FROM Kontakt WHERE Kontakt.Ico = Subjekt.Ico) AS PocetKontaktu FROM Subjekt";
                string queryKontaktString = "SELECT * FROM Kontakt";
                using (connection = new SqlConnection(connectionString))
                using (adapter = new SqlDataAdapter())
                {
                    // subjekt
                    adapter.SelectCommand = new SqlCommand(querySubjektString, connection);
                    adapter.Fill(dataTableSubject);
                    dataGridViewSubject.DataSource = dataTableSubject;

                    // contact
                    adapter.SelectCommand = new SqlCommand(queryKontaktString, connection);
                    adapter.Fill(dataTableContact);
                    dataGridViewContact.DataSource = dataTableContact;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Refresh Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertSubject()
        {
            try
            {
                //using (FormEditSubject formEditSubject = new FormEditSubject())
                //{
                //    formEditSubject.ShowDialog();
                //}

                string insertQuery = "INSERT INTO Subjekt VALUES (@Ico, @Nazev, @Ulice, @Obec, @Psc, @Poznamka, @Vlozeno)";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    connection.Open();
                    //TODO validace záznamů, data typy, stejný záznamy - test PK jestli existuje?
                    //TODO ošetřit existující klíč - pohledat na netu jak se dělá?

                    SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@Ico", 321),
                    new SqlParameter("@Nazev", "TestSubjekt1"),
                    new SqlParameter("@Ulice", "Pernikova"),
                    new SqlParameter("@Obec", "Turnov"),
                    new SqlParameter("@Psc", 46001),
                    new SqlParameter("@Poznamka", "žádná poznámka"),
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

        private void EditSubject()
        {
            //TODO vzít selected row, předat jako parametr a buď pracovat přimo s adaptérem pro row a zavolat update, nebo jen vzít hodnoty a zavolat novej query jen s daty
            /*
            When you want to send your changes to the database you can just call the adapter.update method...
            adapter.Update(ds);
            https://social.msdn.microsoft.com/Forums/en-US/8db841fc-ffa7-4519-b6f5-d054c7190948/insert-deleting-updating-records-into-database-using-datagridview-in-visual-c?forum=csharplanguage
            ***

            https://khanrahim.wordpress.com/2010/04/10/insert-update-delete-with-datagridview-control-in-c-windows-application/
            */

            try
            {
                // get first selected item to update
                DataGridViewRow selectedRow = GetSelectedRows().FirstOrDefault();

                // nothing selected, return
                if (selectedRow == null)
                    return;

                //using (FormEditSubject formEditSubject = new FormEditSubject())
                //{
                //    formEditSubject.ShowDialog();
                //}

                string updateQuery = "UPDATE Subjekt SET Ico = @NewIco, Nazev = @Nazev, Ulice = @Ulice, Obec = @Obec, Psc = @Psc, Poznamka = @Poznamka," +
                    " Vlozeno = @Vlozeno WHERE Ico = @Ico";
                //string updateQuery = "UPDATE Subjekt SET Ulice = @Ulice WHERE Ico = @Ico";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    connection.Open();
                    //TODO validace záznamů, data typy, stejný záznamy - test PK jestli existuje?
                    // TODO padá pokud upravím ičo na již existující ičo

                    SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@Ico", 321),
                    new SqlParameter("@NewIco", 444),
                    new SqlParameter("@Nazev", "TestSubjekt4"),
                    new SqlParameter("@Ulice", "Ctvrta"),
                    new SqlParameter("@Obec", "Ctverin"),
                    new SqlParameter("@Psc", 44444),
                    new SqlParameter("@Poznamka", "čtyřka"),
                    new SqlParameter("@Vlozeno", DateTime.Now)
                };
                    command.Parameters.AddRange(sqlParameters);

                    //command.Parameters.AddWithValue("Ulice", "Maršála Koněva");
                    //command.Parameters.AddWithValue("Ico", 321);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // get rows where any cell is selected
        private IEnumerable<DataGridViewRow> GetSelectedRows()
        {
            return dataGridViewSubject.SelectedCells.Cast<DataGridViewCell>()
                .Select(cell => cell.OwningRow)
                .Distinct()
                .OrderBy(row => row.Index);
        }

        private void DeleteSubject()
        {
            try
            {
                string deleteQuery = "DELETE FROM Subjekt WHERE Ico = @Ico";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    // get selected item rows to be deleted
                    IEnumerable<DataGridViewRow> selectedRows = GetSelectedRows();

                    // nothing selected, return
                    if (selectedRows.Count() == 0)
                        return;

                    // confirm deletion, if no, skip deletion and return
                    if (DialogResult.No == MessageBox.Show("Are you sure you want to delete selected item(s)?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        return;

                    // delete selected rows
                    connection.Open();
                    command.Parameters.Add("@Ico", SqlDbType.Int);
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        command.Parameters["@Ico"].Value = row.Cells["Ico"].Value;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region ActionButtonMethods
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertSubject();
        }

        private void toolStripButtonInsert_Click(object sender, EventArgs e)
        {
            InsertSubject();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSubject();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteSubject();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditSubject();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            EditSubject();
        }
        #endregion
    }
}
