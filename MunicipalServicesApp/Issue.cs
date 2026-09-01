using System;

namespace MunicipalServicesApp
{
    public class Issue
    {
        public string Location { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string Attachment { get; set; }

        public DateTime DateReported { get; set; }
    }
}