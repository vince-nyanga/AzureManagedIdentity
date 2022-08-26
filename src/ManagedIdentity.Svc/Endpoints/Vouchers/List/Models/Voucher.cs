namespace ManagedIdentity.Svc.Endpoints.Vouchers.List.Models
{
    public class Voucher
    {
        /// <summary>
        /// The voucher code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Email address of user who redeemed the voucher
        /// </summary>
        public string? RedeemedBy { get; set; }

        /// <summary>
        /// Last modified date
        /// </summary>
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
