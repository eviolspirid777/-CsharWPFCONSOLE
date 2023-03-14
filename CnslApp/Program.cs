using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using PrsnLib;
using FileFunc;
using System.Diagnostics.Metrics;

//string Path = @"content.json";

internal class Program
{
    static int TableWidth = 200; //размер таблицы
    static void PrintLine()
    {
        Console.WriteLine(new string('-', TableWidth));
    }

    static void PrintRow(params string[] columns)
    {
        int width = (TableWidth - columns.Length) / columns.Length;
        string row = "|";
        foreach (string column in columns)
        {
            row += AlignCentre(column, width) + "|";
        }
        Console.WriteLine(row);
    }

    static string AlignCentre(string text, int width)
    {
        text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
        if (string.IsNullOrEmpty(text))
        {
            return new string(' ', width);
        }
        else
        {
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }

    static string EnterRes(string add)
    {
        Console.WriteLine($"Введите {add}:\n");
        string text = Console.ReadLine();
        return text;
    }


    static void EditNode(int count, ref List<Person> exmp)
    {
        
        Console.WriteLine("\nВы хотите изменить запись?(y/n)");
        var sw = Console.ReadLine();
        if (sw == "y")
        {
            Console.WriteLine("Введите номер записи, которую хотите изменить:");
            string? num = Console.ReadLine();
            if (int.TryParse(num, out int number) && number <= exmp.Capacity)
            {
                number--;
                Console.WriteLine("Что вы хотите изменить:\n1)ФИО\n2)Город\n3)Почтовый индекс\n4)Улицу\n5)Почту\n6)Телефон\n7)Факультет\n8)Курс\n9)Группу\n10)Специальность\n");
                string t = Console.ReadLine();
                switch (t)
                {
                    case "1":
                        exmp[number].Fio.Surname = EnterRes("Фамилия");
                        exmp[number].Fio.Name = EnterRes("Имя");
                        exmp[number].Fio.Patron = EnterRes("Отчество");
                        break;
                    case "2":
                        exmp[number].Address.City = EnterRes("Город");
                        break;
                    case "3":
                        exmp[number].Address.PstIndex = EnterRes("Почтовый индекс");
                        break;
                    case "4":
                        exmp[number].Address.Street = EnterRes("Улица");
                        break;
                    case "5":
                        exmp[number].Contacts.Mail = EnterRes("Почта");
                        break;
                    case "6":
                        exmp[number].Contacts.Phone = EnterRes("Телефон");
                        break;
                    case "7":
                        exmp[number].Curriculum.Faculty = EnterRes("Факультет");
                        break;
                    case "8":
                        exmp[number].Curriculum.Course = EnterRes("Курс");
                        break;
                    case "9":
                        exmp[number].Curriculum.Group = EnterRes("Группа");
                        break;
                    case "10":
                        exmp[number].Curriculum.Specialty = EnterRes("Специальность");
                        break;
                    default:
                        Console.WriteLine("Введен неправильный символ!");
                        Console.ReadKey();
                        EditNode(count, ref exmp);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Вы вышли за пределы записей!");
                Thread.Sleep(1200);
                ListMenu();
            }
        }
        if (sw != "y" && sw != "n")
        {
            Console.WriteLine("Вы ввели неправильный символ!");
            Thread.Sleep(1000);
            EditNode(count, ref exmp);
        }
        string jsonString = JsonSerializer.Serialize(exmp, FileWork.Options());
        FileWork.WriteTxt(PathContent.GetPath(), jsonString);
    }
    static void FillExmp(ref Person temper)
    {
        Console.WriteLine("Введите ФИО:\n Имя");
        temper.Fio.Name = Console.ReadLine();
        Console.WriteLine(" Фамилия:");
        temper.Fio.Surname = Console.ReadLine();
        Console.WriteLine(" Отчество:");
        temper.Fio.Patron = Console.ReadLine();
        Console.WriteLine("Введите город:");
        temper.Address.City = Console.ReadLine();
        Console.WriteLine("Введите почтовый индекс:");
        temper.Address.PstIndex = Console.ReadLine();
        Console.WriteLine("Введите улицу:");
        temper.Address.Street = Console.ReadLine();
        Console.WriteLine("Введите почту:");
        temper.Contacts.Mail = Console.ReadLine();
        Console.WriteLine("Введите телефон:");
        temper.Contacts.Phone = Console.ReadLine();
        Console.WriteLine("Введите факультет:");
        temper.Curriculum.Faculty = Console.ReadLine();
        Console.WriteLine("Введите курс:");
        temper.Curriculum.Course = Console.ReadLine();
        Console.WriteLine("Введите группу:");
        temper.Curriculum.Group = Console.ReadLine();
        Console.WriteLine("Введите специальность:");
        temper.Curriculum.Specialty = Console.ReadLine();
        Console.Clear();
    }
    static void ExmpMenu(List<Person> example, out int counter)
    {
        counter = 1;
        Console.Clear();
        PrintLine();
        PrintRow("Номер", "Имя", "Фамилия", "Отчество", "Город", "Почтовый индекс", "Улица", "Почта", "Телефон", "Курс", "Факультет", "Группа", "Специальность");
        PrintLine();
        foreach (var item in example)
        {
            PrintRow($"{counter}", $"{item.Fio.Name}", $"{item.Fio.Surname}", $"{item.Fio.Patron}", $"{item.Address.City}", $"{item.Address.PstIndex}", $"{item.Address.Street}", $"{item.Contacts.Mail}", $"{item.Contacts.Phone}", $"{item.Curriculum.Course}", $"{item.Curriculum.Faculty}", $"{item.Curriculum.Group}", $"{item.Curriculum.Specialty}");
            counter++;
        }
        PrintLine();
    }
    static void ExmpMenu(List<Person> example)
    {
        int counter = 1;
        Console.Clear();
        PrintLine();
        PrintRow("Номер", "Имя", "Фамилия", "Отчество", "Город", "Почтовый индекс", "Улица", "Почта", "Телефон", "Курс", "Факультет", "Группа", "Специальность");
        PrintLine();
        foreach (var item in example)
        {
            PrintRow($"{counter}", $"{item.Fio.Name}", $"{item.Fio.Surname}", $"{item.Fio.Patron}", $"{item.Address.City}", $"{item.Address.PstIndex}", $"{item.Address.Street}", $"{item.Contacts.Mail}", $"{item.Contacts.Phone}", $"{item.Curriculum.Course}", $"{item.Curriculum.Faculty}", $"{item.Curriculum.Group}", $"{item.Curriculum.Specialty}");
            counter++;
        }
        PrintLine();
    }
    static void ListMenu()
    {
        if (FileWork.Exist(PathContent.GetPath()))
        {
            string jsonString = File.ReadAllText(PathContent.GetPath());
            List<Person> exp = JsonSerializer.Deserialize<List<Person>>(jsonString)!; //ПРЕДСТАВИТЬ ВВИДЕ МАССИВА И ОТРАБОТАТЬ КАЖДЫЙ ЭЛЕМЕНТ ЧЕРЕЗ ЦИКЛ
            ExmpMenu(exp, out int counter);
            Console.WriteLine();
            EditNode(counter, ref exp);
            Console.Clear();
            PrintMenu();
        }
        else
        {
            Console.WriteLine("Не могу найти файл! Создаю новый...");
            FileWork.CreateFile(PathContent.GetPath());
            Thread.Sleep(1000);
            ListMenu();
        }
    }

    static void AddNode()
    {
        if (FileWork.Exist(PathContent.GetPath()))
        {
            var humans = new List<Person>();
            string flag = "";
            flag = File.ReadAllText(PathContent.GetPath()).Trim();
            if (flag != "")
            {
                humans = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(PathContent.GetPath()));
            }
            Person temp = new();
            FillExmp(ref temp);
            Console.Clear();
            humans.Add(temp);
            string jsonString = JsonSerializer.Serialize(humans, FileWork.Options());
            File.WriteAllText(PathContent.GetPath(), jsonString);
            Console.Clear();
            PrintMenu();
        }
        else
            Console.WriteLine("Не могу найти файл!");
    }

    static void Sort()
    {
        List<Person> human = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(PathContent.GetPath()));
        human.Sort((p1, p2) => p1.Fio.Name.CompareTo(p2.Fio.Name));
        ExmpMenu(human);
        Console.ReadKey();
        Console.Clear();
        PrintMenu();
    }
    static void Filt()
    {
        List<Person> humans = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(PathContent.GetPath()));
        Console.WriteLine("Введите ключевое слово:");
        string sw = Console.ReadLine();
        Console.Clear();
        var filteredList = humans.Where(person =>
            person.Fio.Surname.Contains(sw) ||
            person.Fio.Name.Contains(sw) ||
            person.Fio.Patron.Contains(sw) ||
            person.Fio.Name.ToLower().Contains(sw) ||
            person.Fio.Surname.ToLower().Contains(sw) ||
            person.Fio.Patron.ToLower().Contains(sw) ||
            person.Fio.Surname.ToUpper().Contains(sw) ||
            person.Fio.Name.ToUpper().Contains(sw) ||
            person.Fio.Patron.ToUpper().Contains(sw)
        );
        if (filteredList.Count() > 0)
        {
            int counter = 1;
            PrintLine();
            PrintRow("Номер", "Имя", "Фамилия", "Отчество", "Город", "Почтовый индекс", "Улица", "Почта", "Телефон", "Курс", "Факультет", "Группа", "Специальность");
            PrintLine();
            foreach (var person in filteredList)
            {
                PrintRow($"{counter}", $"{person.Fio.Name}", $"{person.Fio.Surname}", $"{person.Fio.Patron}", $"{person.Address.City}", $"{person.Address.PstIndex}", $"{person.Address.Street}", $"{person.Contacts.Mail}", $"{person.Contacts.Phone}", $"{person.Curriculum.Course}", $"{person.Curriculum.Faculty}", $"{person.Curriculum.Group}", $"{person.Curriculum.Specialty}");
                counter++;
            }
            PrintLine();
        }
        else
        {
            Console.WriteLine("Не нашел записей..!");
        }
        Console.WriteLine("\n\nНажмите любую клавишу...");
        Console.ReadKey();
        Console.Clear();
        PrintMenu();
    }
    static void PrintMenu()
    {
        Console.Write("Введите:\n1.Получить список (изменить запись)\n2.Добавить запись\n3.Соритровать\n4.Фильтровать\n5.Выйти\n");
        char ch = Convert.ToChar(Console.ReadLine());
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
                    Sort();
                    break;
                }
            case '4':
                {
                    Filt();
                    break;
                }
            case '5':
                {
                    Console.WriteLine("Удачи!");
                    Thread.Sleep(1200);
                    Console.Clear();
                    System.Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.WriteLine("Ошибка! Не могу получить символ!");
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