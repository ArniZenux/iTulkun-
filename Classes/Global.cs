using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace iTulkun
{
    class Global
    {
        #region "VARIABLES"
        public static SQLiteConnection conn;
        public static SQLiteCommand command;
        public static SQLiteDataReader reader;
        //public static SQLiteDataAdapter adapter;
        #endregion
    }
}
