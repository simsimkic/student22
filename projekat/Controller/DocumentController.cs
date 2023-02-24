/***********************************************************************
 * Module:  DocumentController.cs
 * Purpose: Definition of the Class Controller.DocumentController
 ***********************************************************************/

using System;

namespace Controller
{
   public class DocumentController : Controller
   {
      public int GenerateDrugUsageReport()
      {
         // TODO: implement
         return 0;
      }
      
      public int FillReport()
      {
         // TODO: implement
         return 0;
      }
      
      public int FillLaboratoryReferral()
      {
         // TODO: implement
         return 0;
      }
      
      public int FillSpecialistReferral()
      {
         // TODO: implement
         return 0;
      }
      
      public int FillHospitalizationReferral()
      {
         // TODO: implement
         return 0;
      }
      
      public int PrescribeDrug()
      {
         // TODO: implement
         return 0;
      }
      
      public int FillProgressNote()
      {
         // TODO: implement
         return 0;
      }
      
      public int GenerateStatisticsReport()
      {
         // TODO: implement
         return 0;
      }
   
      public Service.PatientService patientService;
      public Service.RoomService roomService;
      public Service.DrugService drugService;
   
   }
}