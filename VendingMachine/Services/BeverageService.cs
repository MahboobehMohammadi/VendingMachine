using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachine.Models;
using VendingMachine.DTO;
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
            //_ctx must be injected to be effective
            _ctx = new VendingMacineContext();
            _beverages = _ctx.Beverages;
        }
        public IEnumerable<BeverageListDto> GetAll()
        {
            return _beverages.Select(x => new BeverageListDto { Name = x.Name, Id = x.Id }).ToList();
        }

        public IEnumerable<BeverageRecipeDto> GetRecipe(int id)
        {
            return _beverages.FirstOrDefault(x => x.Id == id).recipes.OrderBy(x => x.Order).Select(x => new BeverageRecipeDto { Title = x.Title });
        }
    }
}