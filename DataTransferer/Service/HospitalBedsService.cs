using System;
using System.Collections.Generic;
using DataTransferer.Model;

namespace DataTransferer.Service
{
    public class HospitalBedsService
    {
        public void SaveDataByRegion(List<NisDBContext.HospitalbbedsByRegion> data)
        {
            Console.WriteLine("Saving HospitalbBeds");
            /*using (var context = new NisDBContext())
            {
                foreach (var item in data)
                    context.Add(item);
            }*/
        }
    }
}