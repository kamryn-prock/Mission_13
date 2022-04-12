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

        public IActionResult Index(int teamid)
        {
            //create dataset
            ViewBag.Bowlers = _repo.Bowlers
                //.Where(b => b.TeamID == teamid || teamid == null)
                .ToList();
                

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.TeamId = _repo.Bowlers.Select(x => x.TeamID).Distinct().OrderBy(x => x).ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Add(Bowler b)
        {

            _repo.Add(b);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //ViewBag.Team = _repo.Bowlers.OrderBy(x => x.Team).Select(x => x.Team).Distinct().ToList();
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View("Add", bowler);
        }
        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _repo.Update(b);

            return RedirectToAction("Index");

        }
       
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View("Delete", bowler);

        }


        [HttpPost]
        public IActionResult Delete(Bowler d)
        {
            _repo.Delete(d);
            return RedirectToAction("Index");
        }

    }
}
