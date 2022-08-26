using Ardalis.ApiEndpoints;
using Azure;
using ManagedIdentity.Svc.Endpoints.Vouchers.Generate.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ManagedIdentity.Svc.Endpoints.Vouchers.Generate
{
    [Route("api/v1/vouchers")]
    public class GenerateVoucherEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult
    {
        private readonly IMediator _mediator;

        public GenerateVoucherEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("generate")]
        [SwaggerOperation(
            Summary = "Generates a new voucher",
            Description = "Generates a new voucher",
            OperationId = "Voucher.Generate",
            Tags = new[] { "VoucherEndpoint" })
        ]
        public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new GenerateVoucher(), cancellationToken);

            return Ok();
        }
    }
}
