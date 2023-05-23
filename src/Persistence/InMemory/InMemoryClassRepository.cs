using Domain.Enums;
using Domain.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Repositoryes;

namespace UDUNT_TimeTable.Persistence.InMemory
{
    public class InMemoryClassRepository : IClassRepository
    {
        private static List<Class> classes = new List<Class>
        {
            new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      1,
                      1,
                      WeekType.None,
                      "Основи програмування",
                      new Group("ПЗ2112", "922"),
                      new Teacher("доц.Горбова О.В."),
                      "4205")
                      ,
           new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      1,
                      1,
                      WeekType.None,
                      "Основи програмування",
                      new Group("ПЗ2111", "921"),
                      new Teacher("доц.Горбова О.В."),
                      "4205"),
           new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      1,
                      2,
                      WeekType.Numerator,
                      "Основи програмування",
                      new Group("ПЗ2111", "921"),
                      new Teacher("доц.Горбова О.В."),
                      "4205"),

           new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      2,
                      1,
                      WeekType.Numerator,
                      "Основи програмування",
                      new Group("ПЗ2112", "922"),
                      new Teacher("доц.Горбова О.В."),
                      "4205"),
            new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      1,
                      4,
                      WeekType.Denominator,
                      "П З  загальн. користув-я",
                      new Group("ПЗ2111", "921"),
                      new Teacher("ст.в.Самойлов С.П."),
                      "4206"),

            new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      1,
                      2,
                      WeekType.Numerator,
                      "Дискретні структури",
                      new Group("ПЗ2112", "922"),
                      new Teacher("доц.Нечай І.В."),
                      "4202"),
            new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      1,
                      2,
                      WeekType.Denominator,
                      "Архітектура комп'ютера",
                      new Group("ПЗ2112", "922"),
                      new Teacher("ст.в.Шаповал І.В."),
                      "4202"),
            new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      1,
                      3,
                      WeekType.Denominator,
                      "Архітектура комп'ютера",
                      new Group("ПЗ2112", "922"),
                      new Teacher("ст.в.Шаповал І.В."),
                      "4202"),

             new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      2,
                      2,
                      WeekType.Numerator,
                      "П З  загальн. користув-я",
                      new Group("ПЗ2112", "922"),
                      new Teacher("ст.в.Самойлов С.П."),
                      "4206"),
             new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      2,
                      2,
                      WeekType.Denominator,
                      "П З  загальн. користув-я",
                      new Group("ПЗ2111", "921"),
                      new Teacher("ст.в.Самойлов С.П."),
                      "4206"),
             new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      2,
                      3,
                      WeekType.None,
                      "П З  загальн. користув-я",
                      new Group("ПЗ2111", "921"),
                      new Teacher("ст.в.Самойлов С.П."),
                      "4206"),
            new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      2,
                      3,
                      WeekType.None,
                      "П З  загальн. користув-я",
                      new Group("ПЗ2112", "922"),
                      new Teacher("ст.в.Самойлов С.П."),
                      "4206"),

             new Class("Розклад занять на 2 семестр 2022/23 н.р.",
                      5,
                      3,
                      WeekType.Numerator,
                      "П З  загальн. користув-я",
                      new Group("ПЗ2112", "922"),
                      new Teacher("ст.в.Самойлов С.П."),
                      "4206"),

            new Class("Розклад занять на 1 семестр 2022/23 н.р.",
                      1,
                      2,
                      WeekType.Numerator,
                      "Профес.пр-ка прогр.інженер.",
                      new Group("ПЗ2112", "922"),
                      new Teacher("ст.в.Шаповал І.В."),
                      "4206")
        };

        public Task Create(Class @class)
        {
            classes.Add(@class);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Class>> Get(SearchCriteria searchCriteria)
        {
            var result = classes.Where(c => c.ScheduleName == searchCriteria.ScheduleName);

            if (!string.IsNullOrEmpty(searchCriteria.TeacherName))
            {
                result = result.Where(c => c.Teacher.Name.Equals(searchCriteria.TeacherName));
            }

            if (!string.IsNullOrEmpty(searchCriteria.GroupName))
            {
                result = result.Where(c => c.Group.Name.Equals(searchCriteria.GroupName));
            }

            return Task.FromResult<IEnumerable<Class>>(result.ToList());
        }
    }
}
