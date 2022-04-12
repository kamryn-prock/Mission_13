using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlFun.Models
{
    public class BowlerViewModel
    {
        public IQueryable<Bowler> Bowlers { get; set; }
    }
}
