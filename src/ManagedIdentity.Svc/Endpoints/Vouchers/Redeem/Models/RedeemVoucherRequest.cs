using FluentValidation;

namespace ManagedIdentity.Svc.Endpoints.Vouchers.Redeem.Models
{
    public class RedeemVoucherRequest
    {
        /// <summary>
        /// Voucher code
        /// </summary>
        public string Code { get; set; }


        /// <summary>
        /// Email address of user redeeming the voucher
        /// </summary>
        public string RedeemerEmail { get; set; }
    }
}
