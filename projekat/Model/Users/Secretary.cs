/***********************************************************************
 * Module:  Secretary.cs
 * Purpose: Definition of the Class Model.Users.Secretary
 ***********************************************************************/

using Model.Secretary;
using ProjekatKlinika.Repository.Abstract;
using System;

namespace Model.Users
{
   public class Secretary : User, IIdentifiable<long>
   {
        public Secretary() : base()
        {

        }
        public System.Collections.ArrayList dailyWorkingHours;
        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetDailyWorkingHours()
      {
         if (dailyWorkingHours == null)
            dailyWorkingHours = new System.Collections.ArrayList();
         return dailyWorkingHours;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetDailyWorkingHours(System.Collections.ArrayList newDailyWorkingHours)
      {
         RemoveAllDailyWorkingHours();
         foreach (DailyWorkingHours oDailyWorkingHours in newDailyWorkingHours)
            AddDailyWorkingHours(oDailyWorkingHours);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddDailyWorkingHours(DailyWorkingHours newDailyWorkingHours)
      {
         if (newDailyWorkingHours == null)
            return;
         if (this.dailyWorkingHours == null)
            this.dailyWorkingHours = new System.Collections.ArrayList();
         if (!this.dailyWorkingHours.Contains(newDailyWorkingHours))
            this.dailyWorkingHours.Add(newDailyWorkingHours);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveDailyWorkingHours(DailyWorkingHours oldDailyWorkingHours)
      {
         if (oldDailyWorkingHours == null)
            return;
         if (this.dailyWorkingHours != null)
            if (this.dailyWorkingHours.Contains(oldDailyWorkingHours))
               this.dailyWorkingHours.Remove(oldDailyWorkingHours);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllDailyWorkingHours()
      {
         if (dailyWorkingHours != null)
            dailyWorkingHours.Clear();
      }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}