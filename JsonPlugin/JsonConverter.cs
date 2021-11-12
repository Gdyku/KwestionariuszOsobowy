using Newtonsoft.Json;
using PersonModel;
using SerializeInterface;
using System;
using System.IO;

namespace JsonPlugin
{
    public class JsonConverter : ISerializePlugin
    {
        public JsonConverter()
        {

        }
        public string Name => "Json Converter";

        public string Description => "Clas which save sata to Json format";

        public Person Deserialize(StreamReader reader)
        {
            var jsonText = reader.ReadToEnd();
            var person = FromJsonToString(jsonText);

            return person;
        }

        public void Serialize(Person person, StreamWriter writer)
        {
            string json = JsonConvert.SerializeObject(person);
            writer.WriteLine(json);
        }

        //below are helper methods to serializing and deserializing
        private Person FromJsonToString(string jsonText)
        {
            var person = JsonConvert.DeserializeObject<Person>(jsonText);
            return person;
        }

    }
}
