﻿using System;
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
    /// <summary>
    /// Main Subjects application form
    /// </summary>
    public partial class FormMain : Form
    {
        public const string AppConfigConnectionString = "SubjectDBConnectionString";

        private string connectionString;
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private static List<string> helpLines = new List<string>()
            {
                $"Local database must be present in project directory for proper functionality.{Environment.NewLine}" +
                    $"Connection string in app.config must be set correctly.",
                "Select grid cell(s) in rows to be deleted, then click Delete button to delete data from database.",
                "Select grid cell(s) in row to be edited, then click Edit button to update data from database.",
                "Data can be refreshed with menu/toolbar Refresh button or with F5 key.",
                "Ico and Psc input characters must be numbers only.",
                "Insert/Update Subject form can be closed with Escape key and submitted with Enter key."
            };

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // get connection string from app config
            connectionString = ConfigurationManager.ConnectionStrings[AppConfigConnectionString].ConnectionString;

            // fill datagrids with database data
            LoadDBData();

            // set initial column width
            dataGridViewSubject.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridViewContact.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        /// <summary>
        /// Get Subjekt and Kontakt table data, fill in dataGridViews
        /// </summary>
        private void LoadDBData()
        {
            try
            {
                // fill subject and contact dataGridView
                DataSet dataset = new DataSet();
                DataTable dataTableSubject = new DataTable();
                DataTable dataTableContact = new DataTable();
                string querySubjektString = SubjectDbConstants.QuerySelectSubject;
                string queryKontaktString = SubjectDbConstants.QuerySelectContact;
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
                MessageBox.Show(exc.Message, SubjectAppConstants.ErrDBLoad, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Insert new subject via form FormEditSubject
        /// </summary>
        private void InsertSubject()
        {
            using (FormEditSubject formEditSubject = new FormEditSubject(connectionString))
            {
                formEditSubject.ShowDialog();
            }
        }

        /// <summary>
        /// Update first selected dataGridViewSubject row via form FormEditSubject
        /// if nothing selected, return
        /// </summary>
        private void EditSubject()
        {
            // get first selected item to update
            DataGridViewRow selectedRow = GetSelectedRows().FirstOrDefault();

            // nothing selected, return
            if (selectedRow == null)
                return;

            using (FormEditSubject formEditSubject = new FormEditSubject(connectionString, selectedRow))
            {
                formEditSubject.ShowDialog();
            }
        }

        /// <summary>
        /// Get dataGridViewSubject selected rows
        /// </summary>
        /// <returns>Selected dataGridViewSubject rows</returns>
        private IEnumerable<DataGridViewRow> GetSelectedRows()
        {
            return dataGridViewSubject.SelectedCells.Cast<DataGridViewCell>()
                .Select(cell => cell.OwningRow)
                .Distinct()
                .OrderBy(row => row.Index);
        }

        /// <summary>
        /// Delete selected subject(s)
        /// </summary>
        private void DeleteSubject()
        {
            try
            {
                string deleteQuery = SubjectDbConstants.QueryDeleteSubject;
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    // get selected item rows to be deleted
                    IEnumerable<DataGridViewRow> selectedRows = GetSelectedRows();

                    // nothing selected, return
                    if (selectedRows.Count() == 0)
                        return;

                    // confirm deletion, if no, skip deletion and return
                    if (DialogResult.No == MessageBox.Show(SubjectAppConstants.WrnDeleteItem,
                        SubjectAppConstants.CaptionWrnDeleteItem, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
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
                MessageBox.Show(exc.Message, SubjectAppConstants.CaptionErrDeleteItem, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region ActionButtonMethods
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDBData();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadDBData();
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

        private void refreshToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoadDBData();
        }

        private void toolStripButtonExport_Click(object sender, EventArgs e)
        {
            try
            {
                var sb = new StringBuilder();

                var headers = dataGridViewSubject.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

                foreach (DataGridViewRow row in dataGridViewSubject.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                }

                // Get the location and file name of the file to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV files(*.csv)| *.csv|All files (*.*)|*.*";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveDialog.FileName, false))
                    {
                        sw.WriteLine(sb.ToString());
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, SubjectAppConstants.CaptionErrExport, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                LoadDBData();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Join(Environment.NewLine + Environment.NewLine, helpLines.ToArray()),
                SubjectAppConstants.CaptionInfoHelp, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
