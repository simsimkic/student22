/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Purpose: Definition of the Class Repository.AppointmentRepository
 ***********************************************************************/

using Model.Doctor;
using Model.Manager;
using Model.Users;
using Model.Util;
using ProjekatKlinika.Repository.Abstract.DoctorAbstract;
using ProjekatKlinika.Repository.JSON;
using ProjekatKlinika.Repository.JSON.Stream;
using ProjekatKlinika.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Repository
{
    public class AppointmentRepository : JsonRepository<Appointment, long>, IAppointmentRepository
    {

        private const string ENTITY_NAME = "Appointment";
        public AppointmentRepository(IJsonStream<Appointment> stream, ISequencer<long> sequencer)
            : base(ENTITY_NAME, stream, sequencer)
        {
        }


        /*
        private static List<Appointment> appointments;

        public List<Appointment> GetAppointments()
        {
            return appointments;
        }

        public void ScheduleAppointment(Appointment appointment)
        {
            appointments.Add(appointment);
            return;
        }

        public void RescheduleAppointment(Appointment oldappointment, Appointment newappointment)
        {
            appointments.Remove(oldappointment);
            appointments.Add(newappointment);
            return;
        }

        public void CancelAppointment(Appointment appointment)
        {
            appointments.Remove(appointment);
            return;
        }

        public List<Appointment> GetAppointmentsByRoom(Model.Manager.Room room)
      {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment app in GetAppointments())
            {
                if (app.Room.Equals(room))
                {
                    appointments.Add(app);
                }
            }
         return appointments;
      }
      
      public List<Appointment> GetAppointmentsByDoctor(Model.Users.Doctor doctor)
      {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment app in GetAppointments())
            {
                if (app.Doctor.Equals(doctor))
                {
                    appointments.Add(app);
                }
            }
            return appointments;
      }
      
          
       public List<Appointment> GetAppointmentsByPatient(Model.Users.Patient patient)
       {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment app in GetAppointments())
            {
                if (app.Patient.IdNumber.Equals(patient.IdNumber))
                {
                    appointments.Add(app);
                }
            }
            return appointments;
        }

        public List<Appointment> GetDailyAppointmentsByRoom(string roomName, DateTime day)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment app in GetAppointments())
            {
                if (app.Duration.StartTime.Date.Equals(day.Date) && app.Room.Equals(roomName))
                {
                    appointments.Add(app);
                }
            }
            return appointments;
        }

        public List<Appointment> GetDailyAppointmentsByDoctor(Model.Users.Doctor doctor, DateTime day)
        {
            // TODO: implement
            return null;
        }


        public List<Appointment> GetDailyAppointmentsByPatient(Model.Users.Patient patient, DateTime day)
        {
            // TODO: implement
            return null;
        }

        public Model.Doctor.Appointment FindAvailableAppointment(Model.Users.Doctor doctor, DateTime startDate, DateTime endDate)
        {
         // TODO: implement
         return null;
        }
      
        public Model.Doctor.Appointment FindAvailableAppointmentByDoctor(Model.Users.Doctor doctor)
        {
             // TODO: implement
             return null;
        }
      
        public Model.Doctor.Appointment findAvailableAppointmentByDate(DateTime startDate, DateTime endDate)
        {
             // TODO: implement
             return null;
        }
         
   */
    }
}