using System;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace HangManV1
{

    class SqlCommands
    {
        public const string dataSource = "SQLiteHangman.db";
        public void newDataBase()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + dataSource))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS User ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name VARCHAR(100) NOT NULL, " +
                    "password TEXT, win INTERGER NOT NULL, lose INTEGER NOT NULL)", connection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
        }
        public void deleteDataBase()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + dataSource))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("DROP TABLE User", connection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
        }
    }
}
