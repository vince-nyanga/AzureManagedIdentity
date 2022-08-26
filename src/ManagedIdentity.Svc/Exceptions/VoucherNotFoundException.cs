namespace ManagedIdentity.Svc.Exceptions
{
    public class VoucherNotFoundException : Exception
    {
        public VoucherNotFoundException(string code)
            : base($"Voucher with code '{code}' not found")
        {

        }
    }
}
