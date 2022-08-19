using Azure.Data.Tables;

namespace ManagedIdentity.Svc.TableStorage
{
    public interface ITableStorage
    {
        TableClient GetTable(string tableName);
    }

    public class TableStorage : ITableStorage
    {
        private readonly TableServiceClient _tableServiceClient;

        public TableStorage(TableServiceClient tableServiceClient)
        {
            _tableServiceClient = tableServiceClient;
        }

        public TableClient GetTable(string tableName)
        {
            return _tableServiceClient.GetTableClient(tableName);
        }
    }
}
