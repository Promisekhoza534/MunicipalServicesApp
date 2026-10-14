using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssuesForm : Form
    {
        private List<Issue> reportedIssues = new List<Issue>();

        public ReportIssuesForm()
        {
            InitializeComponent();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblAttachedFile.Text = openFileDialog1.FileName;

                UpdateProgress();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Check location
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the location of the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLocation.Focus();
                return;
            }

            // Check category
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select an issue category.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategory.Focus();
                return;
            }

            // Check description
            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show(
                    "Please provide a description of the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                rtbDescription.Focus();
                return;
            }

            // Create a new issue
            Issue newIssue = new Issue();

            newIssue.Location = txtLocation.Text.Trim();
            newIssue.Category = cmbCategory.SelectedItem.ToString();
            newIssue.Description = rtbDescription.Text.Trim();
            newIssue.Attachment = lblAttachedFile.Text;
            newIssue.DateReported = DateTime.Now;

            // Check if a similar issue already exists
            bool similarIssueFound = false;

            foreach (Issue issue in reportedIssues)
            {
                if (issue.Location.Equals(
                    newIssue.Location,
                    StringComparison.OrdinalIgnoreCase)
                    && issue.Category == newIssue.Category)
                {
                    similarIssueFound = true;
                    break;
                }
            }

            // Store the issue
            reportedIssues.Add(newIssue);

            // Show appropriate message
            if (similarIssueFound)
            {
                MessageBox.Show(
                    "A similar issue has already been reported in this area. " +
                    "Your report has been added to the community issue.",
                    "Community Issue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "Your issue has been reported successfully!",
                    "Report Submitted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 mainMenu = new Form1();

            mainMenu.Show();

            this.Close();
        }

        private void UpdateProgress()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                progress += 25;
            }

            if (cmbCategory.SelectedIndex != -1)
            {
                progress += 25;
            }

            if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                progress += 25;
            }

            if (lblAttachedFile.Text != "No file selected")
            {
                progress += 25;
            }

            progressReport.Value = progress;
            lblProgress.Text = "Report Progress: " + progress + "%";
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
        
            UpdateProgress();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            UpdateProgress();
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void ReportIssuesForm_Load(object sender, EventArgs e)
        {

        }
    }
    }
    
