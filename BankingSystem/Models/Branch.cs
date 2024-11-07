using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Models
{
    public class Branch
    {

        [Key]
        public int BranchId { get; set; }


        [Required]
        [StringLength(100)]
        public string BranchName { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        public ICollection<Account> Accounts { get; set; }  
        public ICollection<Customer> Customers {  get; set; }

    }
}
