using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GithubApi.Models;
using static GithubApi.Models.GithubObject;

namespace GithubApi.Controllers
{
    public class ProjectsController : Controller
    {
        GhApi api = new GhApi();
        public IActionResult Index()
        {
            //RootObject ghResponse =
             api.CallGitHubAPI();
            return View();
        }
       
    }
}
