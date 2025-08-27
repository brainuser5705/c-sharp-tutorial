// Array
// define the size of the array

// string[] myFirstStringArray = new string[2];
// myFirstStringArray[0] = "first item";
// myFirstStringArray[1] = "second item";

// string[] strings = ["", "", "",];

// string[] strings1 = ["test", "test1"];

// // List
// // size is mutable

// List<string> strings2 = new List<string>();
// List<string> list = new List<string> { "", "", "", };
// List<string> list1 = [""];

// list.Add("ice cream");
// Console.WriteLine(list[0]);

// // Enumerable
// // fixed size, access with enumerating
// // cannot modify enumerable

// // convert to list to enumerable
// IEnumerable<string> enumerableList = list;
// // can convert it back to a list
// List<string> list3 = enumerableList.ToList();

// // Multidimensional array                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             do 
// int[,] multidimensional = {
//     {1,2},
//     {3,4}
// };
// Console.WriteLine(multidimensional[0, 0]);

// // 3d
// int[,,] threedimensional = {
//     {
//         {1,2},
//         {2,3}
//     }
// };
// Console.WriteLine(threedimensional[0, 0, 0]);

// // Dictionary
// Dictionary<string, int> dictionary = new Dictionary<string, int>();
// dictionary["test"] = 1;
// Console.WriteLine(dictionary["test"]);
// // Error if accessing unknown key

// int[] numbers = [1, 2, 3];
// foreach (int number in numbers)
// {
//     Console.WriteLine(number);
// }

// static methods can only access other static attributes of the class e.g. variables
// nonstatic methods can access nonstatic variables
// static variables can be access from both static and nonstatic methods
// deepest level scope takes precedence

using System.Data;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld {
    
    internal class Program {
        static void Main(string[] args)
        {

            DataContextDapper dapper = new DataContextDapper();

            DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");

            Console.WriteLine(rightNow);

            Computer myComputer = new Computer()
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };

            string sql = @$"INSERT INTO TutorialAppSchema.Computer(
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES ('{myComputer.Motherboard}',
                '{myComputer.HasWifi}',
                '{myComputer.HasLTE}',
                '{myComputer.ReleaseDate}',
                '{myComputer.Price}',
                '{myComputer.VideoCard}')";

            // Console.WriteLine(sql);

            int result = dapper.ExecuteSqlWithRowCount(sql);

            // Console.WriteLine(result);

            string selectSql = @"SELECT
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
            FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(selectSql);

            foreach (Computer computer in computers)
            {
                Console.WriteLine(@$"
                    '{myComputer.Motherboard}',
                    '{myComputer.HasWifi}',
                    '{myComputer.HasLTE}',
                    '{myComputer.ReleaseDate}',
                    '{myComputer.Price}',
                    '{myComputer.VideoCard}'
                ");
            }

            // myComputer.HasWifi = false;
            // Console.WriteLine(myComputer.Motherboard);
            // Console.WriteLine(myComputer.HasWifi);
        }
    }

}


