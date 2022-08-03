using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp.Data.Scaffolded
{
    public partial class Shop
    {
        public Shop()
        {
            Wines = new HashSet<Wine>();
        }

        public int ShopId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Wine> Wines { get; set; }
    }
}
