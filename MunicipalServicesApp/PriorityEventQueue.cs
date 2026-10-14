using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public class PriorityEventQueue
    {
        private List<Tuple<EventItem, int>> items =
            new List<Tuple<EventItem, int>>();

        public void Enqueue(EventItem eventItem, int priority)
        {
            items.Add(new Tuple<EventItem, int>(eventItem, priority));
        }

        public EventItem Dequeue()
        {
            if (items.Count == 0)
            {
                return null;
            }

            int highestPriorityIndex = 0;

            for (int i = 1; i < items.Count; i++)
            {
                if (items[i].Item2 > items[highestPriorityIndex].Item2)
                {
                    highestPriorityIndex = i;
                }
            }

            EventItem selectedEvent =
                items[highestPriorityIndex].Item1;

            items.RemoveAt(highestPriorityIndex);

            return selectedEvent;
        }

        public int Count
        {
            get { return items.Count; }
        }
    }
}