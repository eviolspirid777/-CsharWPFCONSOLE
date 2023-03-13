using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrsnLib;

namespace csSharpJWPF
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var options = new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), WriteIndented = true };
            List<Person> humans = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(PathContent.GetPath()), options);
            MyGrid.ItemsSource = humans;
        }
        public void Mouse_click(object e, RoutedEventArgs arg)
        {
            Window2 wnd = new Window2();
            wnd.Show();
        }
        public void Mouse_click_Filt(object e, RoutedEventArgs arg)
        {
            //           Window3 wnd = new Window3(keyword.Text);
            //           wnd.Show();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),       //настройки для сериалайзера
                WriteIndented = true
            };
            string jsonString = File.ReadAllText(PathContent.GetPath());
            List<Person> humans = JsonSerializer.Deserialize<List<Person>>(jsonString);
            List<Person> tempHumans = new List<Person>();
            foreach (var exp in humans)
                if (exp.Fio.Name.ToLower().Contains(keyword.Text) || exp.Fio.Surname.ToLower().Contains(keyword.Text) || exp.Fio.Patron.ToLower().Contains(keyword.Text) || exp.Fio.Name.ToUpper().Contains(keyword.Text) || exp.Fio.Surname.ToUpper().Contains(keyword.Text) || exp.Fio.Patron.ToUpper().Contains(keyword.Text) || exp.Fio.Name.Contains(keyword.Text) || exp.Fio.Surname.Contains(keyword.Text) || exp.Fio.Patron.Contains(keyword.Text))
                {
                    tempHumans.Add(exp);
                }
            MyGrid.ItemsSource = tempHumans;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var options = new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), WriteIndented = true };
            List<Person> humans = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(PathContent.GetPath()), options);
            MyGrid.ItemsSource = humans;
        }
    }
}