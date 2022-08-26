using ManagedIdentity.Svc.Constants;
using ManagedIdentity.Svc.Entities;
using ManagedIdentity.Svc.TableStorage;
using ManagedIdentity.Svc.Utilities;
using MediatR;

namespace ManagedIdentity.Svc.Endpoints.Vouchers.Generate.Command
{
    public class GenerateVoucherHandler : AsyncRequestHandler<GenerateVoucher>
    {
        private readonly ITableStorageRepository _tableStorageRepository;

        public GenerateVoucherHandler(ITableStorageRepository tableStorageRepository)
        {
            _tableStorageRepository = tableStorageRepository;
        }

        protected override async Task Handle(GenerateVoucher request, CancellationToken cancellationToken)
        {
            var voucher = new VoucherEntity
            {
                PartitionKey = PartitionKey.ForVouchers,
                RowKey = VoucherCodeGenerator.Generate()
            };

            await _tableStorageRepository.Add(voucher);
        }
    }
}
