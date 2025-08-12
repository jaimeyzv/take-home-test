namespace Fundo.Applications.Application.UseCases.GetAllHistory
{
    public class GetLoanHistoryResponse
    {
        public List<GetLoanHistoryItem> History { get; set; }
    }

    public class GetLoanHistoryItem
    {
        public int LoanHistoryId { get; set; }

        public int LoanId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PayDate { get; set; }
    }
}
