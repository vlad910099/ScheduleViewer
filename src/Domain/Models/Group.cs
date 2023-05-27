using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Group
    {
        public string Name { get; }
        public string AlternativeName { get; }

        public Group(string name, string alternativeName)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            AlternativeName = alternativeName;
        }

        public override bool Equals(object obj) => obj is Group group && Name == group.Name;

        public override int GetHashCode() => 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
    }
}