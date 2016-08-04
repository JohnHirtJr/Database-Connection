using System;

namespace Database_Connection
{
    public class SqlConnection : DbConnection
    {
        private string _name = "SQL";

        public SqlConnection(string connectionstring) : base(connectionstring)
        {
            ConnectionString = connectionstring;
        }

        public string Name
        {
            get { return _name; }
        }

        public override bool OpenConnection(bool value)
        {
            var isConnected = value;
            var timerStart = DateTime.Now;
            var elapsed = TimeSpan.Zero;
            var drawnew = true;
            do
            {
                if (isConnected)
                    return true;

                elapsed = DateTime.Now - timerStart;

                if (elapsed.Seconds < 1 && drawnew)
                {
                    Console.Clear();
                    Console.WriteLine("Establishing connection . ");
                    drawnew = false;
                }
                if (elapsed.Seconds == 2 && !drawnew)
                {
                    Console.Clear();
                    Console.WriteLine("Establishing connection .. ");
                    drawnew = true;
                }
                if (elapsed.Seconds == 3 && drawnew)
                {
                    Console.Clear();
                    Console.WriteLine("Establishing connection ... ");
                    drawnew = false;
                }
                if (elapsed.Seconds == 4 && !drawnew)
                {
                    Console.Clear();
                    Console.WriteLine("Establishing connection .... ");
                    drawnew = true;
                }

            } while (elapsed < Timeout);


            return false;
        }

        public override void CloseConnection()
        {
            Console.WriteLine("SQL connection is now closed.\n");
        }
    }
}