/***********************************************************************
 * Module:  AppointmentController.cs
 * Purpose: Definition of the Class Controller.AppointmentController
 ***********************************************************************/

using Model.Doctor;
using Model.Manager;
using Model.Users;
using Model.Util;
using ProjekatKlinika.Controller;
using Repository;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class AppointmentController : IController<Appointment, long>
    {
        private readonly AppointmentService service;
        public AppointmentController(AppointmentService service)
        {
            this.service = service;
        }

        public Appointment Create(Appointment entity) => service.Create(entity);

        public void Delete(Appointment entity) => service.Delete(entity);

        public Appointment Get(long id) => service.Get(id);

        public IEnumerable<Appointment> GetAll() => service.GetAll();

        public void Update(Appointment entity) => service.Update(entity);
    

    /*public Service.AppointmentService appointmentService;

    public void ScheduleAppointment(Appointment appointment)
    {
          appointmentService.ScheduleAppointment(appointment);
          return;
    }

    public void RescheduleAppointment(Appointment oldappointment, Appointment newappointment)
    {

          appointmentService.RescheduleAppointment(oldappointment, newappointment);
          return;
    }

    public void CancelAppointment(Appointment appointment)
    {
         appointmentService.CancelAppointment(appointment);
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

    public bool IsAppointmentValid(Model.Doctor.Appointment appointment)
    {
          return appointmentService.IsAppointmentValid(appointment);
    }

    public int RecommendAppointment(int priority, Model.Users.Doctor doctor, DateTime startDate, DateTime endDate)
    {
       // TODO: implement
       return 0;
    }

      public List<Appointment> GetAppointments()
      {
         return appointmentService.GetAppointments();
      }


 */
}
}