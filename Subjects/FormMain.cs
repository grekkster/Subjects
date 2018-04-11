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
            connectionString = ConfigurationManager.ConnectionStrings["SubjectDBConnectionString"].ConnectionString;

            //TODO - LINQ to SQL
            //https://docs.microsoft.com/cs-cz/dotnet/framework/data/adonet/sql/linq/

            //factory + DBConnection:
            //https://www.youtube.com/watch?v=OdDkFPO_nto

            /*
            string queryString = "select *, (select COUNT(*) from Kontakt where Kontakt.Ico = Subjekt.Ico) as PocetKontaktu from Subjekt";
            DataSet dataset = new DataSet();
            using (connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    queryString, connection);
                adapter.Fill(dataset);
                dataGridViewSubject.DataSource = dataset;
            }

            
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (adapter = new SqlDataAdapter(command))
            {
                // subjekt
                command.Parameters.AddWithValue("@Parameter", parameter);
                adapter.Fill(dataTableSubjekt);
                dataGridViewSubject.DataSource = dataTableSubjekt;

                //kontakt
                //adapter.SelectCommand = new SqlCommand(queryKontaktString, connection);
                adapter.Fill(dataTableKontakt);
                dataGridViewContact.DataSource = dataTableKontakt;
            }
            */

            RefreshData();
        }

        //private void OpenConnection()
        //{

        //}

        //private void CloseConnection()
        //{

        //}

        private void RefreshData()
        {
            // Subjekt dataGridView
            DataSet dataset = new DataSet();
            DataTable dataTableSubjekt = new DataTable();
            DataTable dataTableKontakt = new DataTable();
            string querySubjektString = "select *, (select COUNT(*) from Kontakt where Kontakt.Ico = Subjekt.Ico) as PocetKontaktu from Subjekt";
            string queryKontaktString = "select * from Kontakt";
            using (connection = new SqlConnection(connectionString))
            using (adapter = new SqlDataAdapter())
            {
                // subjekt
                adapter.SelectCommand = new SqlCommand(querySubjektString, connection);
                adapter.Fill(dataTableSubjekt);
                dataGridViewSubject.DataSource = dataTableSubjekt;

                //kontakt
                adapter.SelectCommand = new SqlCommand(queryKontaktString, connection);
                adapter.Fill(dataTableKontakt);
                dataGridViewContact.DataSource = dataTableKontakt;
            }
        }

        private void InsertSubject()
        {
            using (FormEditSubject formEditSubject = new FormEditSubject())
            {
                formEditSubject.ShowDialog();
            }

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

        private void EditSubject()
        {
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

        private void DeleteSubject()
        {
            string updateQuery = "DELETE FROM Subjekt WHERE Ico = @Ico";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                // get items to be deleted
                List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
                foreach (DataGridViewCell cell in dataGridViewSubject.SelectedCells)
                {
                    selectedRows.Add(dataGridViewSubject.Rows[cell.RowIndex]);
                }

                // nothing selected
                if (selectedRows.Count == 0)
                    return;

                // delete selected rows
                connection.Open();
                command.Parameters.Add("Ico", SqlDbType.Int);
                foreach (DataGridViewRow row in selectedRows)
                {
                    command.Parameters["Ico"].Value = row.Cells["Ico"].Value;
                    command.ExecuteNonQuery();
                }
            }
        }

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
    }
}
