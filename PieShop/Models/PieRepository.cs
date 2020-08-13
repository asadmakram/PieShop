using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDBContext _appDBContext = null;
        public PieRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public IEnumerable<Pie> AllPies => _appDBContext.Pies.Include(c => c.Category);

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _appDBContext.Pies.Include(c => c.Category).Where(x => x.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return _appDBContext.Pies.Include(c=>c.Category).FirstOrDefault(x => x.PieId == pieId);
        }
    }
}
