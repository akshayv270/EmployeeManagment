using EmployeeManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagment.Controllers
{
    public class StateController : Controller
    {
        StateDataAccess stateDataAccess = new StateDataAccess();
        [HttpGet]
        public IActionResult Index()
        {
            return View(stateDataAccess.GetAllState());
        }

        [HttpGet]
        public IActionResult StateDropDemo()
        {
            var states = stateDataAccess.GetAllState();
            ViewBag.States = new SelectList(states, "Id", "StateName");
            return View();
        }
        [HttpGet]
        public IActionResult CreateState()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateState(StateModel Smodel)
        {
            if (Smodel != null)
            {
                stateDataAccess.InsertStateModel(Smodel);
                TempData["StateSucess"] = "Recod Inserted Sucessfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            stateDataAccess.DeleteItem(id);
            return RedirectToAction("Index");
        }

          [HttpGet]  
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            StateModel stateData = stateDataAccess.GetStateData(id);

            if (stateData == null)
            {
                return NotFound();
            }
            return View(stateData);
        }


        [HttpPost]
        
        public IActionResult Edit(int id, [Bind] StateModel stateData)
        {
            if (id != stateData.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                stateDataAccess.UpdateState(stateData);
                return RedirectToAction("Index");
            }
            return View(stateData);
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            StateModel stateData = stateDataAccess.GetStateData(id);

            if (stateData == null)
            {
                return NotFound();
            }
            return View(stateData);
        }
        [HttpGet]
        public JsonResult GetCitiesByState(int stateId)
        {
            var cities = stateDataAccess.GetAllCityByStateID(stateId);
            return Json(cities);
        }


    }
}
