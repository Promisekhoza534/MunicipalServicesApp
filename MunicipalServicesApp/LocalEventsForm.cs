
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LocalEventsForm : Form
    {
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

        private Dictionary<string, int> searchPreferences =
            new Dictionary<string, int>();

        private int totalSearches = 0;
        private EventItem mostRecentlyFoundEvent = null;

        public LocalEventsForm()
        {
            InitializeComponent();
        }

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

            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");

            foreach (string category in eventCategories)
            {
                cmbCategory.Items.Add(category);
            }

            cmbCategory.SelectedIndex = 0;

            DisplayAllEvents();

            foreach (KeyValuePair<DateTime, List<EventItem>> entry in eventsByDate)
            {
                foreach (EventItem eventItem in entry.Value)
                {
                    eventQueue.Enqueue(eventItem);
                    recentEvents.Push(eventItem);
                }
            }

            priorityEventQueue.Enqueue(
                eventsByCategory["Community"][0], 1);

            priorityEventQueue.Enqueue(
                eventsByCategory["Health"][0], 2);

            priorityEventQueue.Enqueue(
                eventsByCategory["Business"][0], 3);


            ProcessPriorityEvents();
        }



        private void SearchEvents()
        {
            lstEvents.Items.Clear();

            recentEvents.Clear();
            eventQueue.Clear();

            string selectedCategory = cmbCategory.SelectedItem.ToString();
            DateTime selectedDate = dtpEventDate.Value.Date;

            totalSearches++;

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

       
            while (eventQueue.Count > 0)
            {
                EventItem nextEvent = eventQueue.Dequeue();
                lstEvents.Items.Add(nextEvent);
            }


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

            if (lstEvents.Items.Count == 0)
            {
                lstEvents.Items.Add(
                    "No events found for the selected category and date.");
            }

            if (totalSearches >= 2)
            {
                ShowRecommendations();

            }
            else
            {
                lstRecommendations.Items.Clear();
                lstRecommendations.Items.Add(
                    "Search for more events to receive recommendations.");
            }
        }


        private void ProcessPriorityEvents()
        {
            while (priorityEventQueue.Count > 0)
            {
                EventItem priorityEvent = priorityEventQueue.Dequeue();

                System.Diagnostics.Debug.WriteLine(
                    "Priority event: " + priorityEvent.Title);
            }
        }


        private void ShowRecommendations()
        {
            lstRecommendations.Items.Clear();

            if (searchPreferences.Count == 0)
            {
                lstRecommendations.Items.Add(
                    "Search for events to receive recommendations.");
                return;
            }

            string preferredCategory = null;
            int highestSearchCount = 0;

            foreach (KeyValuePair<string, int> preference in searchPreferences)
            {
                if (preference.Value > highestSearchCount)
                {
                    highestSearchCount = preference.Value;
                    preferredCategory = preference.Key;
                }
            }

            if (preferredCategory != null &&
                eventsByCategory.ContainsKey(preferredCategory))
            {
                foreach (EventItem eventItem in eventsByCategory[preferredCategory])
                {
                    if (eventItem.EventDate.Date >= DateTime.Today)
                    {
                        lstRecommendations.Items.Add(eventItem);
                    }
                }
            }

            if (lstRecommendations.Items.Count == 0)
            {
                lstRecommendations.Items.Add(
                    "No upcoming recommendations are available.");
            }
        }

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
                eventsByCategory.Add(eventItem.Category, new List<EventItem>());
            }

            eventsByCategory[eventItem.Category].Add(eventItem);

            eventCategories.Add(eventItem.Category);
        }

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEvents();
        }
    }
}
