using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlUpskill
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetFirstQueryResult();
            GetSecondQueryResult();

            Console.ReadKey();
        }

        static void GetFirstQueryResult()
        {
            var sqlQueryService = new SqlQueryService();
            var firstResult = sqlQueryService.GetFirstQueryResult();

            PrintLine();
            PrintRow("Name");
            PrintLine();

            foreach (var result in firstResult)
            {
                PrintRow(result);
            }
        }

        static void GetSecondQueryResult()
        {
            var sqlQueryService = new SqlQueryService();
            var secondResult = sqlQueryService.GetSecondQueryResult();

            PrintLine();
            PrintRow("Name", "StateProvinceId");
            PrintLine();

            foreach (var state in secondResult)
            {
                PrintRow(state.StateProvinceName, state.StateProvinceId.ToString());
            }
        }

        static int tableWidth = 77;

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
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
    }
}
