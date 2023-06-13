using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DAL
{
    public class Zone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "Write a character")]
        public string Character { get; set; }

        [Required(ErrorMessage = "Write attraction")]
        public string Attraction { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Write a price")]
        public string Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}