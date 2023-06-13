using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using workflowInASP.Models;

namespace workflowInASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult FindBMI(BMI model)
        {
            var result = WorkflowInvoker.Invoke(new BMIruleBased.Workflow1(), new Dictionary<string, object> {
        {
            "BMIinput",
            model.BMIValue
        }
    });
            model.Recommendation = result["Recommendation"] as String;
            TempData["wfResult"] = model;
            return RedirectToAction("ShowResult");



        }
        [HttpGet]
        
       public ActionResult ShowResult()
        {
           BMI model = TempData["wfResult"] as BMI;
            return View(model);
             }

    }
}