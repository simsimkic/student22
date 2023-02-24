/***********************************************************************
 * Module:  Address.cs
 * Purpose: Definition of the Class Model.Util.Address
 ***********************************************************************/

using System;

namespace Model.Util
{
   public class Address
   {
      public City city;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public City GetCity()
      {
         return city;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newCity</param>
      public void SetCity(City newCity)
      {
         if (this.city != newCity)
         {
            if (this.city != null)
            {
               City oldCity = this.city;
               this.city = null;
               oldCity.RemoveAddress(this);
            }
            if (newCity != null)
            {
               this.city = newCity;
               this.city.AddAddress(this);
            }
         }
      }
   
   }
}