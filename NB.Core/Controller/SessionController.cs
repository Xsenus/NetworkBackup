﻿using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.IO;

namespace NB.Core.Controller
{
    public static class SessionController
    {
        public static string StringSQLiteConnection { get; set; } = "NetworkBackup.s3db";

        public static Session GetSessionSimpleDataLayer(string connectionString = null)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                var fullPathDataBase = Path.GetFullPath(StringSQLiteConnection);
                connectionString = SQLiteConnectionProvider.GetConnectionString(fullPathDataBase);
            }

            var xpoTypeInfoSource = XpoTypesInfoHelper.GetXpoTypeInfoSource().XPDictionary;
            var connectionProvider = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.DatabaseAndSchema);

            var dl = new SimpleDataLayer(xpoTypeInfoSource, connectionProvider);
            var session = new Session(dl, null)
            {
                LockingOption = LockingOption.None,
                TrackPropertiesModifications = true
            };

            return session;
        }

        public static Session GetSessionThreadSafeDataLayer(string connectionString = null)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                var fullPathDataBase = Path.GetFullPath(StringSQLiteConnection);
                connectionString = SQLiteConnectionProvider.GetConnectionString(fullPathDataBase);
            }

            var xpoTypeInfoSource = XpoTypesInfoHelper.GetXpoTypeInfoSource().XPDictionary;
            var connectionProvider = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.DatabaseAndSchema);

            var dl = new ThreadSafeDataLayer(xpoTypeInfoSource, connectionProvider);
            var session = new Session(dl, null) 
            { 
                LockingOption = LockingOption.None, 
                TrackPropertiesModifications = true 
            };

            return session;
        }
    }
}
