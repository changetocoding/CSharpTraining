using System;
using System.Collections.Generic;

#nullable disable

namespace GSASolution.db.Scaffolded
{
    public partial class Capital
    {
        public int CapitalId { get; set; }
        public int? StrategyId { get; set; }
        public DateTime? Date { get; set; }
        public int? Amount { get; set; }

        public virtual Strategy Strategy { get; set; }
    }
}
