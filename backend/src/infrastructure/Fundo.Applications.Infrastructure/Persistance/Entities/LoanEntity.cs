using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fundo.Applications.Infrastructure.Persistance.Entities
{
    [Table("Loans")]
    public class LoanEntity
    {
        [Key]
        [Column("LoanId")]
        public int LoanId { get; set; }

        [Column("Amount")]
        public decimal Amount { get; set; }

        [Column("CurrentBalance")]
        public decimal CurrentBalance { get; set; }

        [Column("ApplicantName")]
        public string ApplicantName { get; set; }

        [ForeignKey(nameof(Status))]
        [Column("StatusId")]
        public int StatusId { get; set; }

        public LoanStatusEntity Status { get; set; }
    }
}
