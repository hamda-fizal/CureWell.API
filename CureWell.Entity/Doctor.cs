using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Entity
{
    public class Doctor
    {

        public int DoctorId { get; set; }

        [Required]
        public string DoctorName { get; set; }
    }
}
