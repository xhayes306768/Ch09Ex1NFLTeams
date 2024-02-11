using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NFLTeams.Models;

namespace NFLTeams.Controllers
{
    public class NameController : Controller
    {
        public IActionResult Index()
        {
             var session = new NFLSession(HttpContext.Session);
            var model = new TeamListViewModel
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
                Teams = session.GetMyTeams(),
                ActiveName = session.GetUsername()


            };

            return View(model);
        }


        public IActionResult Change(TeamViewModel model)
        {
            var userName = model.ActiveName;

           
            var session = new NFLSession(HttpContext.Session);
            session.SetUsername(userName);

            
            return RedirectToAction("Index", "Home");


        }

    }
}
