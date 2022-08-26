using ManagedIdentity.Svc.Constants;
using ManagedIdentity.Svc.Entities;
using ManagedIdentity.Svc.Exceptions;
using ManagedIdentity.Svc.TableStorage;
using MediatR;

namespace ManagedIdentity.Svc.Endpoints.Vouchers.Redeem.Command
{
    public class RedeemVoucherHandler : AsyncRequestHandler<RedeemVoucher>
    {
        private readonly ITableStorageRepository _tableStorageRepository;

        public RedeemVoucherHandler(ITableStorageRepository tableStorageRepository)
        {
            _tableStorageRepository = tableStorageRepository;
        }

        protected override async Task Handle(RedeemVoucher request, CancellationToken cancellationToken)
        {
            var voucher = await _tableStorageRepository.Get<VoucherEntity>(PartitionKey.ForVouchers, request.Code);

            if (voucher is null)
            {
                throw new VoucherNotFoundException(request.Code);
            }

            if (!string.IsNullOrEmpty(voucher.RedeemedBy))
            {
                throw new VoucherAlreadyRedeemedException(request.Code);
            }

            voucher.RedeemedBy = request.RedeemerEmail;

            await _tableStorageRepository.Upsert(voucher);
        }
    }
}
