using ManagedIdentity.Svc.Endpoints.Vouchers.List.Models;
using MediatR;

namespace ManagedIdentity.Svc.Endpoints.Vouchers.List.Query
{
    public record ListVouchers : IRequest<IEnumerable<Voucher>>
    {
    }
}
