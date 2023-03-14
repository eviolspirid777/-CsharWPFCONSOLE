﻿using System;
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
using FileFunc;

namespace csSharpJWPF
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var options = new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), WriteIndented = true };
            List<Person> Persons = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(FileWork.GetPath()), options);
            MyGrid.ItemsSource = Persons;
        }
        public void Mouse_click(object e, RoutedEventArgs arg)
        {
            Window2 window = new Window2();
            window.Show();
            this.Close();
        }
        public void Mouse_click_Filt(object e, RoutedEventArgs arg)
        {
            string jsonString = File.ReadAllText(FileWork.GetPath());
            List<Person> Persons = JsonSerializer.Deserialize<List<Person>>(jsonString, FileWork.Options());
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
            List<Person> persons = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(FileWork.GetPath()), FileWork.Options());
            MyGrid.ItemsSource = persons;
        }
    }
}