using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.DAL.Data.EF.Dao
{
    [Table("ORDERS")]
    public class OrderDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("O_Id")]
        public int Id { get; set; }

        [Required]
        [Column("C_Id")]
        public int CustomerId { get; set; }

        [Required]
        [Column("STR_Id")]
        public int StoreId { get; set; }

        [Required]
        [Column("S_Id")]
        public int StaffId { get; set; }

        [Column("O_Status")]
        public bool Status { get; set; }

        [Column("O_Date")]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual CustomersDao Customers { get; set; }

        [ForeignKey(nameof(StoreId))]
        public virtual StoresDao Stores{ get; set; }

        [ForeignKey(nameof(StaffId))]
        public virtual StaffsDao Staffs { get; set; }

    }
}
