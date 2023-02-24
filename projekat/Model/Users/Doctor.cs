/***********************************************************************
 * Module:  Doctor.cs
 * Purpose: Definition of the Class Model.Users.Doctor
 ***********************************************************************/

using ProjekatKlinika.Repository.Abstract;
using System;
using System.ComponentModel;

namespace Model.Users
{
   public class Doctor : User, IIdentifiable<long>
   {
        public Doctor() : base()
        {

        }
        public System.Collections.ArrayList doctorsDailyWorkingHours;

        private int licenseNumber;
        private string specialization;
        private long id;
        public string Specialization { get; set; }
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public int LicenseNumber { get => licenseNumber; set => licenseNumber = value; }

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetDoctorsDailyWorkingHours()
      {
         if (doctorsDailyWorkingHours == null)
            doctorsDailyWorkingHours = new System.Collections.ArrayList();
         return doctorsDailyWorkingHours;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetDoctorsDailyWorkingHours(System.Collections.ArrayList newDoctorsDailyWorkingHours)
      {
         RemoveAllDoctorsDailyWorkingHours();
         foreach (Model.Secretary.DoctorsDailyWorkingHours oDoctorsDailyWorkingHours in newDoctorsDailyWorkingHours)
            AddDoctorsDailyWorkingHours(oDoctorsDailyWorkingHours);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddDoctorsDailyWorkingHours(Model.Secretary.DoctorsDailyWorkingHours newDoctorsDailyWorkingHours)
      {
         if (newDoctorsDailyWorkingHours == null)
            return;
         if (this.doctorsDailyWorkingHours == null)
            this.doctorsDailyWorkingHours = new System.Collections.ArrayList();
         if (!this.doctorsDailyWorkingHours.Contains(newDoctorsDailyWorkingHours))
         {
            this.doctorsDailyWorkingHours.Add(newDoctorsDailyWorkingHours);
            newDoctorsDailyWorkingHours.SetDoctor(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveDoctorsDailyWorkingHours(Model.Secretary.DoctorsDailyWorkingHours oldDoctorsDailyWorkingHours)
      {
         if (oldDoctorsDailyWorkingHours == null)
            return;
         if (this.doctorsDailyWorkingHours != null)
            if (this.doctorsDailyWorkingHours.Contains(oldDoctorsDailyWorkingHours))
            {
               this.doctorsDailyWorkingHours.Remove(oldDoctorsDailyWorkingHours);
               oldDoctorsDailyWorkingHours.SetDoctor((Model.Users.Doctor)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllDoctorsDailyWorkingHours()
      {
         if (doctorsDailyWorkingHours != null)
         {
            System.Collections.ArrayList tmpDoctorsDailyWorkingHours = new System.Collections.ArrayList();
            foreach (Model.Secretary.DoctorsDailyWorkingHours oldDoctorsDailyWorkingHours in doctorsDailyWorkingHours)
               tmpDoctorsDailyWorkingHours.Add(oldDoctorsDailyWorkingHours);
            doctorsDailyWorkingHours.Clear();
            foreach (Model.Secretary.DoctorsDailyWorkingHours oldDoctorsDailyWorkingHours in tmpDoctorsDailyWorkingHours)
               oldDoctorsDailyWorkingHours.SetDoctor((Model.Users.Doctor)null);
            tmpDoctorsDailyWorkingHours.Clear();
         }
      }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            this.Id = (int)id;
        }
    }
}