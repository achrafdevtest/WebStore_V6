using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.DAL.Data.EF.Dao
{
    [Index(nameof(Matricule), IsUnique = true)]
    [Table("STAFF")]
    public class StaffsDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("S_Id")]
        public int Id { get; set; }

        [Column("STR_Id")]
        public int StoreId { get; set; }

        [Column("S_Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("S_Matricule")]
        [MaxLength(6)]
        public string Matricule { get; set; }

        [Column("S_Phone")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Column("S_Email")]
        [EmailAddress]
        [MaxLength(100)]
        public string EMAIL { get; set; }

        [Column("S_Active")]
        public bool IsActive { get; set; }
    }
}
