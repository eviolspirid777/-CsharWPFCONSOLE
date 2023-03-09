using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using PrsnLib;

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
        Console.Clear();
        return text;
    }
    static void EdittingNode(int count, ref List<Person> exmp)
    {
        Console.WriteLine("Введите номер записи, которую хотите изменить:");
        int num = Convert.ToInt32(Console.ReadLine()) - 1;
        if (num <= exmp.Capacity)
        {
            Console.WriteLine("Что вы хотите изменить:\n1)ФИО\n2)Город\n3)Почтовый индекс\n4)Улицу\n5)Почту\n6)Телефон\n7)Факультет\n8)Курс\n9)Группу\n10)Специальность\n");
            int t = Convert.ToInt32(Console.ReadLine());
            switch (t)
            {
                case 1:
                    exmp[num].Fio.Name = EnterRes("Имя");
                    exmp[num].Fio.Surname = EnterRes("Фамилия");
                    exmp[num].Fio.Patron = EnterRes("Отчество");
                    break;
                case 2:
                    exmp[num].Address.City = EnterRes("Город");
                    break;
                case 3:
                    exmp[num].Address.PstIndex = EnterRes("Почтовый индекс");
                    break;
                case 4:
                    exmp[num].Address.Street = EnterRes("Улица");
                    break;
                case 5:
                    exmp[num].Contacts.Mail = EnterRes("Почта");
                    break;
                case 6:
                    exmp[num].Contacts.Phone = EnterRes("Телефон");
                    break;
                case 7:
                    exmp[num].Curriculum.Faculty = EnterRes("Факультет");
                    break;
                case 8:
                    exmp[num].Curriculum.Course = EnterRes("Курс");
                    break;
                case 9:
                    exmp[num].Curriculum.Group = EnterRes("Группа");
                    break;
                case 10:
                    exmp[num].Curriculum.Specialty = EnterRes("Специальность");
                    break;
            }
        }
    }

    static void EditNode(int count, ref List<Person> exmp)
    {
        PathContent path = new PathContent();
        Console.WriteLine("\nВы хотите изменить запись?(y/n)");
        var sw = Console.ReadLine();
        if (sw == "y")
        {
            Console.WriteLine("Введите номер записи, которую хотите изменить:");
            int num = Convert.ToInt32(Console.ReadLine()) - 1;
            if (num <= exmp.Capacity)
            {
                Console.WriteLine("Что вы хотите изменить:\n1)ФИО\n2)Город\n3)Почтовый индекс\n4)Улицу\n5)Почту\n6)Телефон\n7)Факультет\n8)Курс\n9)Группу\n10)Специальность\n");
                int t = Convert.ToInt32(Console.ReadLine());
                switch (t)
                {
                    case 1:
                        exmp[num].Fio.Name = EnterRes("Имя");
                        exmp[num].Fio.Surname = EnterRes("Фамилия");
                        exmp[num].Fio.Patron = EnterRes("Отчество");
                        break;
                    case 2:
                        exmp[num].Address.City = EnterRes("Город");
                        break;
                    case 3:
                        exmp[num].Address.PstIndex = EnterRes("Почтовый индекс");
                        break;
                    case 4:
                        exmp[num].Address.Street = EnterRes("Улица");
                        break;
                    case 5:
                        exmp[num].Contacts.Mail = EnterRes("Почта");
                        break;
                    case 6:
                        exmp[num].Contacts.Phone = EnterRes("Телефон");
                        break;
                    case 7:
                        exmp[num].Curriculum.Faculty = EnterRes("Факультет");
                        break;
                    case 8:
                        exmp[num].Curriculum.Course = EnterRes("Курс");
                        break;
                    case 9:
                        exmp[num].Curriculum.Group = EnterRes("Группа");
                        break;
                    case 10:
                        exmp[num].Curriculum.Specialty = EnterRes("Специальность");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Вы вышли за пределы записей!");
                Thread.Sleep(1200);
                EdittingNode(count, ref exmp);
            }
        }
        if (sw != "y" && sw != "n")
        {
            Console.WriteLine("Вы ввели неправильный символ!");
            Thread.Sleep(1000);
            EditNode(count, ref exmp);
        }

        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        string jsonString = JsonSerializer.Serialize(exmp, options);
        File.WriteAllText(path.Get_Path(), jsonString);
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
    static int ExmpMenu(List<Person> example)
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
        return counter;
    }
    static void ListMenu()
    {
        PathContent path = new PathContent();
        FileInfo fileInf = new FileInfo(path.Get_Path());
        if (fileInf.Exists)
        {
            string jsonString = File.ReadAllText(path.Get_Path());
            List<Person> exp = JsonSerializer.Deserialize<List<Person>>(jsonString)!; //ПРЕДСТАВИТЬ ВВИДЕ МАССИВА И ОТРАБОТАТЬ КАЖДЫЙ ЭЛЕМЕНТ ЧЕРЕЗ ЦИКЛ
            int counter = ExmpMenu(exp);
            Console.WriteLine();
            EditNode(counter, ref exp);
            Console.Clear();
            PrintMenu();
        }
        else
        {
            Console.WriteLine("Не могу найти файл! Создаю новый...");
            StreamWriter sw = File.CreateText(path.Get_Path());
            Thread.Sleep(1000);
            ListMenu();
        }
    }

    static void AddNode()
    {
        PathContent path = new PathContent();
        FileInfo fileInf = new FileInfo(path.Get_Path());
        if (fileInf.Exists)
        {
            var humans = new List<Person>();
            string flag = "";
            flag = File.ReadAllText(path.Get_Path()).Trim();
            if (flag != "")
            {
                humans = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(path.Get_Path()));
            }
            Person temp = new();
            FillExmp(ref temp);
            Console.Clear();
            humans.Add(temp);
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(humans, options);
            File.WriteAllText(path.Get_Path(), jsonString);
            Console.Clear();
            PrintMenu();
        }
        else
            Console.WriteLine("Не могу найти файл!");
    }

    static void Sort()
    {
        PathContent path = new PathContent();
        List<Person> human = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(path.Get_Path()));
        human.Sort((p1, p2) => p1.Fio.Name.CompareTo(p2.Fio.Name));
        ExmpMenu(human);
        Console.ReadKey();
        Console.Clear();
        PrintMenu();
    }
    static void Filt()
    {
        PathContent path = new PathContent();
        List<Person> humans = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(path.Get_Path()));
        Console.WriteLine("Введите фамилию:");
        string surname = Console.ReadLine();
        Console.Clear();
        bool flag = false;
        foreach (var person in humans)
        {
            if (person.Fio.Surname.Contains(surname))
            {
                string t = person.GetInfo();
                Console.WriteLine(t);
                flag = true;
            }
        }
        if (flag == false)
            Console.WriteLine("Не могу найти записи с данной фамилией!");
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