using Ardalis.ApiEndpoints;
using Azure;
using ManagedIdentity.Svc.Endpoints.Vouchers.List.Models;
using ManagedIdentity.Svc.Endpoints.Vouchers.List.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ManagedIdentity.Svc.Endpoints.Vouchers.List
{
    [Route("api/v1/vouchers")]
    public class ListVouchersEndpoint : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<IEnumerable<Voucher>>
    {
        private readonly IMediator _mediator;

        public ListVouchersEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(
           Summary = "List all vouchers",
           Description = "List all vouchers",
           OperationId = "Voucher.List",
           Tags = new[] { "Vouchers" })
       ]
        public override async Task<ActionResult<IEnumerable<Voucher>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var vouchers = await _mediator.Send(new ListVouchers());

            return Ok(vouchers);
        }
    }
}
