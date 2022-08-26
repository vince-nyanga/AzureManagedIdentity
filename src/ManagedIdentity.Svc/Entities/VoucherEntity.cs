using Azure;
using Azure.Data.Tables;

namespace ManagedIdentity.Svc.Entities
{
    public class VoucherEntity : ITableEntity
    {
        public string PartitionKey { get; set; }

        public string RowKey { get; set; }

        public string? RedeemedBy { get; set; }

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }
    }
}
