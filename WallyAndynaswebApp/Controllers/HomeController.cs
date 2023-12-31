﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WallyAndynaswebApp.Models;

namespace WallyAndynaswebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // el controlador llama a las vistas
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Usuarios() 
        { 
            return View(); 
        }
        public IActionResult InvetarioCanchas()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AcercaDe()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}