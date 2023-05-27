using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgeHrm3.DAL.Context;

public class SQLiteDataStoreContext : DataStoreContext
{
    //private static readonly Logger logger = LogManager.GetLogger("LogSQL");

    public SQLiteDataStoreContext(DbContextOptions<DataStoreContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {

        options
        //.LogTo(Console.WriteLine, LogLevel.Information)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
        .UseSqlite("Data Source=./database/database.db");
        base.OnConfiguring(options);
    }
}
