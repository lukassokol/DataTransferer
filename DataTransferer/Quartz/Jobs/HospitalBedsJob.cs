using System.Linq;
using System.Threading.Tasks;
using DataTransferer.Requests;
using DataTransferer.Service;
using Quartz;

namespace DataTransferer.Quartz.Jobs
{
    public class HospitalBedsJob: IJob
    {
        private readonly HospitalBedsService _hospitalBedsService;

        public HospitalBedsJob()
        {
            _hospitalBedsService = new();
        }

        public Task Execute(IJobExecutionContext context)
        {
            //Get data from server
            var data = GetRequests.GetHospitalBedsByRegion();

            //Save data to DB
            _hospitalBedsService.SaveDataByRegion(data);
            return Task.CompletedTask;
        }
    }
}