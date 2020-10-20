﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static void initializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.Sql)
            {
                //TODO - Set up the SQL connector properly.
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if (db == DatabaseType.TextFile)
            {
                //TODO - Create the Text connector properly
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }
        /// <summary>
        /// Get connection string from app.config.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns the connection string Value.</returns>
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
