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
            }*/

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

        }

        private void EditSubject()
        {

        }

        private void DeleteSubject()
        {

        }
    }
}
