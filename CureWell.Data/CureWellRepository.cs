using CureWell.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Data
{
    public class CureWellRepository : ICureWellRepository
    {
        public CureWellRepository()
        {
            
        }
        public bool AddDoctor(Doctor dObj)
        {
            try
            {
                var noOfEntries=0;
                if (noOfEntries > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteDoctor(Doctor dObj)
        {
            try
            {

                int noOfEntries = 0;
                if (noOfEntries > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public List<Doctor> GetAllDoctors()
        {
            try
            {
                List<Doctor> doctors = new List<Doctor>
                {
                    new Doctor() { DoctorId = 1007, DoctorName = "sdf" }
                };
                return doctors;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Specialization> GetAllSpecialization()
        {
            try
            {
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Surgery> GetAllSurgeries()
        {
            try
            {

                return null;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<DoctorSpecialization> GetDoctorsBySpecializationCode(string specializationCode)
        {
            try
            {
                return null;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool UpdateDoctorDetails(Doctor dObj)
        {
            try
            {
                int noOfEntries = 0;
                if (noOfEntries > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool UpdateSurgery(Surgery sObj)
        {
            try
            {
                Doctor data = null;
                if (data != null)
                {
                   
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
