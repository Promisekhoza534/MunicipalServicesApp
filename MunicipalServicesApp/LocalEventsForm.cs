
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LocalEventsForm : Form
    {
        // Data structures used to organise events
        private SortedDictionary<DateTime, List<EventItem>> eventsByDate =
            new SortedDictionary<DateTime, List<EventItem>>();

        private Dictionary<string, List<EventItem>> eventsByCategory =
            new Dictionary<string, List<EventItem>>();

        private HashSet<string> eventCategories =
            new HashSet<string>();

        private Stack<EventItem> recentEvents =
            new Stack<EventItem>();

        private Queue<EventItem> eventQueue =
            new Queue<EventItem>();

        private PriorityEventQueue priorityEventQueue =
            new PriorityEventQueue();

        // Stores the categories searched by the user
        private Dictionary<string, int> searchPreferences =
            new Dictionary<string, int>();

        private int totalSearches = 0;

        private EventItem mostRecentlyFoundEvent = null;

        public LocalEventsForm()
        {
            InitializeComponent();
        }

        // Load sample events when the form opens
        private void LocalEventsForm_Load(object sender, EventArgs e)
        {
            AddEvent(new EventItem(
                "Community Clean-Up",
                "Residents are invited to participate in a community clean-up campaign.",
                "Community",
                new DateTime(2026, 10, 20),
                "Soshanguve Community Hall"));

            AddEvent(new EventItem(
                "Municipal Health Awareness Day",
                "Health and wellness information will be provided to community members.",
                "Health",
                new DateTime(2026, 10, 24),
                "Pretoria Community Centre"));

            AddEvent(new EventItem(
                "Small Business Information Session",
                "Information about municipal support services available to local businesses.",
                "Business",
                new DateTime(2026, 10, 28),
                "Municipal Offices"));

            AddEvent(new EventItem(
                "Recycling Awareness Campaign",
                "Residents can learn more about recycling and responsible waste management.",
                "Environment",
                new DateTime(2026, 11, 3),
                "Community Library"));

            AddEvent(new EventItem(
                "Community Safety Meeting",
                "Residents can discuss local safety concerns and community initiatives.",
                "Safety",
                new DateTime(2026, 11, 8),
                "Local Community Hall"));

            // Populate category dropdown
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");

            foreach (string category in eventCategories)
            {
                cmbCategory.Items.Add(category);
            }

            cmbCategory.SelectedIndex = 0;

            // Display all available sample events
            DisplayAllEvents();

            // Populate queue and stack
            foreach (KeyValuePair<DateTime, List<EventItem>> entry in eventsByDate)
            {
                foreach (EventItem eventItem in entry.Value)
                {
                    eventQueue.Enqueue(eventItem);
                    recentEvents.Push(eventItem);
                }
            }

            // Add selected events to the priority queue
            priorityEventQueue.Enqueue(
                eventsByCategory["Community"][0], 1);

            priorityEventQueue.Enqueue(
                eventsByCategory["Health"][0], 2);

            priorityEventQueue.Enqueue(
                eventsByCategory["Business"][0], 3);

            ProcessPriorityEvents();

            // Initial recommendation message
            lstRecommendations.Items.Clear();
            lstRecommendations.Items.Add(
                "Search for events to receive recommendations.");
        }

        // Search events by selected category and date
        private void SearchEvents()
        {
            lstEvents.Items.Clear();

            recentEvents.Clear();
            eventQueue.Clear();

            string selectedCategory =
                cmbCategory.SelectedItem == null
                ? "All Categories"
                : cmbCategory.SelectedItem.ToString();

            DateTime selectedDate = dtpEventDate.Value.Date;

            totalSearches++;

            // Record the user's category preference
            if (selectedCategory != "All Categories")
            {
                if (!searchPreferences.ContainsKey(selectedCategory))
                {
                    searchPreferences.Add(selectedCategory, 1);
                }
                else
                {
                    searchPreferences[selectedCategory]++;
                }
            }

            // Find matching events
            foreach (KeyValuePair<DateTime, List<EventItem>> entry in eventsByDate)
            {
                foreach (EventItem eventItem in entry.Value)
                {
                    bool categoryMatches =
                        selectedCategory == "All Categories" ||
                        eventItem.Category == selectedCategory;

                    bool dateMatches =
                        eventItem.EventDate.Date == selectedDate;

                    if (categoryMatches && dateMatches)
                    {
                        recentEvents.Push(eventItem);
                        eventQueue.Enqueue(eventItem);
                    }
                }
            }

            // Display matching events using the queue
            while (eventQueue.Count > 0)
            {
                EventItem nextEvent = eventQueue.Dequeue();
                lstEvents.Items.Add(nextEvent);
            }

            // Record the most recently found event
            if (recentEvents.Count > 0)
            {
                mostRecentlyFoundEvent = recentEvents.Pop();

                System.Diagnostics.Debug.WriteLine(
                    "Most recent matching event: " +
                    mostRecentlyFoundEvent.Title);
            }
            else
            {
                mostRecentlyFoundEvent = null;
            }

            // Display message if no events match
            if (lstEvents.Items.Count == 0)
            {
                lstEvents.Items.Add(
                    "No events found for the selected category and date.");
            }

            // Generate recommendations after two searches
            if (totalSearches >= 2)
            {
                ShowRecommendations();
            }
            else
            {
                lstRecommendations.Items.Clear();

                lstRecommendations.Items.Add(
                    "Search again to receive recommendations.");
            }
        }

        // Process events in the priority queue
        private void ProcessPriorityEvents()
        {
            while (priorityEventQueue.Count > 0)
            {
                EventItem priorityEvent =
                    priorityEventQueue.Dequeue();

                System.Diagnostics.Debug.WriteLine(
                    "Priority event: " + priorityEvent.Title);
            }
        }

        // Generate recommendations based on search preferences
        private void ShowRecommendations()
        {
            lstRecommendations.Items.Clear();

            if (searchPreferences.Count == 0)
            {
                lstRecommendations.Items.Add(
                    "Select an event category to receive recommendations.");

                return;
            }

            string preferredCategory = null;
            int highestSearchCount = 0;

            // Find the most frequently searched category
            foreach (KeyValuePair<string, int> preference in searchPreferences)
            {
                if (preference.Value > highestSearchCount)
                {
                    highestSearchCount = preference.Value;
                    preferredCategory = preference.Key;
                }
            }

            // Display events from the preferred category
            if (preferredCategory != null &&
                eventsByCategory.ContainsKey(preferredCategory))
            {
                foreach (EventItem eventItem in eventsByCategory[preferredCategory])
                {
                    lstRecommendations.Items.Add(eventItem);
                }
            }

            if (lstRecommendations.Items.Count == 0)
            {
                lstRecommendations.Items.Add(
                    "No recommendations are available.");
            }
        }

        // Add an event to the relevant data structures
        private void AddEvent(EventItem eventItem)
        {
            DateTime date = eventItem.EventDate.Date;

            if (!eventsByDate.ContainsKey(date))
            {
                eventsByDate.Add(date, new List<EventItem>());
            }

            eventsByDate[date].Add(eventItem);

            if (!eventsByCategory.ContainsKey(eventItem.Category))
            {
                eventsByCategory.Add(
                    eventItem.Category,
                    new List<EventItem>());
            }

            eventsByCategory[eventItem.Category].Add(eventItem);

            eventCategories.Add(eventItem.Category);
        }

        // Display all sample events
        private void DisplayAllEvents()
        {
            lstEvents.Items.Clear();

            foreach (KeyValuePair<DateTime, List<EventItem>> entry in eventsByDate)
            {
                foreach (EventItem eventItem in entry.Value)
                {
                    lstEvents.Items.Add(eventItem);
                }
            }
        }

        // Search button event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEvents();
        }

        // Category dropdown event
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Category selection is handled when Search is clicked.
        }

        // Back button returns to the existing main menu
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Form1)
                {
                    form.Show();
                    break;
                }
            }

            this.Close();
        }

        // Designer event handlers
        private void label3_Click(object sender, EventArgs e)
        {
            // No action required.
        }

        private void lstRecommendations_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            // No action required.
        }
    }
}