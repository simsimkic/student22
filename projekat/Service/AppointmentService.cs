/***********************************************************************
 * Module:  AppointmentService.cs
 * Purpose: Definition of the Class Service.AppointmentService
 ***********************************************************************/

using Model.Doctor;
using Model.Manager;
using Model.Users;
using ProjekatKlinika.Repository.Abstract.DoctorAbstract;
using ProjekatKlinika.Service;
using Repository;
using System;
using System.Collections.Generic;


namespace Service
{
    public class AppointmentService : IService<Appointment, long>
    {

        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public Appointment Create(Appointment entity) => appointmentRepository.Create(entity);

        public void Delete(Appointment entity) => appointmentRepository.Delete(entity);

        public Appointment Get(long id) => appointmentRepository.Get(id);

        public System.Collections.Generic.IEnumerable<Appointment> GetAll() => appointmentRepository.GetAll();

        public void Update(Appointment entity) => appointmentRepository.Update(entity);
    }
}



    /*public Repository.AppointmentRepository appointmentRepository;

    private int HoursBeforeAppointmentToMakeChanges = 24;


      public void ScheduleAppointment(Appointment appointment)
      {
        if (!AreAppointmentsOverlaping((List<Appointment>)appointmentRepository.GetAll(),appointment) && IsAppointmentValid(appointment))
        {
            appointmentRepository.Create(appointment);
        }
        else return;
      }

      public void RescheduleAppointment(Appointment oldappointment, Appointment newappointment)
      {
        List<Appointment> existingAppointmentsWithoutOldAppointment = new List<Appointment>((List<Appointment>)appointmentRepository.GetAll());
        existingAppointmentsWithoutOldAppointment.Remove(oldappointment);

        if (!AreAppointmentsOverlaping(existingAppointmentsWithoutOldAppointment, newappointment) && IsAppointmentValid(newappointment))
        {
         appointmentRepository.Delete(oldappointment);
         appointmentRepository.Create(newappointment);
        }
        else return;
      }

      public void CancelAppointment(Appointment appointment)
      {
         appointmentRepository.Delete(appointment);
         return;
      }

  public void SetOperation(Model.Doctor.Operation operation)
  {
     // TODO: implement
  }

  public List<DateTime> GetUnavailableDaysForOperation(Model.Users.DoctorSpecialist doctor, Model.Manager.OperatingRoom room, int durationInMinutes, Model.Users.Patient patient)
  {
     // TODO: implement
     return null;
  }

  public List<Appointment> GetRecommendedAppointmentsByDay(Model.Users.DoctorSpecialist doctor, Model.Manager.OperatingRoom room, int durationInMinutes, DateTime day, Model.Users.Patient patient)
  {
     // TODO: implement
     return null;
  }

  public List<Appointment> RecommendOperationAppointments(List<Appointment> roomAppointments, List<Appointment> doctorAppointments, List<Appointment> patientAppointments, int durationInMinutes)
  {
     // TODO: implement
     return null;
  }

  public bool IsAppointmentValid(Model.Doctor.Appointment appointment)
  {
        if (appointment.Doctor == null || appointment.Room == null || appointment.Patient == null || appointment.Duration.StartTime >= appointment.Duration.EndTime)
        {
            return false;
        }
        else return true;
    }

  public bool AreAppointmentsOverlaping(List<Appointment> existingAppointments, Model.Doctor.Appointment newAppointment)
  {
     foreach(Appointment app in existingAppointments)
        {
            if (app.Doctor.Equals(newAppointment.Doctor) || app.Room.Equals(newAppointment.Room) || app.Patient.Equals(newAppointment.Patient))
            {
                if(newAppointment.Duration.StartTime < app.Duration.EndTime && newAppointment.Duration.EndTime > app.Duration.StartTime)  // nov termin je pre kraja a posle pocetka vec zakazanog  
                return true;
            }
        } 
     return false;
  }

  public int RecommendAppointment(int priority, Model.Users.Doctor doctor, DateTime startDate, DateTime endDate)
  {
     // TODO: implement
     return 0;
  }

  private List<DateTime> CalculateUnavailableDaysForOperation(List<Appointment> roomAppointments, List<Appointment> doctorAppointments, List<Appointment> patientAppointments)
  {
     // TODO: implement
     return null;
  }

    public List<Appointment> GetAppointmentsByRoom(Room room)
    {
        List<Appointment> allappointments = (List<Appointment>)appointmentRepository.GetAll();
        List<Appointment> appointments = new List<Appointment>();

        foreach(Appointment app in allappointments)
        {
            if(app.Room.RoomNumber.Equals(room.RoomNumber))
            {
                appointments.Add(app);
            }
        }

        return appointments;
    }
    public List<Appointment> GetAppointmentsByDoctor(Doctor doctor)
    {
        List<Appointment> allappointments = (List<Appointment>)appointmentRepository.GetAll();
        List<Appointment> appointments = new List<Appointment>();

        foreach (Appointment app in allappointments)
        {
            if (app.Doctor.LicenseNumber.Equals(doctor.LicenseNumber))
            {
                appointments.Add(app);
            }
        }

        return appointments;
    }
    public List<Appointment> GetAppointmentsByPatient(Patient patient)
    {
        List<Appointment> allappointments = (List<Appointment>)appointmentRepository.GetAll();
        List<Appointment> appointments = new List<Appointment>();

        foreach (Appointment app in allappointments)
        {
            if (app.Patient.IdNumber.Equals(patient.IdNumber))
            {
                appointments.Add(app);
            }
        }

        return appointments;
    }

    public List<Appointment> GetAppointments()
    {
        return (List<Appointment>)appointmentRepository.GetAll();
    }


}*/
