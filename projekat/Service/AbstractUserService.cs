/***********************************************************************
 * Module:  AbstractUserService.cs
 * Purpose: Definition of the Class Service.AbstractUserService
 ***********************************************************************/

using Model.Users;
using System;

namespace Service
{
   public abstract class AbstractUserService
   {
      public User Register()
      {
         // TODO: implement
         return null;
      }
      
      public abstract UserDataDTO GetRegisterData();
      
      public abstract Boolean IsRegisterDataValid();
      
      public User Login(String username, String password)
      {
         // TODO: implement
         return null;
      }
      
      public void ChangeProfileInfo(UserDataDTO data)
      {
         // TODO: implement
      }
      
      public void RateSoftware(Double grade)
      {
         // TODO: implement
      }
      
      public Boolean IsUsernameValid()
      {
         // TODO: implement
         return false;
      }
      
      public Boolean IsPasswordValid()
      {
         // TODO: implement
         return false;
      }
   
      private Boolean LoggedIn;
   
   }
}