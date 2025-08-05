using Fundo.Applications.Application.UseCases.GetLoanById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fundo.Applications.WebApi.Controllers
{
    [Route("/loans")]
    public class LoanManagementController : Controller
    {

        private readonly IMediator _mediator;

        public LoanManagementController(IMediator mediator)
        {
         this._mediator = mediator;   
        }

        [HttpGet("{loanId}")]
        public async Task<ActionResult<GetLoanByIdResponse>> GetByLoanId(int loanId, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(new GetLoanByIdRequest(loanId), cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetLoanByIdResponse>> Create(
            GetLoanByIdRequest request,
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
    }
}