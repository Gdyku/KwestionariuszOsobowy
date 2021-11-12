using System;

namespace PersonModel
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PersonDescription : Attribute
    {
        public PersonDescription()
        {
        }
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
