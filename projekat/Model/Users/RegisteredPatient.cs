/***********************************************************************
 * Module:  RegisteredPatient.cs
 * Purpose: Definition of the Class Model.Users.RegisteredPatient
 ***********************************************************************/

using Model.Util;
using System;
using System.ComponentModel;

namespace Model.Users
{
   public class RegisteredPatient : Patient
   {
        private Gender gender;
        private String parentName;

        public RegisteredPatient(Gender gender, string parentName, Patient patient) : base(patient)
        {
            Gender = gender;
            ParentName = parentName;
           // Language = language;
           // Theme = theme;
        }

        public string ParentName { get => parentName; set => parentName = value; }
        public Gender Gender { get => gender; set => gender = value; }
        //public Theme Theme { get => theme; set => theme = value; }
        //public Language Language { get => language; set => language = value; }
    }
}