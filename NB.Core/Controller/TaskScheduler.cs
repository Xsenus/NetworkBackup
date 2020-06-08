using NB.Core.Model;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;

namespace NB.Core.Controller
{
    public class TaskScheduler 
    {
        public static async void Start(Task task)
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            var nameJob = $"{task.Name}-{task.Oid}-{Guid.NewGuid()}";

            IJobDetail job = JobBuilder.Create<ZipArchiveController>()
                .WithIdentity(nameJob, "CreateZip")   
                .UsingJobData("pathIn", task.CopyDirectory)
                .UsingJobData("pathOut", task.SaveDirectory)
                .UsingJobData("taskOid", task.Oid)
                .Build();

            var daysOfWeek = new List<DayOfWeek>();

            if (task.IsMonday)
            {
                daysOfWeek.Add(DayOfWeek.Monday);
            }

            if (task.IsTuesday)
            {
                daysOfWeek.Add(DayOfWeek.Tuesday);
            }

            if (task.IsWednesday)
            {
                daysOfWeek.Add(DayOfWeek.Wednesday);
            }

            if (task.IsThursday)
            {
                daysOfWeek.Add(DayOfWeek.Thursday);
            }

            if (task.IsFriday)
            {
                daysOfWeek.Add(DayOfWeek.Friday);
            }

            if (task.IsSaturday)
            {
                daysOfWeek.Add(DayOfWeek.Saturday);
            }

            if (task.IsSunday)
            {
                daysOfWeek.Add(DayOfWeek.Sunday);
            }

            var date = Convert.ToDateTime(task.Date);

            var trigger = default(ITrigger);

            if (daysOfWeek.Count == 0)
            {
                trigger = TriggerBuilder.Create()
                    .WithIdentity(nameJob, "CreateZip")
                    .StartAt(DateBuilder.DateOf(date.Hour, date.Minute, date.Second, date.Day, date.Month, date.Year))
                    .Build();
            }
            else
            {
                var dailyTimeInterval = DailyTimeIntervalScheduleBuilder.Create().OnDaysOfTheWeek(daysOfWeek);
                
                trigger = TriggerBuilder.Create()
                    .WithIdentity(nameJob, "CreateZip")
                    .StartAt(DateBuilder.DateOf(date.Hour, date.Minute, date.Second, date.Day, date.Month, date.Year))
                    .WithSchedule(dailyTimeInterval)
                    .WithCalendarIntervalSchedule(x => x
                        .WithIntervalInWeeks(1))
                    .Build();
            }

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}