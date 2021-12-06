using DataTransferer.Model;
using DataTransferer.Requests;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using DataTransferer.Quartz;
using DataTransferer.Quartz.Jobs;
using Quartz;
using Quartz.Impl;

namespace DataTransferer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*using (var db = new NisDBContext())
            {
                Console.WriteLine("Is connected to db: " + db.Database.CanConnect());


                // Vypis region idciek
                foreach (var reg in db.Regions)
                    Console.WriteLine(reg.ID);

                // Plnenie databazy
                //var s = GetRequests.GetAgTestsByRegions();
                //foreach (var item in s)
                //    db.Add(item);

                //foreach (var hp in GetRequests.GetHospitalPatientsByRegion())
                //    db.Add(hp);

                //foreach (var hb in GetRequests.GetHospitalBedsByRegion())
                //    db.Add(hb);


                // Prikaz pre commit; databazy
                //db.SaveChanges();
            }*/
            var jh = new JobHandler();
            await jh.RunJobs();
            Console.ReadKey();
        }
    }
}