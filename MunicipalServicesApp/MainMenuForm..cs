using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            btnServiceStatus.Click += btnServiceRequestStatus_Click;
            btnServiceStatus.Enabled = true;
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            // Main menu loads here
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportForm = new ReportIssuesForm();

            reportForm.Show();

            this.Hide();
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            LocalEventsForm eventsForm = new LocalEventsForm();
            eventsForm.Show();
        }

        private void btnServiceRequestStatus_Click(object sender, EventArgs e)
        {
            ServiceRequestStatusForm statusForm =
                new ServiceRequestStatusForm();

            statusForm.Show();
            this.Hide();
        }
        private void lblTitle_Click(object sender, EventArgs e)
        {
            // No action needed when the title is clicked
        }

    }
}