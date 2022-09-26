using System.ComponentModel.DataAnnotations;

namespace WebStore.Core.Models;
public class UpdateStaff
{
    [Required]
    public int StoreId { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? EMAIL { get; set; }
    public bool IsActive { get; set; }
}

