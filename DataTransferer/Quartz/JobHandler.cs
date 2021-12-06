using System.Threading.Tasks;
using DataTransferer.Quartz.Jobs;
using Quartz;
using Quartz.Impl;

namespace DataTransferer.Quartz
{
    public class JobHandler
    {

        public async Task RunJobs()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler sched = await factory.GetScheduler();
            await sched.Start();
            
            IJobDetail ExampleJob = JobBuilder.Create<ExampleJob>()
                .WithIdentity("ExampleJob", "group1")
                .Build();
            
            //Define time intervals
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(30)
                    .RepeatForever())
                .Build();

            await sched.ScheduleJob(ExampleJob, trigger);
        }
    }
}