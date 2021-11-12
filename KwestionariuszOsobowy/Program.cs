using PersonModel;
using SerializeInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace KwestionariuszOsobowy
{
    class Program
    {
        static void Main(string[] args)
        {
            var handler = new HandlePerson();
            var dllhandler = new DllHandler();
            var plugins = dllhandler.ReturnPluginsInstancesList();
            Console.WriteLine("Cześć, chcesz wypełnić nowy formularz osobowy czy wczytać ostatni?");
            Console.WriteLine("1. Wczytać ostatnio dodany formularz\n2. Stworzyć nowy formularz");
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                //odczyt w json i xml
                case 1:
                    {
                        string lastFile = handler.ReturnLastSavedFile();
                        using (StreamReader reader = new StreamReader(lastFile))
                        {
                            Person person = null;
                            foreach (var plugin in plugins)
                            {
                                try
                                {
                                    person = plugin.Deserialize(reader);
                                    if (person != null)
                                    {
                                        handler.DisplayPerson(person);
                                        break;
                                    }
                                }
                                catch (Exception e) { }
                            }
                            //var converter = new XmlConverter();
                            //var person = converter.Deserialize(reader);
                            //handler.DisplayPerson(person);
                        }
                    }
                    break;
                case 2:
                    {
                        var person = new Person();
                        person = handler.CreatePerson(person);
                        //wczytanie pluginów, jeśli program znajdzie pluginy to je wyświetli 
                        Console.WriteLine("W jakim formacie chcesz zapisać dane?");
                        dllhandler.ShowDllNames(plugins);
                        int aimedFormatt = Convert.ToInt32(Console.ReadLine());
                        switch(aimedFormatt)
                        {
                            //funkcja do zapisu w Json i XML
                            case 1:
                                {
                                    var questionnairesPath = handler.ReturnQuestionnairesPath();
                                    File.Create($"{questionnairesPath}/{person.Name}{person.Surname}.txt").Close();
                                    var newFile = handler.ReturnLastSavedFile();
                                    using (StreamWriter writer = new StreamWriter(newFile))
                                    {
                                        plugins[aimedFormatt - 1].Serialize(person, writer);
                                    }

                                }
                                break;
                            case 2:
                                {
                                    var questionnairesPath = handler.ReturnQuestionnairesPath();
                                    File.Create($"{questionnairesPath}/{person.Name}{person.Surname}.xml").Close();
                                    var newFile = handler.ReturnLastSavedFile();
                                    using (StreamWriter writer = new StreamWriter(newFile))
                                    {
                                        plugins[aimedFormatt - 1].Serialize(person, writer);
                                    }
                                }
                                break;
                        }
                    }
                    break;
            }
        }
    }
}
