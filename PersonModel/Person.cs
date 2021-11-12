using System;
using System.Collections.Generic;
using System.Text;

namespace PersonModel
{
    public enum Sex { Man, Woman, NonBinary }
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Sex Sex { get; set; }
        public bool IsMarried { get; set; }

        public override string ToString()
        {
            return $"{Name}\n" +
                $"{Surname}\n" +
                $"{DateOfBirth.ToShortDateString()}\n" +
                $"{Sex}\n" +
                $"{IsMarried}";
        }
    }
}
