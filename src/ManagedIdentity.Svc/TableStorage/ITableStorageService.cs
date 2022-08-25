using Azure.Data.Tables;

namespace ManagedIdentity.Svc.TableStorage
{
    public interface ITableStorageService
    {
        /// <summary>
        /// Gets an instance of a <see cref="TableClient"/>
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <returns>Instance of a <see cref="TableClient"/></returns>
        TableClient GetTable(string tableName);

        /// <summary>
        /// Gets an instance of a <see cref="TableClient"/>
        /// </summary>
        /// <remarks>
        /// If the table does not exist it will be created.
        /// </remarks>
        /// <param name="tableName">Table name</param>
        /// <returns>Instance of a <see cref="TableClient"/></returns>
        TableClient EnsureTable(string tableName);
    }
}
