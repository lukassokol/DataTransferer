using System.Linq;
using System.Threading.Tasks;
using DataTransferer.Requests;
using DataTransferer.Service;
using Quartz;

namespace DataTransferer.Quartz.Jobs
{
    public class HospitalPatientsJob: IJob
    {
        private readonly HospitalPatientsService _hospitalPatientsService;

        public HospitalPatientsJob()
        {
            _hospitalPatientsService = new();
        }

        public Task Execute(IJobExecutionContext context)
        {
            //Get data from server
            var data = GetRequests.GetHospitalPatientsByRegion();
            
            //Save data to the DB
            _hospitalPatientsService.SaveDataByRegion(data);
            return Task.CompletedTask;
        }
    }
}