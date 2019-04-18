using AplikacjaARPIdeas.Models;
using AplikacjaARPIdeas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;


namespace AplikacjaARPIdeas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkerRepository _workerRepository;
        
        public HomeController(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var worker = _workerRepository.GetAllWorkers();
            return View(worker);
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Worker worker)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _workerRepository.AddWorker(worker);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "Wystąpił błąd. " + e.Message);
                }
            }

            return View(worker);
        }
        #endregion

        #region Details
        public IActionResult Details(int id)
        {
            Worker worker = _workerRepository.GetWorkersById(id);
            if (worker == null)
            {
                return RedirectToAction("Index");
            }

            return View(worker);
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Worker worker = _workerRepository.GetWorkersById(id);
            if (worker == null)
            {
                return RedirectToAction("Index");
            }

            return View(worker);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _workerRepository.DeleteWorker(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMsg = "Błąd przy usuwaniu. " + e.Message;
                return View(_workerRepository.GetWorkersById(id));
            }
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Worker worker = _workerRepository.GetWorkersById(id);
            if (worker == null)
            {
                return RedirectToAction("Index");
            }

            return View(worker);
        }

        [HttpPost]
        public IActionResult Edit(Worker worker)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _workerRepository.EditWorker(worker);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "Błąd edytowania. " + e.Message);
                }
            }

            return View(worker);
        }
        #endregion

    }
}
