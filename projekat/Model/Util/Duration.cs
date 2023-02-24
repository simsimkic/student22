/***********************************************************************
 * Module:  Duration.cs
 * Purpose: Definition of the Class Model.Util.Duration
 ***********************************************************************/

using System;

namespace Model.Util
{
   public class Duration
   {

        private DateTime startTime;
        private DateTime endTime;
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
    }
}