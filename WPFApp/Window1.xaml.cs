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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        PathContent way = new PathContent(); 
        static string Path = @"content.json";
        public Window1()
        {
            InitializeComponent();
            var options = new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), WriteIndented = true };
            List<Person> humans = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(way.Get_Path()), options);
            MyGrid.ItemsSource = humans;
        }
        public void Mouse_click(object e, RoutedEventArgs arg)
        {
            Window2 wnd = new Window2();
            wnd.Show();
            this.Close();
        }
        public void Mouse_click_Filt(object e, RoutedEventArgs arg)
        {
            Window3 wnd = new Window3(keyword.Text);
            wnd.Show();
        }
    }
}
