using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.DAL.Data.EF.Dao
{
    [Index(nameof(Code), IsUnique = true)]
    [Table("CATEGORY")]
    public class CategoriesDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("C_Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(3)]
        [Column("C_Code")]
        public string Code { get; set; }

        [Required]
        [Column("C_Name")]
        public string Name { get; set; }

        [Column("C_Description")]
        public string Description { get; set; }

    }
}
