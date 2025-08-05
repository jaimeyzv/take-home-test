using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fundo.Applications.Infrastructure.Persistance.Entities
{
    [Table("LoanStatus")]
    public class LoanStatusEntity
    {
        [Key]
        [Column("StatusId")]
        public int StatusId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        public ICollection<LoanEntity> Loans { get; set; }
    }
}
