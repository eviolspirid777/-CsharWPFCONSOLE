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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        PathContent way = new PathContent();
        static string Path = @"content.json";
        Person person = new Person();

        public Window2()
        {
            InitializeComponent();
        }

        private void Key_Down(object sender, RoutedEventArgs e)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),       //настройки для сериалайзера
                WriteIndented = true
            };
                List<Person> humans = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(way.Get_Path()), options);
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
                humans.Add(person);
                string jsonString = JsonSerializer.Serialize(humans, options);     //сериализация, где exmp - список <List>, options настройки
                File.WriteAllText(@"content.json", jsonString);                 //@"content.json" - файл; jsonstring - строка, которую надо записать
                MainWindow wndo = new MainWindow();
                wndo.Show();
                this.Close();
        }
        /*
        private void MyTextBox_KeyDown_Surname(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // обработка ввода при нажатии клавиши Enter
            {
                temp.Surname = Surname.Text; // сохранение введенного значения в переменную
            }
        }
        private void MyTextBox_KeyDown_Name(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // обработка ввода при нажатии клавиши Enter
            {
                temp.Name = Name.Text; // сохранение введенного значения в переменную
            }
        }
        private void MyTextBox_KeyDown_Patron(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // обработка ввода при нажатии клавиши Enter
            {
                temp.Patron = Patron.Text; // сохранение введенного значения в переменную
            }
        }
        private void MyTextBox_KeyDown_Faculty(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // обработка ввода при нажатии клавиши Enter
            {
                temp.Faculty = Faculty.Text; // сохранение введенного значения в переменную
            }
        }
        private void MyTextBox_KeyDown_Specialty(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // обработка ввода при нажатии клавиши Enter
            {
                temp.Specialty = Specialty.Text; // сохранение введенного значения в переменную
            }
        }
        private void MyTextBox_KeyDown_Course(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // обработка ввода при нажатии клавиши Enter
            {
                temp.Course = Course.Text; // сохранение введенного значения в переменную
            }
        }
        private void MyTextBox_KeyDown_Group(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // обработка ввода при нажатии клавиши Enter
            {
                temp.Group = Group.Text; // сохранение введенного значения в переменную
            }
        }
        private void MyTextBox_KeyDown_City(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // обработка ввода при нажатии клавиши Enter
            {
                temp.City = City.Text; // сохранение введенного значения в переменную
            }
        }
        private void MyTextBox_KeyDown_PstIndex(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // обработка ввода при нажатии клавиши Enter
            {
                temp.PstIndex = PstIndex.Text; // сохранение введенного значения в переменную
            }
        }
        private void MyTextBox_KeyDown_Street(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // обработка ввода при нажатии клавиши Enter
            {
                temp.Street = Street.Text; // сохранение введенного значения в переменную
            }
        }
        private void MyTextBox_KeyDown_Phone(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // обработка ввода при нажатии клавиши Enter
            {
                temp.Phone = Phone.Text; // сохранение введенного значения в переменную
            }
        }
        private void MyTextBox_KeyDown_Mail(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // обработка ввода при нажатии клавиши Enter
            {
                temp.Mail = Mail.Text; // сохранение введенного значения в переменную
            }
        }
        KeyDown="MyTextBox_KeyDown_Street"
        */
    }
}
