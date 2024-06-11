using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project__Otdel_Cadrov
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Institute { get; set; }
        public int Birth { get; set; }
        public string? Place { get; set; }
        public string? Address { get; set; }
        public int Phone { get; set; }
        public string? Education { get; set; }
        public int Year { get; set; }
        public int Passport { get; set; }
        public string? Post { get; set; }
    }
}