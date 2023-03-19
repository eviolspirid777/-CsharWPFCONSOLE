using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace FileFunc
{
    public class FileWork
    {
        public static string GetPath() => Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "content.json");
        static public StreamWriter CreateFile()
        {
            StreamWriter sw = new StreamWriter(GetPath());
            return sw; 
        }
        static public bool Exist()
        {
            FileInfo sw = new FileInfo(GetPath());
            if (sw.Exists) return true; else return false;
        }
        static public void WriteText( string txt)
        {
            File.WriteAllText(GetPath(), txt);
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
