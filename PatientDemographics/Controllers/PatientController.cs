using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using PatientDemographics.Models;

namespace PatientDemographics.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<PatientViewModel> patients = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.PatientApiEndPoint);
                //HTTP GET
                var responseTask = client.GetAsync(Constants.PatientApiRequestUri);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PatientViewModel>>();
                    readTask.Wait();
                    patients = readTask.Result;
                }
                else
                {
                    patients = Enumerable.Empty<PatientViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(patients);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientViewModel patient)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.PatientApiEndPoint);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<PatientViewModel>(Constants.PatientApiRequestUri, patient);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }
            return View(patient);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}