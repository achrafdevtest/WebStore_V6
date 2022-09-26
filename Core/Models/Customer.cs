using System.ComponentModel.DataAnnotations;
namespace WebStore.Core.Models;
public class Customer
{
    public int Id { get; set; }

    [Required]
    public string Matricule { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }

    [EmailAddress]
    public string? EMAIL { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
}

