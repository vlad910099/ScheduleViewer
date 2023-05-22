using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Group
    {
        public string Name { get; set; }
        public string AlternativeName { get; set; }

        public Group(string name, string alternativeName)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            AlternativeName = alternativeName;
        }
    }
}
