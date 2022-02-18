using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTracker
{
    public class BattleShip
    {
        public List<Square> Squares { get; set; }
        public bool IsSunk { get; set; } = false;
    }
}
