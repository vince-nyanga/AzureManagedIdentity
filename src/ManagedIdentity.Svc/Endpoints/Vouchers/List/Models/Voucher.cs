namespace ManagedIdentity.Svc.Endpoints.Vouchers.List.Models
{
    public class Voucher
    {
        public string Code { get; set; }

        public string? RedeemedBy { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
