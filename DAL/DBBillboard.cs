using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DAL
{
    public class DBBillboard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Write a category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Write tags")]
        public string Tags { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Write a name")]
        public string User { get; set; }
        public bool IsActive { get; set; } = true;
    }
}