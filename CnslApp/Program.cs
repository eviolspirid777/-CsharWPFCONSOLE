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
using System.Windows.Input;
using PrsnLib;
using FileFunction;
using CnslApp;
using JsonSerializeLib;

namespace program;
internal class Program
{  
    static void PrintTextYellow(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    static string EnterResult(string add)
    {
        Console.WriteLine($"Введите {add}:\n");
        string text = Console.ReadLine();
        return text;
    }
    static void EditNode(List<Person> persons)
    {
        PrintTextYellow("\nВы хотите изменить запись?(y/n)");
        var sw = Console.ReadLine();
        if (sw == "y")
        {
            PrintTextYellow("Введите номер записи, которую хотите изменить:");
            string? num = Console.ReadLine();
            if (int.TryParse(num, out int number) && number <= persons.Count)
            {
                number--;
                PrintTextYellow("Что вы хотите изменить:\n1)ФИО\n2)Город\n3)Почтовый индекс\n4)Улицу\n5)Почту\n6)Телефон\n7)Факультет\n8)Курс\n9)Группу\n10)Специальность\n");
                string t = Console.ReadLine();
                switch (t)
                {
                    case "1":
                        persons[number].Fio.Surname = EnterResult("Фамилия");
                        persons[number].Fio.Name = EnterResult("Имя");
                        persons[number].Fio.Patron = EnterResult("Отчество");
                        break;
                    case "2":
                        persons[number].Address.City = EnterResult("Город");
                        break;
                    case "3":
                        persons[number].Address.PstIndex = EnterResult("Почтовый индекс");
                        break;
                    case "4":
                        persons[number].Address.Street = EnterResult("Улица");
                        break;
                    case "5":
                        persons[number].Contacts.Mail = EnterResult("Почта");
                        break;
                    case "6":
                        persons[number].Contacts.Phone = EnterResult("Телефон");
                        break;
                    case "7":
                        persons[number].Curriculum.Faculty = EnterResult("Факультет");
                        break;
                    case "8":
                        persons[number].Curriculum.Course = EnterResult("Курс");
                        break;
                    case "9":
                        persons[number].Curriculum.Group = EnterResult("Группа");
                        break;
                    case "10":
                        persons[number].Curriculum.Specialty = EnterResult("Специальность");
                        break;
                    default:
                        PrintTextYellow("Введен неправильный символ!");
                        Console.ReadKey();
                        EditNode(persons);
                        break;
                }
            }
            else
            {
                PrintTextYellow("Вы вышли за пределы записей!");
                Thread.Sleep(1200);
                ListMenu();
            }
        }
        if (sw != "y" && sw != "n")
        {
            PrintTextYellow("Вы ввели неправильный символ!");
            Thread.Sleep(1000);
            EditNode(persons);
        }
    }
    static void SetPerson()
    {
        string flag = FileWork.ReadText().Trim();
        if (flag != "")
        {
            Person Person = new Person();
            DeSerialize.Deserialize(out List<Person>Persons);
            Console.WriteLine("Введите ФИО:\n Имя");
            Person.Fio.Name = Console.ReadLine();
            Console.WriteLine(" Фамилия:");
            Person.Fio.Surname = Console.ReadLine();
            Console.WriteLine(" Отчество:");
            Person.Fio.Patron = Console.ReadLine();
            Console.WriteLine("Введите город:");
            Person.Address.City = Console.ReadLine();
            Console.WriteLine("Введите почтовый индекс:");
            Person.Address.PstIndex = Console.ReadLine();
            Console.WriteLine("Введите улицу:");
            Person.Address.Street = Console.ReadLine();
            Console.WriteLine("Введите почту:");
            Person.Contacts.Mail = Console.ReadLine();
            Console.WriteLine("Введите телефон:");
            Person.Contacts.Phone = Console.ReadLine();
            Console.WriteLine("Введите факультет:");
            Person.Curriculum.Faculty = Console.ReadLine();
            Console.WriteLine("Введите курс:");
            Person.Curriculum.Course = Console.ReadLine();
            Console.WriteLine("Введите группу:");
            Person.Curriculum.Group = Console.ReadLine();
            Console.WriteLine("Введите специальность:");
            Person.Curriculum.Specialty = Console.ReadLine();
            Console.Clear();
            Persons.Add(Person);
            DeSerialize.Serialize(out string jsonString,Persons);
            FileWork.WriteText(jsonString);
        }
        else
        {
            Console.WriteLine("Файл пуст!");
        }
    }
    static void ExmpMenu(List<Person> Persons)
    {
        int counter = 1;
        Console.Clear();
        Table.PrintLine();
        Table.PrintRow("Номер", "Имя", "Фамилия", "Отчество", "Город", "Почтовый индекс", "Улица", "Почта", "Телефон", "Курс", "Факультет", "Группа", "Специальность");
        Table.PrintLine();
        foreach (var item in Persons)
        {
            Table.PrintRow($"{counter}", $"{item.Fio.Name}", $"{item.Fio.Surname}", $"{item.Fio.Patron}", $"{item.Address.City}", $"{item.Address.PstIndex}", $"{item.Address.Street}", $"{item.Contacts.Mail}", $"{item.Contacts.Phone}", $"{item.Curriculum.Course}", $"{item.Curriculum.Faculty}", $"{item.Curriculum.Group}", $"{item.Curriculum.Specialty}");
            counter++;
        }
        Table.PrintLine();
    }
    static void PrintPersonTable(List<Person> example)
    {
        int counter = 1;
        Console.Clear();
        Table.PrintLine();
        Table.PrintRow("Номер", "Имя", "Фамилия", "Отчество", "Город", "Почтовый индекс", "Улица", "Почта", "Телефон", "Курс", "Факультет", "Группа", "Специальность");
        Table.PrintLine();
        foreach (var item in example)
        {
            Table.PrintRow($"{counter}", $"{item.Fio.Name}", $"{item.Fio.Surname}", $"{item.Fio.Patron}", $"{item.Address.City}", $"{item.Address.PstIndex}", $"{item.Address.Street}", $"{item.Contacts.Mail}", $"{item.Contacts.Phone}", $"{item.Curriculum.Course}", $"{item.Curriculum.Faculty}", $"{item.Curriculum.Group}", $"{item.Curriculum.Specialty}");
            counter++;
        }
        Table.PrintLine();
    }
    static void ListMenu()
    {
        if (FileWork.Exist())
        {
            DeSerialize.Deserialize(out List<Person> Persons);
            ExmpMenu(Persons);
            Console.WriteLine();
            EditNode(Persons);
            DeSerialize.Serialize(out string jsonString, Persons);
            FileWork.WriteText( jsonString);
            Console.Clear();
            PrintMenu();
        }
        else
        {
            PrintTextYellow("Не могу найти файл! Создаю новый...");
            FileWork.CreateFile();
            Thread.Sleep(1000);
            ListMenu();
        }
    }
    static void AddNode()
    {
        if (FileWork.Exist())
        {
            SetPerson();
            Console.Clear();
            PrintMenu();
        }
        else
        {
            PrintTextYellow("Не могу найти файл!");
        }
    }
    static void Sort()
    {
        DeSerialize.Deserialize(out List<Person> person);
        person.Sort((p1, p2) => p1.Fio.Name.CompareTo(p2.Fio.Name));
        PrintPersonTable(person);
        Console.ReadKey();
        Console.Clear();
        PrintMenu();
    }
    static void DeleteNode()
    {
        if (FileWork.Exist())
        {
            DeSerialize.Deserialize(out List<Person> Persons);
            ExmpMenu(Persons);
            PrintTextYellow("\n\nВведите номер записи, которую вы хотите удалить");
            string num = Console.ReadLine();
            if(int.TryParse(num, out int number))
            {
                Console.Clear();
                Persons.RemoveAll(x => Persons.IndexOf(x) == number - 1);
                DeSerialize.Serialize(out string jsonString, Persons);
                FileWork.WriteText(jsonString);
                PrintMenu();
            }
            else
            {
                Console.WriteLine("Вы ввели не число!");
                Console.Clear();
                DeleteNode();
            }
        }
        else
        {
            PrintTextYellow("Файл не существует!");
            FileWork.CreateFile();
            Thread.Sleep(1000);
            PrintMenu();
        }
    }
    static void Filt()
    {
        DeSerialize.Deserialize(out List < Person > persons);
        PrintTextYellow("Введите ключевое слово:");
        var keyword = Console.ReadLine();
        Console.Clear();
        var filteredList = persons.Where(person =>
            person.Fio.Surname.Contains(keyword) ||
            person.Fio.Name.Contains(keyword) ||
            person.Fio.Patron.Contains(keyword) ||
            person.Fio.Name.ToLower().Contains(keyword) ||
            person.Fio.Surname.ToLower().Contains(keyword) ||
            person.Fio.Patron.ToLower().Contains(keyword) ||
            person.Fio.Surname.ToUpper().Contains(keyword) ||
            person.Fio.Name.ToUpper().Contains(keyword) ||
            person.Fio.Patron.ToUpper().Contains(keyword)
        );
        if (filteredList.Count() > 0)
        {
            int counter = 1;
            Table.PrintLine();
            Table.PrintRow("Номер", "Имя", "Фамилия", "Отчество", "Город", "Почтовый индекс", "Улица", "Почта", "Телефон", "Курс", "Факультет", "Группа", "Специальность");
            Table.PrintLine();
            foreach (var person in filteredList)
            {
                Table.PrintRow($"{counter}", $"{person.Fio.Name}", $"{person.Fio.Surname}", $"{person.Fio.Patron}", $"{person.Address.City}", $"{person.Address.PstIndex}", $"{person.Address.Street}", $"{person.Contacts.Mail}", $"{person.Contacts.Phone}", $"{person.Curriculum.Course}", $"{person.Curriculum.Faculty}", $"{person.Curriculum.Group}", $"{person.Curriculum.Specialty}");
                counter++;
            }
            Table.PrintLine();
        }
        else
        {
            PrintTextYellow("Не нашел записей..!");
        }
        PrintTextYellow("\n\nНажмите любую клавишу...");
        Console.ReadKey();
        Console.Clear();
        PrintMenu();
    }
    static void PrintMenu()
    {
        PrintTextYellow("Введите:\n1.Получить список (изменить запись)\n2.Добавить запись\n3.Удалить запись\n4.Сортировать\n5.Фильтровать\n6.Выйти\n");
        var ch = Convert.ToChar(Console.ReadLine());
        Console.Clear();
        switch (ch)
        {
            case '1':
                {
                    ListMenu();
                    break;
                }
            case '2':
                {
                    AddNode();
                    break;
                }
            case '3':
                {
                    DeleteNode();
                    break;
                }
            case '4':
                {
                    Sort();
                    break;
                }
            case '5':
                {
                    Filt();
                    break;
                }
            case '6':
                {
                    PrintTextYellow("Удачи!");
                    Thread.Sleep(1200);
                    Console.Clear();
                    System.Environment.Exit(0);
                    break;
                }
            default:
                {
                    PrintTextYellow("Ошибка! Не могу получить символ!");
                    Thread.Sleep(500);
                    Console.Clear();
                    PrintMenu();
                    break;
                }
        }
    }
    private static void Main(string[] args)
    {
        PrintMenu();
        System.Environment.Exit(0);
    }
}