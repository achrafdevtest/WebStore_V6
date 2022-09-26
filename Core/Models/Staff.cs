namespace WebStore.Core.Models;
public class Staff
{
    public int Id { get; set; }
    public int StoreId { get; set; }
    public string? Matricule { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? EMAIL { get; set; }
    public bool IsActive { get; set; }
}

