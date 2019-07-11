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
            var sqlQueryService = new SqlQueryService();

            var secondResult = sqlQueryService.GetSecondQueryResult();
            Console.WriteLine(secondResult);
            Console.ReadKey();
        }
    }
}
