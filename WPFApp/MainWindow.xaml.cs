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
using PersonLibrary;
using FileFunctions;
using System.Globalization;

namespace csSharpJWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FileWork.ReadData(out List<Person> Persons);
            SetId(Persons);
            MyGrid.ItemsSource = Persons;
        }
        public void MouseClick(object e, RoutedEventArgs arg)
        {
            Window2 window = new Window2();
            window.Show();
            this.Close();
        }
        public void DeleteClick(object e, RoutedEventArgs arg)
        {
            FileWork.ReadData(out List<Person> Persons);
            SetId(Persons);
            if (int.TryParse(keyword.Text, out int num))
                Persons.RemoveAll(x => Persons.IndexOf(x) == Convert.ToInt32(keyword.Text) - 1);
            else
                MessageBox.Show("Ошибка! Введите номер записи!");
            SetId(Persons);
            FileWork.WriteData(Persons);
            MyGrid.ItemsSource = Persons;
        }
            public void MouseClickFilt(object e, RoutedEventArgs arg)
        {
             FileWork.ReadData(out List<Person>Persons);
            SetId(Persons);
            MyGrid.ItemsSource = Persons.Where(Persons => 
               Persons.Fio.Name.Contains(keyword.Text, StringComparison.CurrentCultureIgnoreCase)
            || Persons.Fio.Surname.Contains(keyword.Text, StringComparison.CurrentCultureIgnoreCase)
            || Persons.Fio.Patron.Contains(keyword.Text, StringComparison.CurrentCultureIgnoreCase)
            );
        }
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            FileWork.ReadData(out List<Person> Persons);
            SetId(Persons);
            MyGrid.ItemsSource = Persons;
        }
        public void SetId(List<Person> Persons)
        {
            int[] Capacity = new int[Persons.Count];
            for (int i = 0; i < Persons.Count; i++)
            {
                Capacity[i] = i;
                Persons[i].Id = i+1;
            }
        }
    }
}