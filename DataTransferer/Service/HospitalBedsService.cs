using System;
using System.Collections.Generic;
using System.Linq;
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
                //TODO: Create list of IDs and iterate them instead of for loop
                for (int i = 1; i < 8; i++)
                {
                    var newest = context.HOspitalbbedsByRegions
                        .Where(t => t.REGION_ID == i)
                        .OrderByDescending(t => t.PUBLISHED_ON)
                        .FirstOrDefault();
                    var subset = data
                        .Where(d => d.REGION_ID == i);
                    if (newest != null)
                    {
                        subset = subset.Where(d => d.PUBLISHED_ON > newest.PUBLISHED_ON);
                    }

                    foreach (var item in subset)
                        context.Add(item);
                }
            }*/
        }
    }
}