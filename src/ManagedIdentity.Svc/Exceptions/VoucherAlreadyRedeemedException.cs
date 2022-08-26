namespace ManagedIdentity.Svc.Exceptions
{
    public class VoucherAlreadyRedeemedException : Exception
    {
        public VoucherAlreadyRedeemedException(string code)
            : base($"Voucher with code '{code}' has already been redeemed")
        {

        }
    }
}
