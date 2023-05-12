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

        public Task<string[]> GetAvailableScheduleNames()
        {
            return scheduleProvider.GetAvailableScheduleNames();
        }

        public async Task LoadSchedule(string selectedScheduleName)
        {
            var scheduleInfo = await scheduleProvider.GetInfo(selectedScheduleName);
            var dbScheduleInfo = await scheduleRepository.Get(selectedScheduleName);

            if (dbScheduleInfo == null)
            {
                var schedule = await scheduleProvider.Get(selectedScheduleName);
                await scheduleRepository.Create(schedule);
            }
            else if (dbScheduleInfo.CreatedDateTime < scheduleInfo.CreatedDateTime)
            {
                var schedule = await scheduleProvider.Get(selectedScheduleName);

                await scheduleRepository.Delete(selectedScheduleName);
                await scheduleRepository.Create(schedule);
            }
        }

        public Task<IEnumerable<Class>> GetClasses(SearchCriteria searchCriteria)
        {
            return classRepository.Get(searchCriteria);
        }

        public async Task<string[]> GetTeachers()
        {
            var result = await teacherRepository.Get();
            return result.Select(t => t.Name).ToArray();
        }

        public async Task<string[]> GetGroups()
        {
            var result = await groupRepository.Get();
            return result.Select(t => t.Name).ToArray();
        }
    }
}
