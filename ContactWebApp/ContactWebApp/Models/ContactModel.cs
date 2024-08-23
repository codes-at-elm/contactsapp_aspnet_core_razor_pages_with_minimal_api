using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactWebApp.Models;

public class ContactModel
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Display(Name = "Middle Name")]
    public string? MiddleName { get; set; }

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    public string? Company { get; set; }
    public string? Website { get; set; }
    public string? Title { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
}
