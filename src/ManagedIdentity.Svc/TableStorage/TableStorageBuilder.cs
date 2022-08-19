using Ardalis.GuardClauses;
using Azure.Data.Tables;
using Azure.Identity;

namespace ManagedIdentity.Svc.TableStorage
{
    public class TableStorageBuilder
    {
        private readonly Uri _uri;
        private readonly List<string> _tableNames = new();

        private TableStorageBuilder(Uri uri)
        {
            _uri = uri;
        }

        public static TableStorageBuilder UsingUri(string uri)
        {
            Guard.Against.NullOrEmpty(uri);

            if (Uri.TryCreate(uri, UriKind.Absolute, out var tableUri))
            {
                return new TableStorageBuilder(tableUri);
            }
            else
            {
                throw new ArgumentException("Invalid uri", nameof(uri));
            }
        }

        public TableStorageBuilder WithTable(string tableName)
        {
            Guard.Against.NullOrEmpty(tableName);

            _tableNames.Add(tableName);
            return this;
        }

        public ITableStorage Build()
        {
            var tableServiceClient = new TableServiceClient(_uri, new DefaultAzureCredential());
            foreach (var table in _tableNames)
            {
                tableServiceClient.CreateTableIfNotExists(table);
            }
            return new TableStorage(tableServiceClient);
        }
    }
}
