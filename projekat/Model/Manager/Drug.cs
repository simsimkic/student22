/***********************************************************************
 * Module:  Drug.cs
 * Purpose: Definition of the Class Model.Drug
 ***********************************************************************/

using Newtonsoft.Json.Serialization;
using ProjekatKlinika.Repository.Abstract;
using System;
using System.Collections.Generic;

namespace Model.Manager
{
   public class Drug : ConsumableGoods, IIdentifiable<long>
    {
        private long idNumber;
        public Drug() : base()
        {

        }
      public List<String> Ingredients { get; set; } = new List<String>();
      public bool Approved { get; set; }
      public String Code { get; set; }
      public String Manufacturer { get; set; }

      public long IdNumber { get => idNumber; set => idNumber = value; }

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