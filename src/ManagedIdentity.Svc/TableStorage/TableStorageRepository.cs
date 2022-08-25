using Azure;
using Azure.Data.Tables;
using ManagedIdentity.Svc.Exceptions;
using System.Collections.Immutable;

namespace ManagedIdentity.Svc.TableStorage
{
    public class TableStorageRepository : ITableStorageRepository
    {
        private readonly ITableStorageService _tableStorageService;

        public TableStorageRepository(ITableStorageService tableStorageService)
        {
            _tableStorageService = tableStorageService;
        }
           
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async virtual Task Add<TEntity>(TEntity entity, string? tableName = null)
            where TEntity : class, ITableEntity, new()
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            var name = GetTableName<TEntity>(tableName);
            var tableClient = _tableStorageService.EnsureTable(name);

            try
            {
                await tableClient.AddEntityAsync(entity);
            }
            catch (RequestFailedException)
            {
                throw new EntityAlreadyExistsException();
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <exception cref="RequestFailedException"
        public async virtual Task<TEntity?> Get<TEntity>(string partitionKey, string rowKey, string? tableName = null)
           where TEntity : class, ITableEntity, new()
        {
            ArgumentNullException.ThrowIfNull(partitionKey, nameof(partitionKey));
            ArgumentNullException.ThrowIfNull(rowKey, nameof(rowKey));

            var name = GetTableName<TEntity>(tableName);
            var tableClient = _tableStorageService.GetTable(name);

            try
            {
                var response = await tableClient.GetEntityAsync<TEntity>(partitionKey, rowKey);

                return response.Value;
            }
            catch (RequestFailedException)
            {
                return null;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async virtual Task<IReadOnlyCollection<TEntity>> GetAll<TEntity>(string partitionKey, string? tableName)
            where TEntity : class, ITableEntity, new()
        {
            ArgumentNullException.ThrowIfNull(partitionKey, nameof(partitionKey));

            var name = GetTableName<TEntity>(tableName);
            var tableClient = _tableStorageService.GetTable(name);

            try
            {
                List<TEntity> entities = new();

                var queryResults =  tableClient.Query<TEntity>(x => x.PartitionKey == partitionKey);

                foreach (var entity in queryResults)
                {
                    entities.Add(entity);
                }

                return entities.ToImmutableList();
            }
            catch (RequestFailedException)
            {
                return new List<TEntity>().ToImmutableList();
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async virtual Task Upsert<TEntity>(TEntity entity, string? tableName = null)
            where TEntity : class, ITableEntity, new()
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            var name = GetTableName<TEntity>(tableName);
            var tableClient = _tableStorageService.EnsureTable(name);

            await tableClient.UpsertEntityAsync(entity);
        }


        private static string GetTableName<TEntity>(string? tableName)
        {
            return string.IsNullOrEmpty(tableName)
                ? typeof(TEntity).Name.Replace("Entity", "")
                : tableName;
        }
    }
}
