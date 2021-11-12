using PersonModel;
using SerializeInterface;
using System;
using System.IO;
using System.Xml.Serialization;

namespace XmlPlugin
{
    public class XmlConverter : ISerializePlugin
    {
        public XmlConverter()
        {

        }
        public string Name => "Xml Converter";

        public string Description => "Class for saving data to Xml format";

        public Person Deserialize(StreamReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            var person = (Person)serializer.Deserialize(reader);
            return person;
        }

        public void Serialize(Person person, StreamWriter writer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            serializer.Serialize(writer, person);
        }
    }
}
