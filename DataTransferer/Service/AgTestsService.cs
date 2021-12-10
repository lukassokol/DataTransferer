using System;
using System.Collections.Generic;
using DataTransferer.Model;

namespace DataTransferer.Service
{
    public class AgTestsService
    {

        public void SaveDataByRegion(List<NisDBContext.AgTestsByRegion> data)
        {
            Console.WriteLine("Saving AgTestsByRegion");
            /*using (var context = new NisDBContext())
            {
                foreach (var item in data)
                    context.Add(item);
            }*/
        }
    }
}