using Azure.Data.Tables;
using Azure.Identity;
using ManagedIdentity.Svc.TableStorage;

namespace ManagedIdentity.Svc.Extenstions
{
    public static class ServiceCollectionExtension
    {
        public static void AddTableStorage(this IServiceCollection services, IConfiguration configuration)
        {
            var tableStorageUri = configuration["TableStorageUri"];

            if (Uri.TryCreate(tableStorageUri, UriKind.Absolute, out var tableUri))
            {
                var tableServiceClient = new TableServiceClient(tableUri, new DefaultAzureCredential());
                services.AddSingleton<ITableStorageService>(new TableStorageService(tableServiceClient));
                services.AddTransient<ITableStorageRepository, TableStorageRepository>();
            }
            else
            {
                throw new Exception("Invalid table storage URI");
            }
        }
    }
}
