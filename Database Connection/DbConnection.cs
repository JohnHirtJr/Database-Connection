using System;

namespace Database_Connection
{

    public abstract class DbConnection
    {
        public string ConnectionString;
        public TimeSpan Timeout = TimeSpan.FromSeconds(5);

        public DbConnection(string connectionstring)
        {
            if (string.IsNullOrEmpty(connectionstring))
                throw new ArgumentException("Value cannot be null or empty.", nameof(connectionstring));
        }

        public abstract bool OpenConnection(bool value);
        public abstract void CloseConnection();

    }
}