using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Entity
{
    public class Surgery
    {


        public int DoctorId { get; set; }


        [Column(TypeName = "decimal(4,2)")] //specifies that the EndTime should be mapped to a database column with the data type Decimal(4,2).
        public decimal EndTime { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal StartTime { get; set; }

        [Column(TypeName = "char(3)")]      //specifies that the SurgeryCategory should be mapped to a database column with the data type Decimal(4,2).
        public string SurgeryCategory { get; set; }

        public DateTime SurgeryDate { get; set; }

        public int SurgeryId { get; set; }
    }
}
