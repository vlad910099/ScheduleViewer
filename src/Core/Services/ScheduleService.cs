using Domain;
using Domain.Models;
using Domain.PersistenceInterfaces;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ScheduleService
    {
        private readonly IScheduleProvider scheduleProvider;
        private readonly IScheduleRepository scheduleRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly IGroupRepository groupRepository;

        #region Cache

        private static readonly ConcurrentDictionary<string, string[]> teacherNamesCache = new ConcurrentDictionary<string, string[]>();
        private static readonly ConcurrentDictionary<string, string[]> groupNamesCache = new ConcurrentDictionary<string, string[]>();

        #endregion Cache

        public ScheduleService(
            IScheduleProvider scheduleProvider,
            IScheduleRepository scheduleRepository,
            ITeacherRepository teacherRepository,
            IGroupRepository groupRepository)
        {
            this.scheduleProvider = scheduleProvider;
            this.scheduleRepository = scheduleRepository;
            this.teacherRepository = teacherRepository;
            this.groupRepository = groupRepository;
        }

        public async Task<ScheduleInfo[]> GetScheduleInfos()
        {
            var scheduleInfos = await scheduleProvider.GetScheduleInfos();

            if (scheduleInfos?.Any() != true)
            {
                scheduleInfos = await scheduleRepository.Get();
            }

            return scheduleInfos.OrderByDescending(x => x.Year).ThenBy(x => x.Name).ToArray();
        }

        public async Task LoadSchedule(ScheduleInfo scheduleInfo)
        {
            var extendedScheduleInfo = await scheduleProvider.ExtendScheduleInfo(scheduleInfo) ?? scheduleInfo;
            var dbScheduleInfo = await scheduleRepository.GetInfo(scheduleInfo.Name);

            if (dbScheduleInfo == null)
            {   
                var schedule = await scheduleProvider.Get(extendedScheduleInfo);
                await scheduleRepository.Create(schedule);
            }
            else if (!string.Equals(dbScheduleInfo.Checksum, extendedScheduleInfo.Checksum))
            {
                var schedule = await scheduleProvider.Get(extendedScheduleInfo);

                await scheduleRepository.Delete(extendedScheduleInfo.Name);
                await scheduleRepository.Create(schedule);
            }
        }

        public Task<IEnumerable<Class>> GetClasses(SearchCriteria searchCriteria) => scheduleRepository.GetClasses(searchCriteria);

        public async Task<string[]> GetTeachers(string scheduleName)
        {
            if (teacherNamesCache.TryGetValue(scheduleName, out var teacherNames))
            {
                return teacherNames;
            }

            var teachers = await teacherRepository.Get(scheduleName);
            var sortedResult = teachers.OrderBy(x => x.Name).Select(t => t.Name).ToArray();

            teacherNamesCache.TryAdd(scheduleName, sortedResult);

            return sortedResult;
        }

        public async Task<string[]> GetGroups(string scheduleName)
        {
            if (groupNamesCache.TryGetValue(scheduleName, out var groupNames))
            {
                return groupNames;
            }

            var groups = await groupRepository.Get(scheduleName);
            var sortedResult = groups.OrderBy(x => x.Name).Select(t => t.Name).ToArray();

            groupNamesCache.TryAdd(scheduleName, sortedResult);

            return sortedResult;
        }
    }
}