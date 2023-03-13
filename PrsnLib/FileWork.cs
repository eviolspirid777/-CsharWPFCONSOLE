using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace PrsnLib
{
    public class FileWork
    {
        static public StreamWriter CreateFile(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            return sw; 
        }
        static public bool Exist(string path)
        {
            FileInfo sw = new FileInfo(path);
            if (sw.Exists) return true; else return false;
        }
        static public void WriteTxt(string path, string txt)
        {
            File.WriteAllText(path, txt);
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
