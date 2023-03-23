using System.Text.Json;
using PrsnLib;
using FileFunction;

namespace JsonSerializeLib
{
    public class DeSerialize
    {
        static public void Deserialize<T>(out T? exmp)
        {
            exmp = JsonSerializer.Deserialize<T>(FileWork.ReadText());
        }
        static public void Serialize<T1>(out string jsonstring , T1? Persons)
        {
            jsonstring = JsonSerializer.Serialize(Persons, FileWork.Options());
        }
    }
}