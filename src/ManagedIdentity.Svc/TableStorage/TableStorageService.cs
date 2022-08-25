using Azure.Data.Tables;

namespace ManagedIdentity.Svc.TableStorage
{
    public sealed class TableStorageService : ITableStorageService
    {
        private readonly TableServiceClient _tableServiceClient;

       
        public TableStorageService(TableServiceClient tableServiceClient)
        {
            _tableServiceClient = tableServiceClient;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public TableClient EnsureTable(string tableName)
        {
            ArgumentNullException.ThrowIfNull(tableName, nameof(tableName));

            var table = _tableServiceClient.GetTableClient(tableName);
            table.CreateIfNotExists();
           return table;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public TableClient GetTable(string tableName)
        {
            ArgumentNullException.ThrowIfNull(tableName, nameof(tableName));

            return _tableServiceClient.GetTableClient(tableName);
        }
    }
}
