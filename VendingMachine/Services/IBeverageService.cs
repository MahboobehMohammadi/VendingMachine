using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.DTO;
namespace VendingMachine.Services
{
    public interface IBeverageService
    {
        IEnumerable<BeverageListDto> GetAll();
        IEnumerable<BeverageRecipeDto> GetRecipe(int id);
    }
}
