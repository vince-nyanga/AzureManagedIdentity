using ManagedIdentity.Svc.TableStorage;

namespace ManagedIdentity.Svc.Extenstions
{
    public static class ServiceCollectionExtension
    {
        public static void AddTableStorage(this IServiceCollection services, IConfiguration configuration)
        {
            var tableStorageUri = configuration["TableStorageUri"];
            var tableStorage = TableStorageBuilder.UsingUri(tableStorageUri)
                .WithTable("todos")
                .Build();
            services.AddSingleton<ITableStorage>(tableStorage);
        }
    }
}
