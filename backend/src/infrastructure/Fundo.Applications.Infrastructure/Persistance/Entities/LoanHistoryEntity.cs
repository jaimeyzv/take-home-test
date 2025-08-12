using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fundo.Applications.Infrastructure.Persistance.Entities
{
    [Table("LoansHistory")]
    public class LoanHistoryEntity
    {
        [Key]
        [Column("LoanHistoryId")]
        public int LoanHistoryId { get; set; }
        
        [Column("LoanId")]
        public int LoanId { get; set; }

        [Column("Amount")]
        public decimal Amount { get; set; }

        [Column("PayDate")]
        public DateTime PayDate { get; set; }
    }
}
