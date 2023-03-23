using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using PrsnLib;
namespace FileFunction
{
    public class FileWork
    {
        static string PathTo = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "content.json");
        static public StreamWriter CreateFile()
        {
            StreamWriter sw = new StreamWriter(PathTo);
            return sw;
        }
        static public bool ReadData(out List<Person> Persons)
        {
            string flag = File.ReadAllText(PathTo).Trim();
            if (flag != "")
                {
                    Persons = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(PathTo));
                    return true;
                }
            else
                {
                Persons = null;
                    return false;
                }
        }
        static public void WriteData(List <Person> Persons)
        {
            string jsonString = JsonSerializer.Serialize(Persons, Options());
            File.WriteAllText(PathTo, jsonString);
        }
        static JsonSerializerOptions Options()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            return options;
        } 
    }
}
