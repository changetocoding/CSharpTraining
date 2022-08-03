using System;
using System.Collections.Generic;
using System.Text;
using GSASolution.db.Scaffolded;

namespace GSASolution
{
    public interface IDataInputer
    {
        IEnumerable<Strategy> ReadStrategies(string fileLoc);
        Dictionary<string, List<Capital>> ReadCapital(string fileLoc);
        Dictionary<string, List<Pnl>> ReadPnl(string fileLoc);
    }
}
