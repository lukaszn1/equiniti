using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Interview.Models.Operations
{
    public class Operation
    {
        public Guid Id { get; set; }

        public int ApplicationId { get; set; }

        public OperationType Type { get; set; }

        public OperationSummary Summary { get; set; }

        public double Amount { get; set; }

        public DateTime? PostingDate { get; set; }

        public bool IsCleared { get; set; }

        public DateTime? ClearedDate { get; set; }
    }
}