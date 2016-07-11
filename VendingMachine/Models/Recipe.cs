using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short Order { get; set; }
        public int BeverageId { get; set; }
    }
}