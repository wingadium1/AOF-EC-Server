using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void MDI_Load(object sender, EventArgs e)
        {

        }

        private void questionManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Question_Management newFormQuestionManagement = new Question_Management();
            newFormQuestionManagement.MdiParent = this;
            newFormQuestionManagement.Show();
        }

        private void presentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenting newFormPresenting = new Presenting();
            newFormPresenting.MdiParent = this;
            newFormPresenting.Show();
        }
    }
}
