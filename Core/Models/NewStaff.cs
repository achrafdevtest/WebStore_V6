using System.ComponentModel.DataAnnotations;

namespace WebStore.Core.Models;
public class NewStaff : UpdateStaff
{
    [Required]
    public string? Matricule { get; set; }

}

