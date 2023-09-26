using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Entity
{
    public class DoctorSpecialization
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string SpecializationCode { get; set; }

        public string SpecializationName { get; set; }
        [Required]
        public DateTime SpecializationDate { get; set; }
    }
}
