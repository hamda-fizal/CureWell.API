using CureWell.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Data
{
    public interface ICureWellRepository
    {
        List<Doctor> GetAllDoctors();
        bool AddDoctor(DoctorSpecialization dObj);
        List<Specialization> GetAllSpecialization();
        List<Surgery> GetAllSurgeries();
        List<DoctorSpecialization> GetDoctorsBySpecializationCode(string specializationCode);
        bool UpdateDoctorDetails(Doctor dObj);
        bool UpdateSurgery(Surgery sObj);
        bool DeleteDoctor(int id);

        bool UpdateTables(DoctorSpecialization dObj);

        bool AddSurgery(Surgery sObj);
    }
}
