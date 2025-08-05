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
            if (Status != "Active" && Status != "active")
                throw new InvalidOperationException("Cannot make payments on a non-active loan");

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
            if (Amount <= 0)
                throw new ArgumentException("Loan amount must be greater than zero");

            if (string.IsNullOrWhiteSpace(ApplicantName))
                throw new ArgumentException("Applicant name is required");

            this.CurrentBalance = this.Amount;
            this.Status = "Active";
        }
    }
}
