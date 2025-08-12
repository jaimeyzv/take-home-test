namespace Fundo.Applications.Domain.Entities
{
    public class LoanHistoryDomain
    {
        public int LoanHistoryId { get; set; }

        public int LoanId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PayDate { get; set; }
    }
}
