/***********************************************************************
 * Module:  DoctorReview.cs
 * Purpose: Definition of the Class Model.Users.DoctorReview
 ***********************************************************************/

using System;

namespace Model.Util
{
   public class DoctorReview : Review
   {
      public Model.Users.Patient patient;
      public Model.Users.Doctor doctor;
   
   }
}