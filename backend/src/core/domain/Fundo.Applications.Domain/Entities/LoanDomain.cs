using Fundo.Applications.Domain.ValueObjects;

namespace Fundo.Applications.Domain.Entities
{
    public class LoanDomain
    {
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
        public string ApplicantName { get; set; }
        public string Status { get; set; }

        public void MakePayment(decimal paymentAmount)
        {
            if (paymentAmount <= 0)
                throw new ArgumentException("Payment must be greater than 0");

            if (paymentAmount > CurrentBalance)
                throw new InvalidOperationException("Payment exceeds current balance");

            CurrentBalance -= paymentAmount;

            if (CurrentBalance == 0)
                Status = "Paid";
        }

        public void NewLoanCreation()
        {
            this.CurrentBalance = this.Amount;
            this.Status = "Active";
        }
    }
}
