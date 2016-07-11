using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Entity;
using VendingMachine.Models;

namespace VendingMachine.DAL
{
    public class VendingMacineContext:DbContext
    {
        static VendingMacineContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VendingMacineContext, Migrations.Configuration>());
        }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public VendingMacineContext()
        {
            Database.Connection.ConnectionString =
                ConfigurationManager.ConnectionStrings["vendingMacineContext"].ConnectionString;
        }

    }
}