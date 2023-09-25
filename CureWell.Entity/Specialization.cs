using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Entity
{
    public class Specialization
    {
        [Key]
        [Column(TypeName = "char(3)")]
        public string SpecializationCode { get; set; }

        [Required]
        public string SpecializationName { get; set; }
    }
}
