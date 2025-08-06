using Fundo.Applications.Application.UseCases.CreateLoan;
using Fundo.Applications.Application.UseCases.GetLoanById;
using Fundo.Applications.Application.UseCases.GetLoanList;
using Fundo.Applications.Application.UseCases.PayLoan;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fundo.Applications.WebApi.Controllers
{
    [Route("api/loans")]
    public class LoanManagementController : Controller
    {

        private readonly IMediator _mediator;

        public LoanManagementController(IMediator mediator)
        {
         this._mediator = mediator;   
        }

        [HttpGet("{loanId}")]
        public async Task<ActionResult<GetLoanByIdResponse>> GetByLoanId(
            [FromRoute] int loanId, 
            CancellationToken cancellationToken
        )
        {
            try
            {
                var response = await _mediator.Send(new GetLoanByIdRequest { LoanId = loanId }, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<ActionResult<GetLoanListResponse>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(new GetLoanListRequest(), cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreateLoanResponse>> Create(
            [FromBody] CreateLoanRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{loanId}/payment")]
        public async Task<ActionResult<PayLoanResponse>> Pay(
            [FromRoute] int loanId,
            [FromBody] PayLoanRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                request.LoanId = loanId;
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}