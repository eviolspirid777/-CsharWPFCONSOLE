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
using System.Globalization;
using JsonSerializeLib;

namespace csSharpJWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DeSerialize.Deserialize(out List<Person> Persons);
            FillCount(Persons);
            MyGrid.ItemsSource = Persons;
        }
        public void Mouse_click(object e, RoutedEventArgs arg)
        {
            Window2 window = new Window2();
            window.Show();
            this.Close();
        }
        public void Delete_click(object e, RoutedEventArgs arg)
        {
            DeSerialize.Deserialize(out List<Person> Persons);
            FillCount(Persons);
            if (int.TryParse(keyword.Text, out int num))
                Persons.RemoveAll(x => Persons.IndexOf(x) == Convert.ToInt32(keyword.Text) - 1);
            else
                MessageBox.Show("Ошибка! Введите номер записи!");
            FillCount(Persons);
            DeSerialize.Serialize(out string jsonString,Persons);
            FileWork.WriteText(jsonString);
            MyGrid.ItemsSource = Persons;
        }
            public void Mouse_click_Filt(object e, RoutedEventArgs arg)
        {
            string jsonString = FileWork.ReadText();
            DeSerialize.Deserialize(out List<Person> Persons);
            FillCount(Persons);
            MyGrid.ItemsSource = Persons.Where(Persons => 
               Persons.Fio.Name.Contains(keyword.Text, StringComparison.CurrentCultureIgnoreCase)
            || Persons.Fio.Surname.Contains(keyword.Text, StringComparison.CurrentCultureIgnoreCase)
            || Persons.Fio.Patron.Contains(keyword.Text, StringComparison.CurrentCultureIgnoreCase)
            );
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            DeSerialize.Deserialize(out List<Person> Persons);
            FillCount(Persons);
            MyGrid.ItemsSource = Persons;
        }
        public void FillCount(List<Person> Persons)
        {
            int[] capacity = new int[Persons.Count];
            for (int i = 0; i < Persons.Count; i++)
            {
                capacity[i] = i;
                Persons[i].Id = i+1;
            }
        }
    }
}