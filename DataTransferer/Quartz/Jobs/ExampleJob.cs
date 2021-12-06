using System;
using System.Threading.Tasks;
using Quartz;

namespace DataTransferer.Quartz.Jobs
{
    public class ExampleJob: IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job started");
            return Task.CompletedTask;
        }
    }
}