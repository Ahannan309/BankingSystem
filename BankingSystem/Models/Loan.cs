using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSystem.Models
{
    public class Loan
    {

        [Key]
        public int LaonId { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime LoanDate { get; set; }


        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public decimal InterestRate { get; set; }

        public bool IsPaidOff {  get; set; }    
    }
}
