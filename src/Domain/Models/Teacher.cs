using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
