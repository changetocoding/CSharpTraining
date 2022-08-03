using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp.Data.Scaffolded
{
    public partial class Wine
    {
        public int WineId { get; set; }
        public int ShopId { get; set; }
        public string Name { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
