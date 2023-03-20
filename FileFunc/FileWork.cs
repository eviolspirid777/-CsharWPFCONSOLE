using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace FileFunction
{
    public class FileWork
    {
        public static string PathTo = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "content.json");
        static public StreamWriter CreateFile()
        {
            StreamWriter sw = new StreamWriter(PathTo);
            return sw; 
        }
        static public bool Exist()
        {
            FileInfo sw = new FileInfo(PathTo);
            if (sw.Exists) return true; else return false;
        }
        static public void WriteText( string txt)
        {
            File.WriteAllText(PathTo, txt);
        }
        static public JsonSerializerOptions Options()
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
