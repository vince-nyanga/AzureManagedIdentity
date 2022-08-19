using ManagedIdentity.Svc.Models;

namespace ManagedIdentity.Svc.Repositories
{
    public interface ITodoRepository
    {
        Task Add(TodoItem item);
    }
}
