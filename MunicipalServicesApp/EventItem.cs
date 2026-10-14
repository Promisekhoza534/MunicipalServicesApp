using System;

namespace MunicipalServicesApp
{
    public class EventItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public DateTime EventDate { get; set; }

        public string Location { get; set; }

        public EventItem(string title, string description, string category,
                         DateTime eventDate, string location)
        {
            Title = title;
            Description = description;
            Category = category;
            EventDate = eventDate;
            Location = location;
        }

        public override string ToString()
        {
            return EventDate.ToString("dd/MM/yyyy") + " - " +
                   Title + " | " +
                   Category + " | " +
                   Location;
        }
    }
}