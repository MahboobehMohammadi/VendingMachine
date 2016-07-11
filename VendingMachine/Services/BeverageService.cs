using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachine.Models;
using VendingMachine.DAL;
using System.Data.Entity;
namespace VendingMachine.Services
{
    public class BeverageService:IBeverageService
    {
        VendingMacineContext _ctx;
        DbSet<Beverage> _beverages;
        public BeverageService()
        {
            //It must be injected to be effective
            _ctx = new VendingMacineContext();
            _beverages = _ctx.Beverages;
        }
        public IEnumerable<Beverage> GetAll()
        {
            return _beverages.ToList();
        }

        public IEnumerable<Recipe> GetRecipe(int id)
        {
            return _beverages.FirstOrDefault(x => x.Id == id).recipes.OrderBy(x=>x.Order);
        }
    }
}