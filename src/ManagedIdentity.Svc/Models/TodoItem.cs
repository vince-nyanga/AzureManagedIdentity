using Azure;
using Azure.Data.Tables;

namespace ManagedIdentity.Svc.Models
{
    public class TodoItem : ITableEntity
    {
        public string Category { get; set; }
        public string Value { get; set; }
        public bool IsCompleted { get; set; }
        public string PartitionKey { get => Category; set => _ = Category; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public TodoItem(string category, string value)
        {
            Category = category;
            RowKey = Guid.NewGuid().ToString();
            Value = value;
        }
    }
}
