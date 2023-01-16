using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePayTasks
{
    public class CombinationModel
    {
        public int Payout { get; set; }
        public List<CombinationLine> CombinationLines { get; set; } = new List<CombinationLine>();
    }

    public class CombinationLine
    {
        public List<Pair> Pairs { get; set; } = new List<Pair>();
    }

    public class Pair
    {
        public int Bill { get; set; }
        public int Count { get; set; }
    }

}
