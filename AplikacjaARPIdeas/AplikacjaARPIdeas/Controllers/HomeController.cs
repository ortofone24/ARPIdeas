using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AplikacjaARPIdeas.Models;

namespace AplikacjaARPIdeas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkerRepository _workerRepository;

        public HomeController(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public IActionResult Index()
        {
            var worker = _workerRepository.GetAllWorkers();
            return View(worker);
        }
    }
}
