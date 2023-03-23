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
using PrsnLib;
using FileFunction;
using JsonSerializeLib;

namespace csSharpJWPF
{
    public partial class Window2 : Window
    {
        Person person = new Person();

        public Window2()
        {
            InitializeComponent();
        }

        private void Key_Down(object sender, RoutedEventArgs e)
        {
                DeSerialize.Deserialize(out List<Person> persons);
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
                persons.Add(person);
                DeSerialize.Serialize(out string jsonString, persons);              //сериализация, где exmp - список <List>, options настройки
                FileWork.WriteText(jsonString);                                              //@"content.json" - файл; jsonstring - строка, которую надо записать
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
        }
        private void Exit_Key(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
