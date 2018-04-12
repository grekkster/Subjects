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
    public enum FormSqlOperation { Insert, Update };

    public partial class FormEditSubject : Form
    {

        public FormEditSubject(FormSqlOperation sqlOperation)
        {
            InitializeComponent();
        }

        public FormEditSubject(FormSqlOperation sqlOperation, DataGridViewRow rowToUpdate)
        {

        }

        private void FormEditSubject_Load(object sender, EventArgs e)
        {

        }
    }
}
