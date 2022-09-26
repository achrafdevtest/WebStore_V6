using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.DAL.Data.EF.Dao
{
    [Table("STORES")]
    public class StoresDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("STR_Id")]
        public int Id { get; set; }

        [Column("STR_Name")]
        [MaxLength(50)]
        public string Societe { get; set; }

        [Column("STR_Phone")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Column("STR_Email")]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("STR_Street")]
        public string Street { get; set; }

        [Column("STR_City")]
        [MaxLength(30)]
        public string City { get; set; }

        [Column("STR_State")]
        [MaxLength(30)]
        public string State { get; set; }

        [MaxLength(10)]
        [Column("STR_Zip_Code")]
        public string ZipCode { get; set; }
    }
}
