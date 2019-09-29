using System;
using System.Linq;
using StudVoice.Methods;

namespace StudVoice
{
    class Program
    {   
        static void Main(string[] args)
        {
            //FillDB.TestData();
            ShowData.ShowAllTables();
            Console.ReadKey();
        }
    }
}
