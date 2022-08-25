using Azure.Data.Tables;

namespace ManagedIdentity.Svc.TableStorage
{
    public interface ITableStorageRepository
    {
        /// <summary>
        /// Adds an entity to a table.
        /// </summary>
        /// <typeparam name="TEntity">A class that extends <see cref="ITableEntity"/></typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="tableName">Optional table name. If not supplied the entity name will be used.</param>
        /// <returns><see cref="Task"/></returns>
        Task Add<TEntity>(TEntity entity, string? tableName=null)
            where TEntity : class, ITableEntity, new();

        /// <summary>
        /// Returns an entity from a table
        /// </summary>
        /// <typeparam name="TEntity">A class that extends <see cref="ITableEntity"/>.</typeparam>
        /// <param name="partitionKey">Partition key.</param>
        /// <param name="rowKey">Row key.</param>
        /// <param name="tableName">Optional table name. If not supplied the entity name will be used.</param>
        /// <returns>An entity.</returns>
        Task<TEntity?> Get<TEntity>(string partitionKey, string rowKey, string? tableName=null)
            where TEntity : class, ITableEntity, new();

        /// <summary>
        /// Returns a list of all entities in a partition key.
        /// </summary>
        /// <typeparam name="TEntity">A class that extends <see cref="ITableEntity"/>.</typeparam>
        /// <param name="partitionKey">Partition key.</param>
        /// <param name="tableName">Optional table name. If not supplied the entity name will be used.</param>
        /// <returns>List of entities.</returns>
        Task<IReadOnlyCollection<TEntity>> GetAll<TEntity>(string partitionKey, string? tableName=null)
            where TEntity : class, ITableEntity, new();

        /// <summary>
        /// Upserts an entity in a table.
        /// </summary>
        /// <typeparam name="TEntity">A class that extends <see cref="ITableEntity"/></typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="tableName">Optional table name. If not supplied the entity name will be used.</param>
        /// <returns><see cref="Task"/></returns>
        Task Upsert<TEntity>(TEntity entity, string? tableName=null)
            where TEntity : class, ITableEntity, new();
    }
}
