﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EaglesNestSite.Models;

namespace EaglesNestSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    

    public IActionResult Menue()
    {
        return View();
    }


    public IActionResult AboutMe()
    {
        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }


    public IActionResult Login()
    {
        return View();
    }


    public IActionResult Registration()
    {
        return View();
    }

    public IActionResult RegisterSuccess()
    {
        ViewData["Greeting"] = "Sorry";
        ViewData["Sucess"] = "Registration failed";

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

