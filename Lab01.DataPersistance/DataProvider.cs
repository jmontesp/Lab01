using Lab01.Infrastructure.Interfaces;
using Lab01.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Resx = Lab01.Infrastructure.Resources;
namespace Lab01.DataPersistance
{
    /// <summary>
    /// Proveedor de datos
    /// </summary>
    public partial class DataProvider : DbContext, IDataContext
    {
        
        #region Tables

        /// <summary>
        /// Tabla de tareas
        /// </summary>
        public DbSet<TodoItem> TodoItems { get; set; }

        #endregion

        #region Singleton Pattern

        private static DataProvider instance = null;
 
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
        }
        private DataProvider() 
        {
            Database.EnsureCreated();
        }

        #endregion

        #region DbContext

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            switch (Resx.Configuration.currentDataPersistance)
            {
                case "SQLite":
                    var dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    var connectionString = Path.Combine(dataPath, "Todo.db");
                    options.UseSqlite($"Data Source={connectionString}");
                    break;
            }
        }

        #endregion
    }
}
