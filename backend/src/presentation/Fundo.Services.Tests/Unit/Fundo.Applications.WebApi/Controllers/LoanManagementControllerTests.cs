using Fundo.Applications.Application.UseCases.CreateLoan;
using Fundo.Applications.Application.UseCases.GetLoanById;
using Fundo.Applications.Application.UseCases.GetLoanList;
using Fundo.Applications.Application.UseCases.PayLoan;
using Fundo.Applications.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Fundo.Services.Tests.Unit.Fundo.Applications.WebApi.Controllers
{
    public class LoanManagementControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly LoanManagementController _controller;

        public LoanManagementControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new LoanManagementController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetByLoanId_ReturnsOkResult_WhenFound()
        {
            var expectedResponse = new GetLoanByIdResponse { LoanId = 1, ApplicantName = "Piero Zamora" };
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetLoanByIdRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            var result = await _controller.GetByLoanId(1, CancellationToken.None);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<GetLoanByIdResponse>(okResult.Value);
            Assert.Equal(expectedResponse.LoanId, response.LoanId);
        }

        [Fact]
        public async Task GetByLoanId_ReturnsNotFound_WhenExceptionThrown()
        {
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetLoanByIdRequest>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Not found"));

            var result = await _controller.GetByLoanId(99, CancellationToken.None);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Not found", notFoundResult.Value);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WhenSuccessful()
        {
            var expected = new GetLoanListResponse();
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetLoanListRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            var result = await _controller.GetAll(CancellationToken.None);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expected, okResult.Value);
        }

        [Fact]
        public async Task GetAll_ReturnsNotFound_WhenExceptionThrown()
        {
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetLoanListRequest>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("DB error"));

            var result = await _controller.GetAll(CancellationToken.None);

            var notFound = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("DB error", notFound.Value);
        }

        [Fact]
        public async Task Create_ReturnsOk_WhenSuccessful()
        {
            var request = new CreateLoanRequest { Amount = 1000, ApplicantName = "Andrea Vasquez" };
            var expected = new CreateLoanResponse { LoanId = 10 };

            _mediatorMock
                .Setup(m => m.Send(request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            var result = await _controller.Create(request, CancellationToken.None);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expected.LoanId, ((CreateLoanResponse)okResult.Value).LoanId);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenExceptionThrown()
        {
            var request = new CreateLoanRequest { Amount = 1000, ApplicantName = "Andrea Vasquez" };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateLoanRequest>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Validation failed"));

            var result = await _controller.Create(request, CancellationToken.None);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Validation failed", badRequest.Value);
        }

        [Fact]
        public async Task Pay_ReturnsOk_WhenSuccessful()
        {
            var request = new PayLoanRequest { PaymentAmount = 500 };
            var expected = new PayLoanResponse { CurrentBalance = 500 };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<PayLoanRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            var result = await _controller.Pay(1, request, CancellationToken.None);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expected.CurrentBalance, ((PayLoanResponse)okResult.Value).CurrentBalance);
        }

        [Fact]
        public async Task Pay_ReturnsBadRequest_WhenExceptionThrown()
        {
            var request = new PayLoanRequest { PaymentAmount = 500 };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<PayLoanRequest>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Invalid payment"));

            var result = await _controller.Pay(1, request, CancellationToken.None);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Invalid payment", badRequest.Value);
        }
    }
}
