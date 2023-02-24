/***********************************************************************
 * Module:  DoctorService.cs
 * Purpose: Definition of the Class Service.DoctorService
 ***********************************************************************/

using Model.Doctor;
using Model.Doctor;
using Model.Users;
using ProjekatKlinika.Repository.Abstract.DoctorAbstract;
using ProjekatKlinika.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
   public class DoctorService : IService<Doctor, long>
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public Doctor LogIn(String email, String password)
        {
            List<Doctor> doctors = doctorRepository.GetAll().ToList();
            foreach (Doctor doctor in doctors)
            {
                if (doctor.email.Equals(email) && doctor.password.Equals(password))
                {
                    return doctor;
                }
            }
            return null;
        }

        public Doctor Create(Doctor entity) => doctorRepository.Create(entity);

        public void Delete(Doctor entity) => doctorRepository.Delete(entity);

        public Doctor Get(long id) => doctorRepository.Get(id);

        public System.Collections.Generic.IEnumerable<Doctor> GetAll() => doctorRepository.GetAll();

        public void Update(Doctor entity) => doctorRepository.Update(entity);
    }
}

/*
public new void ChangeProfileInfo(UserDataDTO data)
{
 // TODO: implement
}

public int RateDoctor()
{
 // TODO: implement
 return 0;
}

public int AddSpecialization()
{
 // TODO: implement
 return 0;
}

public int SetWorkingHours()
{
 // TODO: implement
 return 0;
}

public int ScheduleHoliday()
{
 // TODO: implement
 return 0;
}

public int DeleteSpecialization()
{
 // TODO: implement
 return 0;
}

public List<Specialization> GetSpecializations()
{
 // TODO: implement
 return null;
}

public List<DoctorsDailyWorkingHours> GetWorkingHours(Model.Users.Doctor doctor)
{
 // TODO: implement
 return null;
}

public override UserDataDTO GetRegisterData()
{
    throw new NotImplementedException();
}

public override bool IsRegisterDataValid()
{
    throw new NotImplementedException();
}

public Repository.SpecializationRepository specializationRepository;
public Repository.WorkingHoursRepository workingHoursRepository;
public Repository.DoctorRepository doctorRepository;

}
}
*/
