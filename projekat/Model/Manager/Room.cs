/***********************************************************************
 * Module:  Room.cs
 * Purpose: Definition of the Class Model.Room
 ***********************************************************************/

using ProjekatKlinika.Repository.Abstract;
using System;

namespace Model.Manager
{
   public class Room : IIdentifiable<long>
    {
        private long idNumber;
        private int roomNumber { get; set; }
        private String roomType { get; set; }

        public Room() : base()
        {

        }
        public String RoomType { get; set; }
        public int RoomNumber { get; set; }
        public long IdNumber { get => idNumber; set => idNumber = value; }

       
        public System.Collections.ArrayList durableGoods;

      

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetDurableGoods()
      {
         if (durableGoods == null)
            durableGoods = new System.Collections.ArrayList();
         return durableGoods;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetDurableGoods(System.Collections.ArrayList newDurableGoods)
      {
         RemoveAllDurableGoods();
         foreach (DurableGoods oDurableGoods in newDurableGoods)
            AddDurableGoods(oDurableGoods);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddDurableGoods(DurableGoods newDurableGoods)
      {
         if (newDurableGoods == null)
            return;
         if (this.durableGoods == null)
            this.durableGoods = new System.Collections.ArrayList();
         if (!this.durableGoods.Contains(newDurableGoods))
            this.durableGoods.Add(newDurableGoods);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveDurableGoods(DurableGoods oldDurableGoods)
      {
         if (oldDurableGoods == null)
            return;
         if (this.durableGoods != null)
            if (this.durableGoods.Contains(oldDurableGoods))
               this.durableGoods.Remove(oldDurableGoods);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllDurableGoods()
      {
         if (durableGoods != null)
            durableGoods.Clear();
      }

        public long GetId()
        {

            return idNumber;


        }

        public void SetId(long id)
        {

            idNumber = id;



        }
    }
}