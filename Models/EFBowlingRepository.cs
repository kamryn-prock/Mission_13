using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlFun.Models
{
    public class EFBowlingRepository : IBowlingRepository
    { 
        private BowlingDbContext _context { get; set; }
        public EFBowlingRepository (BowlingDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public void Add(Bowler b)
        {
            if (b.BowlerID == 0)
            {
                _context.Bowlers.Add(b);
            }
            _context.SaveChanges();
        }
        public void Update(Bowler b)
        {
            _context.Bowlers.Update(b);
            _context.SaveChanges();
        }

        public void Delete(Bowler d)
        {
            _context.Bowlers.Remove(d);
            _context.SaveChanges();
        }
    }
}
