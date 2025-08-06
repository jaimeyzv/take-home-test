using Fundo.Applications.Application.UseCases.GetLoanList;
using Fundo.Applications.Application.UseCases.PayLoan;
using Fundo.Services.Tests.Seed;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Fundo.Services.Tests.Integration
{
    public class LoanManagementControllerTests : IClassFixture<WebApplicationFactory<Fundo.Applications.WebApi.Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory _factory;

        public LoanManagementControllerTests(WebApplicationFactory<Fundo.Applications.WebApi.Startup> factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task GetBalances_ShouldReturnExpectedResult()
        {
            var response = await _client.GetAsync("/loans");

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public async Task CreateLoan_WithAmountLessThanOrEqualToZero_ShouldReturnExpectedResult(decimal amount)
        {
            // Arrange
            var invalidRequest = new
            {
                amount = amount,
                applicantName = "Test User"
            };

            var content = new StringContent(
                JsonSerializer.Serialize(invalidRequest),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            var response = await _client.PostAsync("/loans", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.Equal("Loan amount must be greater than zero", responseBody);
        }

        [Fact]
        public async Task CreateLoan_WithValidRequest_ShouldIncreaseLoanCountByOne()
        {
            // Arrange

            // STEP 1: Get existing loans
            var beforeResponse = await _client.GetAsync("/loans");
            beforeResponse.EnsureSuccessStatusCode();

            var beforeContent = await beforeResponse.Content.ReadAsStringAsync();
            var beforeLoans = JsonSerializer.Deserialize<GetLoanListResponse>(beforeContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            int initialCount = beforeLoans.Loans.Count;

            // STEP 2: Create a new valid loan
            var newLoanRequest = new
            {
                amount = 5000,
                applicantName = "Valid User"
            };

            var content = new StringContent(
                JsonSerializer.Serialize(newLoanRequest),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            var createResponse = await _client.PostAsync("/loans", content);
            createResponse.EnsureSuccessStatusCode(); // 200 OK expected

            // Assert

            // STEP 3: Get loans again
            var afterResponse = await _client.GetAsync("/loans");
            afterResponse.EnsureSuccessStatusCode();

            var afterContent = await afterResponse.Content.ReadAsStringAsync();
            var afterLoans = JsonSerializer.Deserialize<GetLoanListResponse>(afterContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            int finalCount = afterLoans.Loans.Count;

            Assert.Equal(initialCount + 1, finalCount);
        }

        [Fact]
        public async Task PayLoan_WhenStatusIsNotActive_ShouldReturnBadRequest()
        {
            // Arrange: getting the first paid loan in DB

            var loansResponse = await _client.GetAsync("/loans");
            loansResponse.EnsureSuccessStatusCode();

            var loansContent = await loansResponse.Content.ReadAsStringAsync();
            var loans = JsonSerializer.Deserialize<GetLoanListResponse>(loansContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            int initialCount = loans.Loans.Count;
            var loanId = loans.Loans.First(x => x.Status == "Paid").LoanId;

            var request = new
            {
                paymentAmount = 100
            };

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync($"/loans/{loanId}/payment", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var error = await response.Content.ReadAsStringAsync();
            Assert.Equal("Cannot make payments on a non-active loan", error);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public async Task PayLoan_WithAmountLessThanOrEqualToZero_ShouldReturnBadRequest(decimal amount)
        {
            // Arrange: getting the first paid loan in DB

            var loansResponse = await _client.GetAsync("/loans");
            loansResponse.EnsureSuccessStatusCode();

            var loansContent = await loansResponse.Content.ReadAsStringAsync();
            var loans = JsonSerializer.Deserialize<GetLoanListResponse>(loansContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            int initialCount = loans.Loans.Count;
            var loanId = loans.Loans.First(x => x.Status == "Active").LoanId;

            var request = new
            {
                paymentAmount = amount
            };

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync($"/loans/{loanId}/payment", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var error = await response.Content.ReadAsStringAsync();
            Assert.Equal("Payment must be greater than 0", error);
        }

        [Fact]
        public async Task PayLoan_WithAmountGreaterThanBalance_ShouldReturnBadRequest()
        {
            // Arrange: getting the first active loan with 5000 in the balance in DB
            var loansResponse = await _client.GetAsync("/loans");
            loansResponse.EnsureSuccessStatusCode();

            var loansContent = await loansResponse.Content.ReadAsStringAsync();
            var loans = JsonSerializer.Deserialize<GetLoanListResponse>(loansContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            int initialCount = loans.Loans.Count;
            var loanId = loans.Loans.First(x => x.CurrentBalance == 4000).LoanId;

            var request = new
            {
                paymentAmount = 10000
            };

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync($"/loans/{loanId}/payment", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var error = await response.Content.ReadAsStringAsync();
            Assert.Equal("Payment exceeds current balance", error);
        }

        [Fact]
        public async Task PayLoan_WithExactBalance_ShouldSetStatusToPaid()
        {
            // Arrange: getting the first active loan with 5000 in the balance in DB
            var loansResponse = await _client.GetAsync("/loans");
            loansResponse.EnsureSuccessStatusCode();

            var loansContent = await loansResponse.Content.ReadAsStringAsync();
            var loans = JsonSerializer.Deserialize<GetLoanListResponse>(loansContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            int initialCount = loans.Loans.Count;
            var loanId = loans.Loans.First(x => x.CurrentBalance == 5000).LoanId;

            var request = new
            {
                paymentAmount = 5000
            };

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync($"/loans/{loanId}/payment", content);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PayLoanResponse>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Assert
            Assert.Equal(0, result.CurrentBalance);
            Assert.Equal("Paid", result.Status, ignoreCase: true);
        }
    }
}
