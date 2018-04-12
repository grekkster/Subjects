using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subjects
{
    public partial class FormEditSubject : Form
    {
        public FormEditSubject()
        {
            InitializeComponent();
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Rows.Add(new string[] { "" });
            dataGridView1.Rows.Add(new string[] { "" });
            dataGridView1.Rows.Add(new string[] { "" });
            dataGridView1.Rows.Add(new string[] { "" });
            this.Controls.Add(dataGridView1);
            this.Text = "DataGridView rollover-cell demo";
        }

        private void FormEditSubject_Load(object sender, EventArgs e)
        {
            //todo udělat přes databinding, stejně jako zobrazení gridu, tak jen pro row, a na OK upravit podle něj hodnoty v DB!
        }
    }
}
