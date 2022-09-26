using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.DAL.Data.EF.Dao
{
    [Index(nameof(Code), IsUnique = true)]
    [Table("PRODUCTS")]
    public class ProductsDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("P_Id")]
        public int Id { get; set; }

        [Required]
        [Column("B_Brand_Id")]
        public int BrandId { get; set; }

        [Required]
        [Column("C_Category_Id")]
        public int CategoryId { get; set; }
     
        [Column("P_Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(3)]
        [Column("P_Code")]
        public string Code { get; set; }

        [Column("P_Description")]
        public string Description { get; set; }

        [Column("P_Model_Years")]
        [MaxLength(4)]
        public int ModelYears { get; set; }

        [Column("P_PU")]
        [Required]
        public decimal PU { get; set; }

        [Column("P_Unite")]
        public string Unite { get; set; }

        [Column("P_Status")]
        public bool IsActive { get; set; }

        [ForeignKey(nameof(BrandId))]
        public virtual BrandsDao Brands { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual CategoriesDao Categories { get; set; }
    }
} 
