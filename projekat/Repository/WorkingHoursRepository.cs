/***********************************************************************
 * Module:  WorkingHoursRepository.cs
 * Purpose: Definition of the Class Repository.WorkingHoursRepository
 ***********************************************************************/

using Model.Secretary;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class WorkingHoursRepository
   {
      public List<DoctorsDailyWorkingHours> GetWorkingHoursByDoctor(Model.Users.Doctor doctor)
      {
         return null;
      }
      
      public List<DateTime> GetHolidayDaysByDoctor(Model.Users.Doctor doctor)
      {
         // TODO: implement
         return null;
      }
   
   }
}