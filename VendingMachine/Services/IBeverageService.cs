using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;
namespace VendingMachine.Services
{
    interface IBeverageService
    {
        IEnumerable<Beverage> GetAll();
        IEnumerable<Recipe> GetRecipe(int id);
    }
}
