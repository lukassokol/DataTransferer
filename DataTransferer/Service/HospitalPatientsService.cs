using System;
using System.Collections.Generic;
using DataTransferer.Model;

namespace DataTransferer.Service
{
    public class HospitalPatientsService
    {
        public void SaveDataByRegion(List<NisDBContext.HospitalPatientsByRegion> data)
        {
            Console.WriteLine("Saving HospitalPatients");
            /*using (var context = new NisDBContext())
            {
                foreach (var item in data)
                    context.Add(item);
            }*/
        }
    }
}