using CureWell.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.Data
{
    public class CureWellRepository : ICureWellRepository
    {
        SqlConnection connection;
        SqlCommand command;

        public CureWellRepository()
        {
            connection = new SqlConnection("server=INL622;database=DoctorDB;trusted_connection=yes");
            command = new SqlCommand();
            command.Connection = connection;
        }
        public bool AddDoctor(DoctorSpecialization dObj)
        {
            try
            {
                command.CommandText = "insert into doctors (DoctorName) values ('" + dObj.DoctorName + "')";
                connection.Open();
                int affectedRows = command.ExecuteNonQuery();
                connection.Close();
                if (affectedRows > 0)
                    return true;
                else
                    return false;
               
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteDoctor(int id)
        {
            try
            {
                command.Connection = connection;
                command.CommandText = "delete from doctors where DoctorId = " + id;
                connection.Open();

                List<Doctor> doctors = new List<Doctor>();
                int affectedRows = command.ExecuteNonQuery();
                connection.Close();

                if (affectedRows > 0)
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
                command.Connection = connection;
                command.CommandText = "select * from doctors";
                connection.Open();

                List<Doctor> doctors = new List<Doctor>();

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    doctors.Add(new Doctor()
                    {
                        DoctorId = Int32.Parse(dataReader["DoctorId"].ToString()),
                        DoctorName = dataReader["DoctorName"].ToString()
                    });
                }
                dataReader.Close();
                connection.Close();

                if (doctors.Count > 0)
                    return doctors;
                else
                    return null;
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

                command.CommandText = "select * from Specializations";
                connection.Open();
                List<Specialization> specializations = new List<Specialization>();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    specializations.Add(new Specialization()
                    {
                        SpecializationCode = dataReader["SpecializationCode"].ToString(),
                        SpecializationName = dataReader["SpecializationName"].ToString()
                    });
                }
                dataReader.Close();
                connection.Close();

                if (specializations.Count > 0)
                    return specializations;
                else
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

                command.CommandText = "select * from Surgeries where SurgeryDate >= GETDATE() ";
                connection.Open();

                List<Surgery> surgeries = new List<Surgery>();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    surgeries.Add(new Surgery()
                    {
                        SurgeryId = Int32.Parse(dataReader["SurgeryId"].ToString()),
                        SurgeryCategory = dataReader["SurgeryCategory"].ToString(),
                        StartTime = Decimal.Parse(dataReader["StartTime"].ToString()),
                        EndTime = Decimal.Parse(dataReader["EndTime"].ToString()),
                        DoctorId = Int32.Parse(dataReader["DoctorId"].ToString()),
                        SurgeryDate = Convert.ToDateTime(dataReader["SurgeryDate"].ToString())
                    }); ;
                }
                dataReader.Close();
                connection.Close();

                if (surgeries.Count > 0)
                    return surgeries;
                else
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
                command.CommandText = "select dr.DoctorId,dr.DoctorName,s.SpecializationCode,s.SpecializationName,ds.SpecializationDate from doctors dr ,specializations s, DrSpecializations ds where ds.DoctorId = dr.DoctorId AND s.SpecializationCode = ds.SpecializationCode AND ds.SpecializationCode = '" + specializationCode + "'";
                connection.Open();

                List<DoctorSpecialization> doctorSpecializations = new List<DoctorSpecialization>();

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    doctorSpecializations.Add(new DoctorSpecialization()
                    {
                        DoctorId = Int32.Parse(dataReader["DoctorId"].ToString()),
                        DoctorName = dataReader["DoctorName"].ToString(),
                        SpecializationCode = dataReader["SpecializationCode"].ToString(),
                        SpecializationName = dataReader["SpecializationName"].ToString(),
                        SpecializationDate =Convert.ToDateTime(dataReader["SpecializationDate"].ToString())


                    });
                }
                dataReader.Close();
                connection.Close();

                if (doctorSpecializations.Count > 0)
                    return doctorSpecializations;
                else
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
                command.CommandText = "update doctors set DoctorName='" + dObj.DoctorName + "' where DoctorId=" + dObj.DoctorId;
                connection.Open();
                int noOfEntries = command.ExecuteNonQuery();
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
                command.CommandText = "update Surgeries set StartTime='" + sObj.StartTime + "',EndTime= '" + sObj.EndTime + "' where SurgeryId=" + sObj.SurgeryId;
                connection.Open();
                int noOfEntries = command.ExecuteNonQuery();
                if (noOfEntries > 0)
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
        public bool UpdateTables(DoctorSpecialization dObj)
        {
            command.CommandText = "insert into DrSpecializations (DoctorId,SpecializationCode,SpecializationDate) values ('" + dObj.DoctorId + "','" + dObj.SpecializationCode + "','" + dObj.SpecializationDate + "')";
            connection.Open();
            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return true;
            else
                return false;
        }

    }
}
