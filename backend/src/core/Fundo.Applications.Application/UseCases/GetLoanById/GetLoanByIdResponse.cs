namespace Fundo.Applications.Application.UseCases.GetLoanById
{
    public sealed class GetLoanByIdResponse
    {
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
        public string ApplicantName { get; set; }
        public string Status { get; set; }
    }
}
