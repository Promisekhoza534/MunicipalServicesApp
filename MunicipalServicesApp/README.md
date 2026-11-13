# MUNICIPAL SERVICES APPLICATION

**Student Name:** Promise Karabo Khoza  
**Student Number:** ST10530868  
**Module:** Advanced Application Development (AAPD7112/w)  
**Programming Language:** C#  
**Development Environment:** Microsoft Visual Studio  
**Application Type:** Windows Forms Desktop Application  

---

# 1. Project Overview

The Municipal Services Application is a desktop application developed using C# Windows Forms. The purpose of the application is to provide community members with a simple way to interact with municipal services.

The application focuses on three main areas: reporting municipal issues, viewing local events and announcements, and tracking service requests.

The project also demonstrates the practical implementation of different data structures and algorithms. These structures help organise information, search for records, manage priorities and represent connections between municipal service request stages.

The application was developed in stages, with each section contributing to the overall functionality of the system. The user interface was also improved following lecturer feedback to make the application more consistent and easier to use.



# 2. Technologies Used

The following technologies and tools were used:

| Technology | Purpose |
|---|---|
| C# | Main programming language |
| Windows Forms | Development of the desktop user interface |
| Microsoft Visual Studio | Development and debugging environment |
| .NET Framework | Application development platform |
| Git | Source code version control |
| GitHub | Online source code repository |

# 3. Application Features

## 3.1 Report Issues

The Report Issues section allows community members to report municipal problems.

Users can provide the location of an issue, select a category, enter a description and attach a supporting file.

The application includes input validation to ensure that required information is provided. It also checks for similar reports using the location and category.

Main functionality:

- Enter the location of an issue.
- Select an issue category.
- Provide a description.
- Attach a supporting document or image.
- Validate required information.
- Submit an issue.
- Check for similar reports.



## 3.2 Local Events and Announcements

The Local Events and Announcements section allows users to discover and search for community events.

Users can search using event categories and dates. The application also provides recommendations based on previous search preferences.

The section uses several data structures to organise event information and manage search activity.

Main functionality:

- Display available community events.
- Search for events using categories.
- Search for events using dates.
- Organise events by date and category.
- Track recently viewed events.
- Manage events using queues.
- Provide recommendations based on previous searches.

The application contains sample events such as Community Clean-Up, Municipal Health Awareness Day, Small Business Information Session, Recycling Awareness Campaign and Community Safety Meeting.


## 3.3 Service Request Status

The Service Request Status section allows users to search for municipal service requests using unique reference numbers.

Each service request contains:

- Request ID.
- Title.
- Description.
- Location.
- Current status.
- Priority.
- Date submitted.
- Status history.

The application includes the following sample requests:

| Request ID | Request | Status | Priority |
|---|---|---|---|
| SR1001 | Water Leak | Submitted | High |
| SR1002 | Street Light Repair | In Progress | Medium |
| SR1003 | Road Damage | Completed | Low |

Users can search for a specific service request using its unique reference number. The application uses a Red-Black Tree to perform the actual request search. Users can also display all available requests, with a Max Heap used to arrange them according to priority, placing high-priority requests before medium- and low-priority requests.



# 4. Data Structures and Algorithms

Different data structures and algorithms were implemented to solve specific problems in the application.

## 4.1 Basic Binary Tree

A binary tree is a structure where each node can have a maximum of two child nodes. The application uses a tree node structure containing a service request and references to left and right child nodes.

## 4.2 Binary Search Tree (BST)

The Binary Search Tree organises service requests according to their unique request IDs.

Smaller IDs are placed on the left, while larger IDs are placed on the right. The tree supports insertion and searching.

## 4.3 AVL Tree

The AVL Tree is a self-balancing binary search tree.

The implementation includes LL, RR, LR and RL rotations to maintain balance after insertion. This helps keep searching efficient as the number of requests increases.

## 4.4 Red-Black Tree

The Red-Black Tree uses red and black node colours to maintain balance.

The implementation includes insertion, rotations and balancing rules. It is used by the Service Request Status form to search for requests using their unique reference numbers.

The application populates the Binary Search Tree, AVL Tree and Red-Black Tree with the sample service requests. The Red-Black Tree is used by the Service Request Status form when searching for a specific request. The other tree implementations demonstrate different approaches to organising and searching service request records.

## 4.5 Max Heap

The Max Heap organises service requests according to priority.

The application assigns the following numerical values:

| Priority | Value |
|---|---:|
| High | 3 |
| Medium | 2 |
| Low | 1 |

The highest-priority request is removed first and displayed before lower-priority requests.

When the user selects Show All, the application uses the Max Heap to display service requests according to their priority. High-priority requests are displayed before medium- and low-priority requests.

## 4.6 Graphs

A graph represents connections between different service request workflow stages.

The application uses an adjacency list to represent connections between:

- Submitted.
- Assigned.
- In Progress.
- Completed.
- Rejected.

These connections represent the possible progression of a service request through the workflow.

## 4.7 Breadth-First Search (BFS)

BFS explores connected graph vertices level by level. The application uses a queue to manage the order in which workflow stages are visited.

## 4.8 Depth-First Search (DFS)

DFS explores one path as far as possible before returning to explore other available paths. The application uses a recursive method to perform this traversal.

## 4.9 Minimum Spanning Tree (MST)

Prim's algorithm is implemented to demonstrate a Minimum Spanning Tree for a sample municipal network.

The network contains Municipal Depot, Soshanguve, Pretoria North, Hammanskraal and Community Centre.

The algorithm selects connections with minimum total illustrative weight without creating cycles. The sample network produces a total weight of 12.

The weights are illustrative values and do not represent actual geographical distances.



# 5. Project File Structure

The project contains separate classes for the main application forms, service request model and data structure implementations.

Important files include:

| File | Purpose |
|---|---|
| Form1.cs | Main application menu |
| ReportIssuesForm.cs | Report Issues functionality |
| LocalEventsForm.cs | Local Events and Announcements functionality |
| EventItem.cs | Event information model |
| PriorityEventQueue.cs | Priority queue implementation for events |
| ServiceRequest.cs | Service request model |
| ServiceRequestStatusForm.cs | Service Request Status interface |
| ServiceRequestBinarySearchTree.cs | Binary Search Tree implementation |
| ServiceRequestAVLTree.cs | AVL Tree implementation |
| ServiceRequestRedBlackTree.cs | Red-Black Tree implementation |
| ServiceRequestMaxHeap.cs | Max Heap implementation |
| ServiceRequestGraph.cs | Graph, BFS and DFS implementation |
| MunicipalNetworkMST.cs | Prim's Minimum Spanning Tree implementation |



# 6. How to Compile and Run the Application

The following steps explain how to open and run the application.

1. Install Microsoft Visual Studio with the .NET desktop development workload.
2. Clone or download the project from the GitHub repository.
3. Open the project solution file in Visual Studio.
4. Allow Visual Studio to load the project.
5. Select Build from the Visual Studio menu.
6. Select Build Solution.
7. Check the Error List to confirm that there are no build errors.
8. Press F5 or select Start to run the application.

The target framework can be checked in the project properties under the Application section.



# 7. How to Use the Application

## Step 1: Open the Application

Run the application in Visual Studio. The main menu will display the three available sections.

## Step 2: Report an Issue

Select Report Issues, complete the required fields, attach a file if necessary and submit the issue.

## Step 3: Search for Local Events

Select Local Events and Announcements. Search for events using the available category and date options.

## Step 4: View Recommendations

Perform multiple searches to allow the application to display recommendations based on previous search preferences.

## Step 5: Track a Service Request

Select Service Request Status and enter a reference number such as SR1001.

Select Search to view the request information and status history.

## Step 6: Display All Requests

Select Show All to display the available service requests according to priority.

# 8. Testing

The application was tested to confirm that its main features, user interface and algorithms work as expected.

| Test | Expected Result | Outcome |
|---|---|---|
| Open Report Issues | Report Issues form opens | Successful |
| Submit an issue | Issue is validated and submitted successfully | Successful |
| Open Local Events | Local Events form opens | Successful |
| Search for an event | Matching event results are displayed | Successful |
| View recommendations | Recommendations appear after multiple searches | Successful |
| Open Service Request Status | Status form opens | Successful |
| Search SR1001 | Water Leak request appears | Successful |
| Search SR1002 | Street Light Repair request appears | Successful |
| Search SR1003 | Road Damage request appears | Successful |
| Search SR9999 | Request-not-found message appears | Successful |
| Show All | Requests appear in priority order | Successful |
| View BFS | Workflow traversal is displayed | Successful |
| View DFS | Workflow traversal is displayed | Successful |
| View MST | Municipal network and total weight are displayed | Successful |
| Navigate between forms | The correct application forms open | Successful |
| Build the project | Project builds without errors | Successful |

The user interfaces were also improved following lecturer feedback. The Main Menu, Report Issues, Local Events and Service Request Status forms were updated with consistent fonts, colours, headings, buttons and control layouts.

# 9. Limitations

The current application uses sample service request information stored in memory. It does not yet use a permanent database to store and retrieve service requests.

The municipal network uses illustrative weights rather than actual geographical distances.

The application does not currently provide a direct integration between reported issues and the service request tracking section. It also does not include a live municipal backend or real-time updates from municipal systems.

# 10. Future Improvements

Although the application currently supports its main features, the following improvements could be considered in future development:

- Connecting the application to Microsoft SQL Server for permanent data storage.
- Allowing reported issues to become trackable service requests.
- Adding user authentication and role-based access.
- Allowing municipal employees to update service request statuses.
- Introducing notifications for service request updates.
- Using real municipal location data.
- Further refining the user interface based on user feedback and usability testing.
- Adding automated testing to improve software quality.

# 11. GitHub Repository

The complete project source code is available on GitHub:

https://github.com/Promisekhoza534/MunicipalServicesApp

# 12. Conclusion

The Municipal Services Application demonstrates how C# Windows Forms can be used to develop a system that supports municipal service activities.

The project combines issue reporting, local event information and service request tracking. It also demonstrates the practical implementation of different data structures and algorithms.

Developing the application improved my understanding of programming, data organisation, searching, priority management, graph algorithms, testing and problem-solving.

The project also provided practical experience in improving an application based on lecturer feedback. The user interface was refined across the main sections, and the application was tested to confirm that the main features continued to work correctly.
