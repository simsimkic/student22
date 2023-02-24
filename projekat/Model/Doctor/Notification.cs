/***********************************************************************
 * Module:  Notification.cs
 * Purpose: Definition of the Class Model.Notification
 ***********************************************************************/

using System;

namespace Model.Doctor
{
   public class Notification
   {
      public Model.Users.Doctor doctor;
   
      private NotificationCategory Category;
      private String Text;
   
   }
}