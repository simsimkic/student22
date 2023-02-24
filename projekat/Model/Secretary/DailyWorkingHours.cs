/***********************************************************************
 * Module:  DailyWorkingHours.cs
 * Purpose: Definition of the Class Model.Secretary.DailyWorkingHours
 ***********************************************************************/

using Model.Util;
using System;
using System.Collections.Generic;

namespace Model.Secretary
{
   public class DailyWorkingHours
   {
      public DateTime Date { get; set; }
      public List<Duration> ActiveHours { get; set; }

    }
}