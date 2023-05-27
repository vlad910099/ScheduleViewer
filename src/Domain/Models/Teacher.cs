using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Teacher
    {
        public string Name { get; }

        public Teacher(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        public override bool Equals(object obj) => obj is Teacher teacher && Name == teacher.Name;

        public override int GetHashCode() => 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
    }
}