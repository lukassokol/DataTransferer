using System;
using System.Linq;
using System.Threading.Tasks;
using DataTransferer.Requests;
using DataTransferer.Service;
using Quartz;

namespace DataTransferer.Quartz.Jobs
{
    public class AgTestsJob: IJob
    {
        private readonly AgTestsService _agTestsService;

        public AgTestsJob()
        {
            _agTestsService = new();
        }

        public Task Execute(IJobExecutionContext context)
        {
            //Get data from server
            var data = GetRequests.GetAgTestsByRegions();

            //Save data to the DB
            _agTestsService.SaveDataByRegion(data);
            
            return Task.CompletedTask;
        }
    }
}