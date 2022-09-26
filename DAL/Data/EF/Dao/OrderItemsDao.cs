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
        [Column("OI_Quantity")]
        public decimal Quantity { get; set; }

        [Required]
        [Column("OI_PUHT")]
        public decimal PuHT { get; set; }

        [Required]
        [Column("OI_PUNet")]
        public decimal PuNet { get; set; }

        [Required]
        [Column("OI_PUTTC")]
        public decimal PuTTC { get; set; }

        [Required]
        [Column("OI_Taxe")]
        public decimal Taxe { get; set; }

        [Required]
        [Column("OI_Discount")]
        public decimal Discount { get; set; }
    }
}
