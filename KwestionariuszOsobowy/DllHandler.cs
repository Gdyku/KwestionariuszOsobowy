using SerializeInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KwestionariuszOsobowy
{
    public class DllHandler
    {
        public DllHandler()
        {
            PluginPath = GetPluginsDirectory();
        }
        private string PluginPath { get; set; }

        public List<ISerializePlugin> ReturnPluginsInstancesList()
        {
            var pluginsCollection = Directory.GetFiles(PluginPath, "*dll");
            var iSerializeTypes = ReturnTypeList(pluginsCollection);

            return iSerializeTypes.Select(t => (ISerializePlugin)Activator.CreateInstance(t)).ToList();
        }

        public void ShowDllNames(List<ISerializePlugin> plugins)
        {
            int index = 0;
            foreach(var element in plugins)
            {
                index++;
                Console.WriteLine($"{index}. {element.Name}");
            }
        }

        private List<Type> ReturnTypeList(string[] collection)
        {
            List<Type> types = new List<Type>();
            foreach(var element in collection)
            {
                Assembly assembly = Assembly.LoadFrom(element);
                var type = assembly.GetTypes().Where(x => x.GetInterface(typeof(ISerializePlugin).Name) != null).ToList();
                types.AddRange(type);
            }
            return types;
        }

        private string GetPluginsDirectory()
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            string path = Path.Combine(directory, "Plugins");
            var pluginsDirectory = new Uri(path).LocalPath;

            return pluginsDirectory;
        }
    }
}
