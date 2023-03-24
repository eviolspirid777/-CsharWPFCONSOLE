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
using PersonLibrary;
using FileFunctions;
using ConsoleApp;

namespace program;
internal class Program
{  
    static void WriteYellowLine(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    static string SetPersonValues(string add)
    {
        Console.WriteLine($"Введите {add}:\n");
        return Console.ReadLine();
    }
    static void EditNode(List<Person> persons)
    {
        WriteYellowLine("\nВы хотите изменить запись?(y/n)");
        var sw = Console.ReadLine();
        if (sw == "y")
        {
            WriteYellowLine("Введите номер записи, которую хотите изменить:");
            string? numberString = Console.ReadLine();
            if (int.TryParse(numberString, out int number) && number <= persons.Count)
            {
                number--;
                WriteYellowLine("Что вы хотите изменить:\n1)ФИО\n2)Город\n3)Почтовый индекс\n4)Улицу\n5)Почту\n6)Телефон\n7)Факультет\n8)Курс\n9)Группу\n10)Специальность\n");
                string t = Console.ReadLine();
                switch (t)
                {
                    case "1":
                        persons[number].Fio.Surname = SetPersonValues("Фамилия");
                        persons[number].Fio.Name = SetPersonValues("Имя");
                        persons[number].Fio.Patron = SetPersonValues("Отчество");
                        break;
                    case "2":
                        persons[number].Address.City = SetPersonValues("Город");
                        break;
                    case "3":
                        persons[number].Address.PstIndex = SetPersonValues("Почтовый индекс");
                        break;
                    case "4":
                        persons[number].Address.Street = SetPersonValues("Улица");
                        break;
                    case "5":
                        persons[number].Contacts.Mail = SetPersonValues("Почта");
                        break;
                    case "6":
                        persons[number].Contacts.Phone = SetPersonValues("Телефон");
                        break;
                    case "7":
                        persons[number].Curriculum.Faculty = SetPersonValues("Факультет");
                        break;
                    case "8":
                        persons[number].Curriculum.Course = SetPersonValues("Курс");
                        break;
                    case "9":
                        persons[number].Curriculum.Group = SetPersonValues("Группа");
                        break;
                    case "10":
                        persons[number].Curriculum.Specialty = SetPersonValues("Специальность");
                        break;
                    default:
                        WriteYellowLine("Введен неправильный символ!");
                        Console.ReadKey();
                        EditNode(persons);
                        break;
                }
            }
            else
            {
                WriteYellowLine("Вы вышли за пределы записей!");
                Thread.Sleep(1200);
                ListMenu();
            }
        }
        if (sw != "y" && sw != "n")
        {
            WriteYellowLine("Вы ввели неправильный символ!");
            Thread.Sleep(1000);
            EditNode(persons);
        }
    }
    static void SetPerson()
    {
        if (FileWork.ReadData(out List<Person> Persons))
        {
            Person Person = new Person();
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
            FileWork.WriteData(Persons);
        }
        else
        {
            Console.WriteLine("Файл пуст!");
        }
    }
    static void PrintList(List<Person> Persons)
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

    static void ListMenu()
    {
        if (FileWork.ReadData(out List<Person> Persons))
        {
            PrintList(Persons);
            Console.WriteLine();
            EditNode(Persons);
            FileWork.WriteData(Persons);
            Console.Clear();
            PrintMenu();
        }
        else
        {
            WriteYellowLine("Не могу найти файл! Создаю новый...");
            FileWork.CreateFile();
            Thread.Sleep(1000);
            ListMenu();
        }
    }
    static void AddNode()
    {
        if (FileWork.ReadData(out List<Person> Persons))
        {
            SetPerson();
            Console.Clear();
            PrintMenu();
        }
        else
        {
            WriteYellowLine("Не могу найти файл!");
        }
    }
    static void SortData()
    {
        if (FileWork.ReadData(out List<Person> person))
        {
            person.Sort((p1, p2) => p1.Fio.Name.CompareTo(p2.Fio.Name));
            PrintList(person);
            Console.ReadKey();
            Console.Clear();
            PrintMenu();
        }
        else 
        {
            WriteYellowLine("Не могу найти файл!");
        }
    }
    static void DeleteNode()
    {
        if (FileWork.ReadData(out List<Person> Persons))
        {
            PrintList(Persons);
            WriteYellowLine("\n\nВведите номер записи, которую вы хотите удалить");
            string numberString = Console.ReadLine();
            if(int.TryParse(numberString, out int number))
            {
                Console.Clear();
                Persons.RemoveAll(x => Persons.IndexOf(x) == number - 1);
                FileWork.WriteData(Persons);
                PrintMenu();
            }
            else
            {
                WriteYellowLine("Вы ввели не число!");
                Console.Clear();
                DeleteNode();
            }
        }
        else
        {
            WriteYellowLine("Файл не существует!");
            FileWork.CreateFile();
            Thread.Sleep(1000);
            PrintMenu();
        }
    }
    static void FiltData()
    {
        if (FileWork.ReadData(out List<Person> Persons))
        {
            WriteYellowLine("Введите ключевое слово:");
            var keyword = Console.ReadLine();
            Console.Clear();
            var filteredList = Persons.Where(person =>
                person.Fio.Surname.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                person.Fio.Name.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                person.Fio.Patron.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
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
                WriteYellowLine("Не нашел записей..!");
            }
            WriteYellowLine("\n\nНажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
            PrintMenu();
        }
        else
        {
            WriteYellowLine("Файл не найден!");
        }
    }
    static void PrintMenu()
    {
        WriteYellowLine("Введите:\n1.Получить список (изменить запись)\n2.Добавить запись\n3.Удалить запись\n4.Сортировать\n5.Фильтровать\n6.Выйти\n");
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
                    SortData();
                    break;
                }
            case '5':
                {
                    FiltData();
                    break;
                }
            case '6':
                {
                    WriteYellowLine("Удачи!");
                    Thread.Sleep(1200);
                    Console.Clear();
                    System.Environment.Exit(0);
                    break;
                }
            default:
                {
                    WriteYellowLine("Ошибка! Не могу получить символ!");
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