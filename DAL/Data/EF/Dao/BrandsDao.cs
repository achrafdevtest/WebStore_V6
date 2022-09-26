using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.DAL.Data.EF.Dao
{
    [Table("BRANDS")]
    [Index(nameof(Code), IsUnique = true)]
    public class BrandsDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("B_Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(3)]
        [Column("B_Code")]
        public string Code { get; set; }

        [Required]
        [Column("B_Name")]
        public string Name { get; set; }

        [Column("B_Description")]
        public string Description { get; set; }
    }
}
