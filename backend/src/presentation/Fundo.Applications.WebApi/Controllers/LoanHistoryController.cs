using Fundo.Applications.Application.UseCases.GetAllHistory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fundo.Applications.WebApi.Controllers
{
    [Route("api/loans/history")]
    [ApiController]
    public class LoanHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanHistoryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("{loanId}")]
        public async Task<ActionResult<GetLoanHistoryResponse>> GetByLoanId(
            [FromRoute] int loanId,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var response = await _mediator.Send(new GetLoanHistoryRequest { LoanId = loanId }, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
