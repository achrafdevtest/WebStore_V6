using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.DAL.Data.EF.Dao
{
    [Table("STOCK")]
    public class StocksDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("STK_Id")]
        public int Id { get; set; }

        [Required]
        [Column("STR_Id")]
        public int StoreId { get; set; }

        [Required]
        [Column("P_Id")]
        public int ProductId { get; set; }

        [Column("STK_Quantity", TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }

        [Column("STK_Disponibility")]
        public bool Disponibility { get; set; }

        [ForeignKey(nameof(StoreId))]
        public virtual StoresDao Stores { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual ProductsDao Products { get; set; }
    }
}
