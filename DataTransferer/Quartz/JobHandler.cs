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
            var scheduler = await CreateScheduler();
            await scheduler.Start();
            
            var agTestsJob = CreateJob<AgTestsJob>("AgTestsJob", "AgTestsGroup");
            var hospitalPatientsJob = CreateJob<HospitalPatientsJob>("hospitalPatientsJob", "hospitalPatientsGroup");
            var hospitalBedsJob = CreateJob<HospitalBedsJob>("hospitalBedsJob", "hospitalBedsJobGroup");
            
            var agTestsTrigger = CreateTrigger("agTestsTrigger", "agTestsTriggerGroup");
            var hospitalPatientsTrigger = CreateTrigger("hospitalPatientsTrigger", "hospitalPatientsTriggerGroup");
            var hospitalBedsTrigger = CreateTrigger("hospitalBedsTrigger", "hospitalBedsTriggerGroup");

            await scheduler.ScheduleJob(agTestsJob, agTestsTrigger);
            await scheduler.ScheduleJob(hospitalPatientsJob, hospitalPatientsTrigger);
            await scheduler.ScheduleJob(hospitalBedsJob, hospitalBedsTrigger);
        }

        private IJobDetail CreateJob<T>(string name, string group)  where T : IJob
        {
            return JobBuilder.Create<T>()
                    .WithIdentity(name, group)
                    .Build();
        }

        private ITrigger CreateTrigger(string name, string group)
        {
            return TriggerBuilder.Create()
                    .WithIdentity(name, group)
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(30)
                        .RepeatForever())
                    .Build();
        }

        private async Task<IScheduler> CreateScheduler()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            return await factory.GetScheduler();
        }
    }
}