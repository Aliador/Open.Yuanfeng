using System;
using System.Windows.Forms;
using Yuanfeng.Smarty;

namespace Open.Yuanfeng.Windows
{
    public partial class BugReportForm : Form
    {
        public BugReportForm()
        {
            InitializeComponent();
        }

        private Exception exception;

        public void ShowDialog(Exception exception)
        {
            this.exception = exception; this.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SimpleConsole.WriteLine(this.tbReport.Text);
            SimpleConsole.WriteLine(exception);

            if (this.cbRestart.Checked) Application.Restart();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (exception != null)
            {
                this.tbDetail.AppendText(exception.Message);
                this.tbDetail.AppendText(exception.StackTrace);
            }

            if (this.Height < 400) this.Height += 120; else this.Height -= 120;
        }
    }
}
