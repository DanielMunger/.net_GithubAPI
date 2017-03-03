using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GithubApi.Models;
using static GithubApi.Models.GithubObject;
using Newtonsoft.Json.Linq;

namespace GithubApi.Controllers
{
    public class ProjectsController : Controller
    {
        GhApi api = new GhApi();
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult CallGithubAPI()
        {
            RootObject[] jsonObject = api.CallGitHubAPI();
            return Json(jsonObject);
        }
       
    }
}
