﻿using System;
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
using PersonLibrary;
using FileFunctions;

namespace csSharpJWPF
{
    public partial class Window2 : Window
    {
        Person person = new Person();

        public Window2()
        {
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
                FileWork.ReadData(out List<Person> Persons);
                person.Fio.Surname = Surname.Text;
                person.Fio.Name = Name.Text; 
                person.Fio.Patron = Patron.Text; 
                person.Curriculum.Faculty = Faculty.Text; 
                person.Curriculum.Specialty = Specialty.Text; 
                person.Curriculum.Course = Course.Text; 
                person.Curriculum.Group = Group.Text; 
                person.Address.City = City.Text; 
                person.Address.PstIndex = PstIndex.Text; 
                person.Address.Street = Street.Text; 
                person.Contacts.Phone = Phone.Text; 
                person.Contacts.Mail = Mail.Text; 
                Persons.Add(person);
                FileWork.WriteData(Persons);              //сериализация, где exmp - список <List>, options настройки
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
        }
        private void ExitKey(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
