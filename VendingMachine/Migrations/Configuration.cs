namespace VendingMachine.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;
    using VendingMachine.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<VendingMachine.DAL.VendingMacineContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "VendingMachine.DAL.VendingMacineContext";
        }

        protected override void Seed(VendingMachine.DAL.VendingMacineContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Beverages.AddOrUpdate(
              p => p.Name,
              new Beverage
              {
                  Name = "Hot Chocolate",
                  recipes = new List<Recipe> { new Recipe {Title="Boil water" , Order=1 },
                                               new Recipe {Title="Add drinking chocolate to cup" , Order=2 },
                                               new Recipe {Title="Add water" , Order=3 }
                  }
              },
              new Beverage
              {
                  Name = "White Coffee with 1 sugar",
                  recipes = new List<Recipe> { new Recipe {Title="Boil water" , Order=1 },
                                               new Recipe {Title="Add sugar" , Order=2 },
                                               new Recipe {Title="Add coffee granules to cup" , Order=3 },
                                               new Recipe {Title="Add water" , Order=4},
                                               new Recipe {Title="Add milk" , Order=5}

                  }
              },
              new Beverage
              {
                  Name = "Lemon Tea",
                  recipes = new List<Recipe> { new Recipe {Title="Boil water" , Order=1 },
                                               new Recipe {Title="Add water" , Order=2 },
                                               new Recipe {Title="Steep tea bag in hot water" , Order=3 },
                                               new Recipe {Title="Add lemon" , Order=4}

                  }
              },
              new Beverage
              {
                  Name = "Iced Coffee",
                  recipes = new List<Recipe> { new Recipe {Title="Crush Ice" , Order=1 },
                                               new Recipe {Title="Add ice to blender" , Order=2 },
                                               new Recipe {Title="Add coffee syrup to blender" , Order=3 },
                                               new Recipe {Title="Blend ingredients" , Order=4},
                                               new Recipe {Title="Add ingredients" , Order=5}

                  }
              }
            );
        }
    }
}
