using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.DAL.Data.EF.Dao
{
    [Table("ORDER_ITEMS")]
    public class OrderItemsDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("OI_Id")]
        public int Id { get; set; }

        [Required]
        [Column("O_Id")]
        public int OrderId { get; set; }

        [Required]
        [Column("P_Id")]
        public int ProductId { get; set; }

        [Required]
        [Column("OI_Quantity", TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }

        [Required]
        [Column("OI_PUHT", TypeName = "decimal(18,3)")]
        public decimal PuHT { get; set; }

        [Required]
        [Column("OI_PUNet", TypeName = "decimal(18,3)")]
        public decimal PuNet { get; set; }

        [Required]
        [Column("OI_PUTTC", TypeName = "decimal(18,3)")]
        public decimal PuTTC { get; set; }

        [Required]
        [Column("OI_Taxe", TypeName = "decimal(18,3)")]
        public decimal Taxe { get; set; }

        [Required]
        [Column("OI_Discount", TypeName = "decimal(18,3)")]
        public decimal Discount { get; set; }
    }
}
