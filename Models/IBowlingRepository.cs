using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlFun.Models
{
    public interface IBowlingRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        void Add(Bowler b);
        void Update(Bowler bn);
        void Delete(Bowler d);
    }
}
