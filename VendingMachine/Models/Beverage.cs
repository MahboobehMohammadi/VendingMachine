using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class Beverage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual List<Recipe> recipes { get; set; }
    }
}