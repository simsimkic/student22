/***********************************************************************
 * Module:  ScheduleController.cs
 * Purpose: Definition of the Class Controller.ScheduleController
 ***********************************************************************/

using Model.Secretary;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class ScheduleController : Controller
   {
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
      
      public List<DoctorsDailyWorkingHours> GetWorkingHoursByDoctor(Model.Users.Doctor doctor)
      {
         // TODO: implement
         return null;
      }
   
      public Service.DoctorService doctorService;
      public Service.SecretaryService secretaryService;
   
   }
}