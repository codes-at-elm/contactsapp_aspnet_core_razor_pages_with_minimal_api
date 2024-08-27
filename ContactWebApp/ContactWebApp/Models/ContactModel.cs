using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactWebApp.Models;

public class ContactModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [StringLength(50)]
    [Display(Name = "Middle Name")]
    public string? MiddleName { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    public string FullName { get => FirstName + (string.IsNullOrEmpty(MiddleName) ? "" : " " + MiddleName) + " " + LastName; }
    
    [StringLength(100)]
    public string? Company { get; set; }

    [StringLength(50)]
    [Url]
    public string? Website { get; set; }

    [StringLength(50)]
    public string? Title { get; set; }

    [Required]
    [StringLength(14)]
    [Phone]
    public string? Phone { get; set; }

    [StringLength(50)]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [StringLength(50)]
    public string? AddressLine1 { get; set; }

    [Required]
    [StringLength(50)]
    public string? AddressLine2 { get; set; }
}
