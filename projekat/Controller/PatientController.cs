/***********************************************************************
 * Module:  PatientController.cs
 * Purpose: Definition of the Class Controller.PatientController
 ***********************************************************************/

using Model.Patient;
using Model.Users;
using ProjekatKlinika.Controller;
using Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controller
{
   public class PatientController : IController<Patient, long>
    {
    
        private readonly PatientService service;
        public PatientController(PatientService service)
        {
            this.service = service;
        }

        public Patient Create(Patient entity) => service.Create(entity);

        public void Delete(Patient entity) => service.Delete(entity);

        public Patient Get(long id) => service.Get(id);

        public IEnumerable<Patient> GetAll() => service.GetAll();

        public void Update(Patient entity) => service.Update(entity);

        public Patient LogIn(String email, String password)
        {
            return service.LogIn(email, password);
        }

        public Patient getByJMBG(String JMBG)
        {
            return service.getByJMBG(JMBG);
        }
        public void CreateReport(long id, Report report)
        {
            service.CreateReport(id, report);
        }



    }
}
/*
public int ChangeTheme()
{
 // TODO: implement
 return 0;
}

public int ChangeLanguage()
{
 // TODO: implement
 return 0;
}

public int IsGuest()
{
 // TODO: implement
 return 0;
}

public int MergeDataDuringRegistration()
{
 // TODO: implement
 return 0;
}

public void CreateGuest(Patient patient)
{
 foreach(Patient pat in patientService.patientRepository.GetPatients())
    {
        if(pat.IdNumber.Equals(patient.IdNumber))
        {
            MessageBox.Show("ID number must be unique");
            return;
        }
    }
    patientService.CreateGuest(patient);
}

public void CreateRegisteredPatient(RegisteredPatient regpatient)
{
    foreach (Patient pat in patientService.patientRepository.GetPatients())
    {
        if (pat.IdNumber.Equals(regpatient.IdNumber))
        {
            MessageBox.Show("ID number must be unique");
            return;
        }
    }
    patientService.CreateRegisteredPatient(regpatient);
}

public Boolean IsIDValid()
{
 // TODO: implement
 return false;
}

public List<Patient> GetPatients()
{
 // TODO: implement
 return null;
}

public void DeletePatient(Patient patient)
{
    patientService.DeletePatient(patient);
}

public Service.PatientService patientService;

}
}
*/
