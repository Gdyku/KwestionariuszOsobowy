using PersonModel;
using System;
using System.IO;

namespace SerializeInterface
{
    public interface ISerializePlugin
    {
        public string Name { get; }
        public string Description { get; }
        public void Serialize(Person person, StreamWriter writer);
        Person Deserialize(StreamReader reader);
    }
}
