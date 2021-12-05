using DataTransferer.Model;
using DataTransferer.Requests;

using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Linq;

namespace DataTransferer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NisDBContext())
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
            }
           
            Console.WriteLine("Done!");
        }
    }
}