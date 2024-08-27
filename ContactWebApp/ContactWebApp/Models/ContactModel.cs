using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactWebApp.Models;

public class ContactModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Display(Name = "Middle Name")]
    public string? MiddleName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    public string FullName { get => FirstName + (string.IsNullOrEmpty(MiddleName) ? "" : " " + MiddleName) + " " + LastName; }  
    public string? Company { get; set; }
    public string? Website { get; set; }
    public string? Title { get; set; }
    
    [Required]
    public string? Phone { get; set; }
    public string? Email { get; set; }

    [Required]
    public string? AddressLine1 { get; set; }

    [Required]
    public string? AddressLine2 { get; set; }
}
