using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public class ServiceRequest
    {
        public string RequestId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime DateSubmitted { get; set; }

        public List<string> StatusHistory { get; set; }

        public ServiceRequest()
        {
            StatusHistory = new List<string>();
        }

        public override string ToString()
        {
            return RequestId + " - " + Title + " (" + Status + ")";
        }
    }
}