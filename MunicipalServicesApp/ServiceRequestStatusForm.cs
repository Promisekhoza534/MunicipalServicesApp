
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ServiceRequestStatusForm : Form
    {
        private static List<ServiceRequest> requests =
            new List<ServiceRequest>();


        private ServiceRequestBinarySearchTree requestTree =
    new ServiceRequestBinarySearchTree();


        private ServiceRequestAVLTree avlRequestTree =
    new ServiceRequestAVLTree();


        private ServiceRequestRedBlackTree redBlackRequestTree =
    new ServiceRequestRedBlackTree();


        private ServiceRequestMaxHeap priorityHeap =
    new ServiceRequestMaxHeap();


        private ServiceRequestGraph requestGraph =
    new ServiceRequestGraph();

        private MunicipalNetworkMST municipalMST =
    new MunicipalNetworkMST();

        public ServiceRequestStatusForm()
        {
            InitializeComponent();

            LoadSampleRequests();

            foreach (ServiceRequest request in requests)
            {
                requestTree.Insert(request);
                avlRequestTree.Insert(request);
                redBlackRequestTree.Insert(request);
                priorityHeap.Insert(request);
            }

            btnSearch.Click += btnSearch_Click;
            btnShowAll.Click += btnShowAll_Click;
            btnBack.Click += btnBack_Click;

            DisplayRequests(requests);



        }

        private void LoadSampleRequests()
        {
            if (requests.Count > 0)
                return;

            requests.Add(new ServiceRequest
            {
                RequestId = "SR1001",
                Title = "Water Leak",
                Description = "A leaking water pipe was reported.",
                Location = "Soshanguve",
                Status = "Submitted",
                Priority = "High",
                DateSubmitted = DateTime.Now.AddDays(-3),
                StatusHistory = new List<string>
                {
                    "Request submitted",
                    "Waiting for assessment"
                }
            });

            requests.Add(new ServiceRequest
            {
                RequestId = "SR1002",
                Title = "Street Light Repair",
                Description = "A street light is not working.",
                Location = "Pretoria North",
                Status = "In Progress",
                Priority = "Medium",
                DateSubmitted = DateTime.Now.AddDays(-2),
                StatusHistory = new List<string>
                {
                    "Request submitted",
                    "Assigned to maintenance team",
                    "Repair in progress"
                }
            });

            requests.Add(new ServiceRequest
            {
                RequestId = "SR1003",
                Title = "Road Damage",
                Description = "A pothole was reported on the road.",
                Location = "Hammanskraal",
                Status = "Completed",
                Priority = "Low",
                DateSubmitted = DateTime.Now.AddDays(-7),
                StatusHistory = new List<string>
                {
                    "Request submitted",
                    "Assigned to road maintenance",
                    "Repair completed"
                }
            });
        }

        private void DisplayRequests(List<ServiceRequest> requestList)
        {
            dgvRequests.DataSource = null;

            dgvRequests.DataSource = requestList.Select(r => new
            {
                RequestID = r.RequestId,
                Title = r.Title,
                Location = r.Location,
                Status = r.Status,
                Priority = r.Priority,
                DateSubmitted = r.DateSubmitted.ToShortDateString()
            }).ToList();
        }



        private void DisplayRequestsByPriority()
        {
            ServiceRequestMaxHeap temporaryHeap =
                new ServiceRequestMaxHeap();

            foreach (ServiceRequest request in requests)
            {
                temporaryHeap.Insert(request);
            }

            List<ServiceRequest> sortedRequests =
                new List<ServiceRequest>();

            while (temporaryHeap.Count > 0)
            {
                ServiceRequest highest =
                    temporaryHeap.RemoveHighestPriority();

                if (highest != null)
                    sortedRequests.Add(highest);
            }

            DisplayRequests(sortedRequests);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string reference = txtRequestId.Text.Trim();

            if (string.IsNullOrWhiteSpace(reference))
            {
                MessageBox.Show("Please enter a request reference.");
                return;
            }

            ServiceRequest request = redBlackRequestTree.Search(reference);

            if (request == null)
            {
                MessageBox.Show("Request not found. Please check the reference.");
                txtRequestDetails.Clear();
                return;
            }

            DisplayRequests(new List<ServiceRequest> { request });

            txtRequestDetails.Text =
                "Request ID: " + request.RequestId + Environment.NewLine +
                "Title: " + request.Title + Environment.NewLine +
                "Description: " + request.Description + Environment.NewLine +
                "Location: " + request.Location + Environment.NewLine +
                "Status: " + request.Status + Environment.NewLine +
                "Priority: " + request.Priority + Environment.NewLine +
                "Date Submitted: " + request.DateSubmitted.ToShortDateString() +
                Environment.NewLine + Environment.NewLine +
                "Status History:" + Environment.NewLine +
                string.Join(Environment.NewLine, request.StatusHistory);

            txtRequestDetails.Text +=
    Environment.NewLine + Environment.NewLine +
    "Available Workflow Stages (BFS):" +
    Environment.NewLine +
    string.Join(" -> ",
        requestGraph.BreadthFirstSearch("Submitted")) +
    Environment.NewLine + Environment.NewLine +
    "Workflow Traversal (DFS):" +
    Environment.NewLine +
    string.Join(" -> ",
        requestGraph.DepthFirstSearch("Submitted"));


            txtRequestDetails.Text +=
    Environment.NewLine + Environment.NewLine +
    "Municipal Network - Minimum Spanning Tree:" +
    Environment.NewLine +
    string.Join(Environment.NewLine,
        municipalMST.BuildMinimumSpanningTree("Municipal Depot"));
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtRequestId.Clear();
            txtRequestDetails.Clear();

            DisplayRequestsByPriority();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 mainMenu = new Form1();
            mainMenu.Show();
            this.Close();
        }


        private void label3_Click(object sender, EventArgs e)
        {
            // No action required.
        }

        private void ServiceRequestStatusForm_Load(object sender, EventArgs e)
        {
            // No action required.
        }

        private void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }




}
