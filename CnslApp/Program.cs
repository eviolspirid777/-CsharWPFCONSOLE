using System.Text.Json;
using PrsnLib;
using FileFunc;
using TableFunc;
//string Path = @"content.json";

internal class Program
{
    delegate void Operator();
    static int TableWidth = 200; //размер таблицы
    

    static string EnterResult(string add)
    {
        Console.WriteLine($"Введите {add}:\n");
        string text = Console.ReadLine();
        return text;
    }


    static void EditNode(int count, ref List<Person> people)
    {
        Console.WriteLine("\nВы хотите изменить запись?(y/n)");
        var sw = Console.ReadLine();
        if (sw == "y")
        {
            Console.WriteLine("Введите номер записи, которую хотите изменить:");
            string? num = Console.ReadLine();
            if (int.TryParse(num, out int number) && number <= people.Count)
            {
                number--;
                Console.WriteLine("Что вы хотите изменить:\n1)ФИО\n2)Город\n3)Почтовый индекс\n4)Улицу\n5)Почту\n6)Телефон\n7)Факультет\n8)Курс\n9)Группу\n10)Специальность\n");
                string t = Console.ReadLine();
                switch (t)
                {
                    case "1":
                        people[number].Fio.Surname = EnterResult("Фамилия");
                        people[number].Fio.Name = EnterResult("Имя");
                        people[number].Fio.Patron = EnterResult("Отчество");
                        break;
                    case "2":
                        people[number].Address.City = EnterResult("Город");
                        break;
                    case "3":
                        people[number].Address.PstIndex = EnterResult("Почтовый индекс");
                        break;
                    case "4":
                        people[number].Address.Street = EnterResult("Улица");
                        break;
                    case "5":
                        people[number].Contacts.Mail = EnterResult("Почта");
                        break;
                    case "6":
                        people[number].Contacts.Phone = EnterResult("Телефон");
                        break;
                    case "7":
                        people[number].Curriculum.Faculty = EnterResult("Факультет");
                        break;
                    case "8":
                        people[number].Curriculum.Course = EnterResult("Курс");
                        break;
                    case "9":
                        people[number].Curriculum.Group = EnterResult("Группа");
                        break;
                    case "10":
                        people[number].Curriculum.Specialty = EnterResult("Специальность");
                        break;
                    default:
                        Console.WriteLine("Введен неправильный символ!");
                        Console.ReadKey();
                        EditNode(count, ref people);
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
            EditNode(count, ref people);
        }
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
    static void ExmpMenu(List<Person> example)
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
        if (FileWork.Exist(FileWork.GetPath()))
        {
            var jsonString = File.ReadAllText(FileWork.GetPath());
            var exp = JsonSerializer.Deserialize<List<Person>>(jsonString)!; //ПРЕДСТАВИТЬ ВВИДЕ МАССИВА И ОТРАБОТАТЬ КАЖДЫЙ ЭЛЕМЕНТ ЧЕРЕЗ ЦИКЛ
            ExmpMenu(exp, out int counter);
            Console.WriteLine();
            EditNode(counter, ref exp);
            jsonString = JsonSerializer.Serialize(exp, FileWork.Options());
            FileWork.WriteText(FileWork.GetPath(), jsonString);
            Console.Clear();
            PrintMenu();
        }
        else
        {
            Console.WriteLine("Не могу найти файл! Создаю новый...");
            FileWork.CreateFile(FileWork.GetPath());
            Thread.Sleep(1000);
            ListMenu();
        }
    }

    static void AddNode()
    {
        if (FileWork.Exist(FileWork.GetPath()))
        {
            var persons = new List<Person>();
            string flag = "";
            flag = File.ReadAllText(FileWork.GetPath()).Trim();
            if (flag != "")
            {
                persons = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(FileWork.GetPath()));
            }
            Person temp = new();
            FillExmp(ref temp);
            Console.Clear();
            persons.Add(temp);
            string jsonString = JsonSerializer.Serialize(persons, FileWork.Options());
            File.WriteAllText(FileWork.GetPath(), jsonString);
            Console.Clear();
            PrintMenu();
        }
        else
            Console.WriteLine("Не могу найти файл!");
    }

    static void Sort()
    {
        var person = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(FileWork.GetPath()));
        person.Sort((p1, p2) => p1.Fio.Name.CompareTo(p2.Fio.Name));
        ExmpMenu(person);
        Console.ReadKey();
        Console.Clear();
        PrintMenu();
    }
    static void Filt()
    {
        List<Person> persons = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(FileWork.GetPath()));
        Console.WriteLine("Введите ключевое слово:");
        var sw = Console.ReadLine();
        Console.Clear();
        var filteredList = persons.Where(person =>
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