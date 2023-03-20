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
using FileFunction;

namespace csSharpJWPF
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var Persons = JsonSerializer.Deserialize<List<Person>>(FileWork.ReadText(), FileWork.Options());
            MyGrid.ItemsSource = Persons;
        }
        private void MyGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Tag = e.Row.GetIndex() + 1;
        }
        public void Mouse_click(object e, RoutedEventArgs arg)
        {
            Window2 window = new Window2();
            window.Show();
            this.Close();
        }
        public void Delete_click(object e, RoutedEventArgs arg)
        {
            var jsonString = FileWork.ReadText();
            var exp = JsonSerializer.Deserialize<List<Person>>(jsonString)!;
            exp.RemoveAll(x => exp.IndexOf(x) == Convert.ToInt32(keyword.Text) - 1);
            jsonString = JsonSerializer.Serialize(exp, FileWork.Options());
            FileWork.WriteText(jsonString);
            MyGrid.ItemsSource = exp;
        }
            public void Mouse_click_Filt(object e, RoutedEventArgs arg)
        {
            string jsonString = FileWork.ReadText();
            var Persons = JsonSerializer.Deserialize<List<Person>>(jsonString, FileWork.Options());
            MyGrid.ItemsSource = Persons.Where(Persons => 
            Persons.Fio.Name.ToLower().Contains(keyword.Text)
            || Persons.Fio.Surname.ToLower().Contains(keyword.Text)
            || Persons.Fio.Patron.ToLower().Contains(keyword.Text)
            || Persons.Fio.Name.ToUpper().Contains(keyword.Text)
            || Persons.Fio.Surname.ToUpper().Contains(keyword.Text)
            || Persons.Fio.Patron.ToUpper().Contains(keyword.Text)
            || Persons.Fio.Name.Contains(keyword.Text)
            || Persons.Fio.Surname.Contains(keyword.Text) 
            || Persons.Fio.Patron.Contains(keyword.Text)
            );
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var persons = JsonSerializer.Deserialize<List<Person>>(FileWork.ReadText(), FileWork.Options());
            MyGrid.ItemsSource = persons;
        }
    }
}