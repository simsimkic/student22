/***********************************************************************
 * Module:  SpecializationRepository.cs
 * Purpose: Definition of the Class Repository.SpecializationRepository
 ***********************************************************************/

using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class SpecializationRepository
   {

        private static List<Specialization> specializations;
        public List<Specialization> GetSpecializations()
        {
            return specializations;
        }
   
   }
}