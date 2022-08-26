using FluentValidation;
using MediatR;

namespace ManagedIdentity.Svc.Endpoints.Vouchers.Redeem.Command
{
    public record RedeemVoucher : IRequest
    {
        public string Code { get; init; }
        public string RedeemerEmail { get; init; }
    }

    public class RedeemVoucherValidator : AbstractValidator<RedeemVoucher>
    {
        public RedeemVoucherValidator()
        {
            RuleFor(x => x.RedeemerEmail)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Code)
                .NotEmpty()
                .Matches("^[A-Z|0-9]{4}-[A-Z|0-9]{4}-[A-Z|0-9]{4}-[A-Z|0-9]{4}$")
                .WithMessage("Invalid voucher code.");
        }
    }
}
