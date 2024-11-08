using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Models
{
    public class Customer
    {
    [Key]
    public int CustomerId { get; set; }

    [Required]
    [StringLength(100)]
    public string CName { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(15)]
    public string PhoneNumber { get; set; } 

    [StringLength(200)]
    public string Address { get; set; } 


    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public  ICollection<Account> Accounts { get; set; }

       
    }
}
