using Microsoft.AspNetCore.Mvc;
using MySqlFun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static MySqlFun.Models.IBowlingRepository;
using System.Threading.Tasks;

namespace MySqlFun.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBowlingRepository repo { get; set; }

        public TypesViewComponent (IBowlingRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var types = repo.Bowlers
                .Select(x => x.TeamID)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }

    }
}
