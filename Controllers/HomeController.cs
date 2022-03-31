using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlFun.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlFun.Controllers
{
    public class HomeController : Controller
    {
        private IBowlingRepository _repo { get; set; }

        //Controller
        public HomeController(IBowlingRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            //create dataset
            var blah = _repo.Bowlers
                .ToList();
                

            return View(blah);
        }

    }
}
