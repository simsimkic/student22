/***********************************************************************
 * Module:  City.cs
 * Purpose: Definition of the Class Model.Util.City
 ***********************************************************************/

using System;

namespace Model.Util
{
   public class City
   {
      public System.Collections.ArrayList address;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetAddress()
      {
         if (address == null)
            address = new System.Collections.ArrayList();
         return address;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetAddress(System.Collections.ArrayList newAddress)
      {
         RemoveAllAddress();
         foreach (Address oAddress in newAddress)
            AddAddress(oAddress);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddAddress(Address newAddress)
      {
         if (newAddress == null)
            return;
         if (this.address == null)
            this.address = new System.Collections.ArrayList();
         if (!this.address.Contains(newAddress))
         {
            this.address.Add(newAddress);
            newAddress.SetCity(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveAddress(Address oldAddress)
      {
         if (oldAddress == null)
            return;
         if (this.address != null)
            if (this.address.Contains(oldAddress))
            {
               this.address.Remove(oldAddress);
               oldAddress.SetCity((City)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllAddress()
      {
         if (address != null)
         {
            System.Collections.ArrayList tmpAddress = new System.Collections.ArrayList();
            foreach (Address oldAddress in address)
               tmpAddress.Add(oldAddress);
            address.Clear();
            foreach (Address oldAddress in tmpAddress)
               oldAddress.SetCity((City)null);
            tmpAddress.Clear();
         }
      }
      public Country country;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Country GetCountry()
      {
         return country;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newCountry</param>
      public void SetCountry(Country newCountry)
      {
         if (this.country != newCountry)
         {
            if (this.country != null)
            {
               Country oldCountry = this.country;
               this.country = null;
               oldCountry.RemoveCity(this);
            }
            if (newCountry != null)
            {
               this.country = newCountry;
               this.country.AddCity(this);
            }
         }
      }
   
   }
}