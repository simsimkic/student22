/***********************************************************************
 * Module:  DoctorsDailyWorkingHours.cs
 * Purpose: Definition of the Class Model.Secretary.DoctorsDailyWorkingHours
 ***********************************************************************/

using System;

namespace Model.Secretary
{
   public class DoctorsDailyWorkingHours : DailyWorkingHours
   {
      public Model.Users.Doctor doctor;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Model.Users.Doctor GetDoctor()
      {
         return doctor;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newDoctor</param>
      public void SetDoctor(Model.Users.Doctor newDoctor)
      {
         if (this.doctor != newDoctor)
         {
            if (this.doctor != null)
            {
               Model.Users.Doctor oldDoctor = this.doctor;
               this.doctor = null;
               oldDoctor.RemoveDoctorsDailyWorkingHours(this);
            }
            if (newDoctor != null)
            {
               this.doctor = newDoctor;
               this.doctor.AddDoctorsDailyWorkingHours(this);
            }
         }
      }
   
      private Model.Manager.Room Room;
   
   }
}