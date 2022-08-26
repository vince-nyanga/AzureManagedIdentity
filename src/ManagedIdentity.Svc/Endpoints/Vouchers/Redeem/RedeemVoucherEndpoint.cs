using Ardalis.ApiEndpoints;
using Azure;
using FluentValidation;
using ManagedIdentity.Svc.Endpoints.Vouchers.Redeem.Command;
using ManagedIdentity.Svc.Endpoints.Vouchers.Redeem.Models;
using ManagedIdentity.Svc.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ManagedIdentity.Svc.Endpoints.Vouchers.Redeem
{
    [Route("api/v1/vouchers")]
    public class RedeemVoucherEndpoint : EndpointBaseAsync
        .WithRequest<RedeemVoucherRequest>
        .WithActionResult
    {
        private readonly IMediator _mediator;

        public RedeemVoucherEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("redeem")]
        [SwaggerOperation(
           Summary = "Redeem voucher",
           Description = "Redeem voucher",
           OperationId = "Voucher.Redeem",
           Tags = new[] { "Vouchers" })
       ]
        public override async Task<ActionResult> HandleAsync(RedeemVoucherRequest request, CancellationToken cancellationToken = default)
        {

            RedeemVoucher command = new()
            {
                Code = request.Code,
                RedeemerEmail = request.RedeemerEmail
            };

            await _mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}
