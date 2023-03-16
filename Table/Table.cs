using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableFunc
{
    public class Table
    {
        static public int TableWidth = 200;            //Размер таблицы
        static public void PrintLine()                    //Рисует линию   
        {
            Console.WriteLine(new string('-', TableWidth));
        }
        static public void PrintRow(params string[] columns)               //Колонки для соответствующих полей
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            string row = "|";
            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
            Console.WriteLine(row);
        }

        static public string AlignCentre(string text, int width)           //обрабатывает длинный текст
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            if (string.IsNullOrWhiteSpace(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}