using ManagedIdentity.Svc.Constants;
using ManagedIdentity.Svc.Endpoints.Vouchers.List.Models;
using ManagedIdentity.Svc.Entities;
using ManagedIdentity.Svc.TableStorage;
using MediatR;

namespace ManagedIdentity.Svc.Endpoints.Vouchers.List.Query
{
    public class ListVouchers : IRequest<IEnumerable<Voucher>>
    {
    }

    public class ListVouchersHandler : IRequestHandler<ListVouchers, IEnumerable<Voucher>>
    {
        private readonly ITableStorageRepository _tableStorageRepository;

        public ListVouchersHandler(ITableStorageRepository tableStorageRepository)
        {
            _tableStorageRepository = tableStorageRepository;
        }

        public async Task<IEnumerable<Voucher>> Handle(ListVouchers request, CancellationToken cancellationToken)
        {
            var entities = await _tableStorageRepository.GetAll<VoucherEntity>(PartitionKey.ForVouchers);

            return entities.Select(MapToVoucher);
        }

        private static Voucher MapToVoucher(VoucherEntity entity) => new()
        {
            Code = entity.RowKey,
            RedeemedBy = entity.RedeemedBy,
            ModifiedDate = entity.Timestamp
        };
       
    }
}
