using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSystem.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }


        [Required]
        [StringLength(20)]
        public string AccountNo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; } 

        public bool IsActive { get; set; }

        [Required]
        public int BranchId { get; set; }

        public Branch Branch { get; set; }

    }
}
