using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EaglesNestSite.Models;
using BusinessLogicLayer;
using ProjectModels;
using System.Reflection;

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

    public IActionResult Verify(UserModel model)
    {

        BusinessLogic businessLogic = new();
        UserModel userFound = businessLogic.LogInUser_BL(model);

        if (userFound.IsActive)
        {
            ViewData["Greeting"] = "Welcome" + userFound.FirstName;
            ViewData["Success"] = "You have logged in successfully!";
        }
        else
        {
            ViewData["Greeting"] = "Sorry";
            ViewData["Success"] = "Login failed";
        }

        return View();
    }

    public IActionResult RegisterSuccess(UserModel model)
    {

        BusinessLogic businesssLogic = new();
        bool isRegistered = businesssLogic.Register_BL(model);

        if (isRegistered)
        {
            ViewData["Greeting"] = "Thank you " + model.FirstName + ",";
            ViewData["Success"] = "You have successfully registered!";
        }
        else
        {
            ViewData["Greeting"] = "Sorry";
            ViewData["Success"] = "Registration failed";
        }


        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

