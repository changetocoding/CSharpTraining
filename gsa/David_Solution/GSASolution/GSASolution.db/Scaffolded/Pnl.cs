using System;
using System.Collections.Generic;

#nullable disable

namespace GSASolution.db.Scaffolded
{
    public partial class Pnl
    {
        public int PnlId { get; set; }
        public int? StrategyId { get; set; }
        public DateTime? Date { get; set; }
        public int? Amount { get; set; }

        public virtual Strategy Strategy { get; set; }
    }
}
