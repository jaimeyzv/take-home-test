namespace Fundo.Applications.Application.UseCases.PayLoan
{
    public sealed class PayLoanResponse
    {
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
        public string ApplicantName { get; set; }
        public string Status { get; set; }
    }
}
