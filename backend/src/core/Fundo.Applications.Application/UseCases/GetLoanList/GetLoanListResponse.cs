namespace Fundo.Applications.Application.UseCases.GetLoanList
{
    public sealed class GetLoanListResponse
    {
        public List<GetLoanListItem> Loans { get; set; }        
    }

    public sealed class GetLoanListItem
    {
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
        public string ApplicantName { get; set; }
        public string Status { get; set; }
    }
}
