using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Repository.Abstract.PatientAbstract
{
    public interface IPatientRepository : IRepository<Patient, long>
    {
    }
}
