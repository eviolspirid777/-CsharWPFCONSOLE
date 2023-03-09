using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using PrsnLib;

namespace csSharpJWPF
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        PathContent way = new PathContent();
        public Window3(string text)
        {
            InitializeComponent();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),       //настройки для сериалайзера
                WriteIndented = true
            };
            string jsonString = File.ReadAllText(way.GetPath());
            List<Person> humans = JsonSerializer.Deserialize<List<Person>>(jsonString);
            List<Person> tempHumans = new List<Person>();
            foreach (var e in humans)
                if (e.Fio.Name.Contains(text) || e.Fio.Surname.Contains(text) || e.Fio.Patron.Contains(text) || e.Curriculum.Faculty.Contains(text) || e.Curriculum.Specialty.Contains(text) || e.Curriculum.Course.Contains(text) || e.Curriculum.Group.Contains(text) || e.Address.City.Contains(text) || e.Address.PstIndex.Contains(text) || e.Address.Street.Contains(text) || e.Contacts.Phone.Contains(text) || e.Contacts.Mail.Contains(text))
                {
                    tempHumans.Add(e);
                }
            string getinf = JsonSerializer.Serialize<List<Person>>(tempHumans, options);
            FileInfo file = new FileInfo(@"filt.json");
            if(file.Exists)
            {
                File.WriteAllText(@"filt.json", jsonString);
                MyGrid.ItemsSource = tempHumans;
            }
            else
            {
                StreamWriter sw = File.CreateText(@"filt.json");
                File.WriteAllText(@"filt.json", jsonString);
                MyGrid.ItemsSource = tempHumans;
            }
        }
    }
}
