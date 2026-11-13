namespace MunicipalServicesApp
{
    partial class ServiceRequestStatusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblReference = new System.Windows.Forms.Label();
            this.lblStatusHeading = new System.Windows.Forms.Label();
            this.txtRequestId = new System.Windows.Forms.TextBox();
            this.txtRequestDetails = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblHeading.Location = new System.Drawing.Point(172, 28);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(700, 55);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Service Request Status";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblReference.Location = new System.Drawing.Point(56, 98);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(210, 23);
            this.lblReference.TabIndex = 1;
            this.lblReference.Text = "\tEnter Request Reference:";
            this.lblReference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatusHeading
            // 
            this.lblStatusHeading.AutoSize = true;
            this.lblStatusHeading.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusHeading.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStatusHeading.Location = new System.Drawing.Point(55, 564);
            this.lblStatusHeading.Name = "lblStatusHeading";
            this.lblStatusHeading.Size = new System.Drawing.Size(160, 28);
            this.lblStatusHeading.TabIndex = 2;
            this.lblStatusHeading.Text = "Request Details";
            this.lblStatusHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatusHeading.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtRequestId
            // 
            this.txtRequestId.BackColor = System.Drawing.Color.White;
            this.txtRequestId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequestId.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestId.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtRequestId.Location = new System.Drawing.Point(60, 135);
            this.txtRequestId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRequestId.Name = "txtRequestId";
            this.txtRequestId.Size = new System.Drawing.Size(614, 31);
            this.txtRequestId.TabIndex = 3;
            // 
            // txtRequestDetails
            // 
            this.txtRequestDetails.BackColor = System.Drawing.Color.White;
            this.txtRequestDetails.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtRequestDetails.Location = new System.Drawing.Point(51, 596);
            this.txtRequestDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRequestDetails.Multiline = true;
            this.txtRequestDetails.Name = "txtRequestDetails";
            this.txtRequestDetails.ReadOnly = true;
            this.txtRequestDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRequestDetails.Size = new System.Drawing.Size(562, 116);
            this.txtRequestDetails.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkBlue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(722, 135);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 40);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Track Request";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnShowAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Location = new System.Drawing.Point(60, 202);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(812, 40);
            this.btnShowAll.TabIndex = 6;
            this.btnShowAll.Text = "Show All Requests";
            this.btnShowAll.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(51, 737);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(176, 33);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "<<<Back To Main Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.GridColor = System.Drawing.Color.LightGray;
            this.dgvRequests.Location = new System.Drawing.Point(60, 325);
            this.dgvRequests.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersVisible = false;
            this.dgvRequests.RowHeadersWidth = 51;
            this.dgvRequests.RowTemplate.Height = 24;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(827, 214);
            this.dgvRequests.TabIndex = 8;
            this.dgvRequests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequests_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkBlue;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Service Requests";
            // 
            // ServiceRequestStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1105, 939);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtRequestDetails);
            this.Controls.Add(this.txtRequestId);
            this.Controls.Add(this.lblStatusHeading);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.lblHeading);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ServiceRequestStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServiceRequestStatusForm";
            this.Load += new System.EventHandler(this.ServiceRequestStatusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.Label lblStatusHeading;
        private System.Windows.Forms.TextBox txtRequestId;
        private System.Windows.Forms.TextBox txtRequestDetails;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Label label1;
    }
}