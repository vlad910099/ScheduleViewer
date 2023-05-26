using Domain.Interfaces;
using Domain.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositoryes;
using System.Linq;

namespace UDUNT_TimeTable.Services
{
    public class ScheduleService
    {
        private readonly IScheduleProvider scheduleProvider;
        private readonly IScheduleRepository scheduleRepository;
        private readonly IClassRepository classRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly IGroupRepository groupRepository;

        public ScheduleService(
            IScheduleProvider scheduleProvider,
            IScheduleRepository scheduleRepository,
            IClassRepository classRepository,
            ITeacherRepository teacherRepository,
            IGroupRepository groupRepository)
        {
            this.scheduleProvider = scheduleProvider;
            this.scheduleRepository = scheduleRepository;
            this.classRepository = classRepository;
            this.teacherRepository = teacherRepository;
            this.groupRepository = groupRepository;
        }

        public async Task<ScheduleInfo[]> GetSchedules()
        {
            var schedules = await scheduleProvider.GetSchedules();

            if (schedules == null || !schedules.Any())
                schedules = await scheduleRepository.GetSchedules();

            var sortSchdules = schedules.OrderByDescending(x => x.Year).ThenBy(x => x.Name).ToList();
            //return sortSchdules;
            return sortSchdules.ToArray();
        }

        public async Task LoadSchedule(ScheduleInfo scheduleInfo)
        {
            var extendedScheduleInfo = (await scheduleProvider.GetScheduleInfo(scheduleInfo)) ?? scheduleInfo;
            var dbScheduleInfo = await scheduleRepository.Get(scheduleInfo.Name);

            if (dbScheduleInfo == null)
            {
                var schedule = await scheduleProvider.Get(extendedScheduleInfo);
                await scheduleRepository.Create(schedule);
            }
            else if (dbScheduleInfo.CreatedDateTime < scheduleInfo.CreatedDateTime)
            {
                var schedule = await scheduleProvider.Get(extendedScheduleInfo);

                await scheduleRepository.Delete(extendedScheduleInfo.Name);
                await scheduleRepository.Create(schedule);
            }
        }

        public Task<IEnumerable<Class>> GetClasses(SearchCriteria searchCriteria)
        {
            return classRepository.Get(searchCriteria);
        }

        public async Task<string[]> GetTeachers(string scheduleName)
        {
            var result = await teacherRepository.Get(scheduleName);
            var sortResult = result.OrderBy(x => x.Name).ToList();
            return sortResult.Select(t => t.Name).Distinct().ToArray();
        }

        public async Task<string[]> GetGroups(string scheduleName)
        {
            var result = await groupRepository.Get(scheduleName);
            var sortResult = result.OrderBy(x => x.Name).ToList();
            return sortResult.Select(t => t.Name).ToArray();
        }

        public async Task<string[]> GetTeachers(string scheduleName, string name)
        {
            var result = await teacherRepository.Get(scheduleName, name);
            return result.Select(t => t.Name).ToArray();
        }
        
        public async Task<string[]> GetGroups(string scheduleName, string name)
        {
            var result = await groupRepository.Get(scheduleName, name);
            return result.Select(t => t.Name).ToArray();
        }
    }
}
