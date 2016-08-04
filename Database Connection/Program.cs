using System;

namespace Database_Connection
{
    static class Program
    {

        static void Main(string[] args)
        {
            var oracleConnection = new OracleConnection("Test connection string");
            var chance = new Random().Next(1, 3);
            var stringtest = chance == 1;

            Console.WriteLine(oracleConnection.OpenConnection(stringtest)
                ? $"Connection to {oracleConnection.Name} is now open.\n"
                : $"Connection to {oracleConnection.Name} timed-out.");

            if (!stringtest) return;
            Console.WriteLine($"Press any key to close the connection to {oracleConnection.Name}.\n");
            Console.ReadKey();
            oracleConnection.CloseConnection();
        }
    }
}
