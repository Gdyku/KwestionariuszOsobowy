using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PersonModel
{
    public class HandlePerson
    {
        public HandlePerson()
        {
            
        }
        public Person CreatePerson(Person person)
        {
            person.Id = Guid.NewGuid();

            //NAME
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            person.Name = name;

            //SURNAME
            Console.WriteLine("What's your surname?");
            string surname = Console.ReadLine();
            person.Surname = surname;

            //BIRTHDATE
            Console.WriteLine("What's your birth date? Date format YYYY-MM-DD");
            DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
            person.DateOfBirth = dateTime;

            //GENDER
            Console.WriteLine("Which sex you are?\n1. I'm  man\n2. I'm woman\n3. I'm non binary");
            Sex sex = (Sex)Convert.ToInt32(Console.ReadLine());
            person.Sex = sex;

            //MARRIED
            Console.WriteLine("Are you married?\n1. Yes\n2.No");
            int answer = Convert.ToInt32(Console.ReadLine());
            bool isMarried = false;
            if (answer == 1)
                isMarried = true;
            else if (answer == 2)
                isMarried = false;
            person.IsMarried = isMarried;


            return person;
        }

        public void DisplayPerson(Person person)
        {
            Console.WriteLine(person.ToString());
        }
            
        public string ReturnLastSavedFile()
        {
            string path = ReturnQuestionnairesPath();
            var filesList = new DirectoryInfo(@$"{path}");
            var newestFile = filesList.GetFiles().OrderByDescending(f => f.LastWriteTime).First().FullName;

            return newestFile;
        }
        public string ReturnQuestionnairesPath()
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            string path = Path.Combine(directory, "PersonalQuestionnaires");
            string filePath = new Uri(path).LocalPath;

            return filePath;
        }

        //public Person CheckIfPersonIsDeserilized(Person person, ISerializePlugin plugin)
        //{
            
        //}
    }
}
