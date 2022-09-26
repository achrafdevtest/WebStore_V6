using System.ComponentModel.DataAnnotations;

namespace WebStore.Core.Models;
public class BaseModelCreator
{
    [Required]
    public string Code { get; set; } = "";
    public string? Name { get; set; }
    public string? Description { get; set; }
}

