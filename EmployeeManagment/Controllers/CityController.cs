using EmployeeManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagment.Controllers
{
    public class CityController : Controller
    {
        CityDataAccess cityDataAccess = new CityDataAccess();
        StateDataAccess stateDataAccess = new StateDataAccess();
        public IActionResult Index()
        {
            return View(cityDataAccess.GetAllCity());
        }


        public ActionResult Delete(int id)
        {
            cityDataAccess.DeleteItem(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CityModel cityData = cityDataAccess.GetCityDataById(id);

            if (cityData == null)
            {
                return NotFound();
            }
            return View(cityData);
        }



      
        [HttpGet]
        public IActionResult CreateState()
        {
          //  IEnumerable<StateModel> stateModels = stateDataAccess.GetAllState();
        // CityModel cityModels= (CityModel)cityDataAccess.GetAllCity();
            var states = stateDataAccess.GetAllState();
            ViewBag.States = new SelectList(states, "Id", "StateName");
            return View();
        }
        [HttpPost]
        public IActionResult CreateState(CityModel CModel)
        {
            if (CModel != null)
            {
                cityDataAccess.InsertCityModel(CModel);
                TempData["StateSucess"] = "Recod Inserted Sucessfully";
            }
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var states = stateDataAccess.GetAllState();
            ViewBag.States = new SelectList(states, "Id", "StateName");
            if (Id == null)
            {
                return NotFound();
            }
          CityModel cityModel = cityDataAccess.GetCityDataById(Id);
            if (cityModel == null)
            {
                return NotFound();
            }
            return View(cityModel);
        }


        [HttpPost]

        public IActionResult Edit(int id, [Bind] CityModel cityData)
        {
            if (id != cityData.Id)
            {
                return NotFound();
            }
            else
            {
                cityDataAccess.UpdateCity(cityData);
                return RedirectToAction("Index");
            }
            return View(cityData);
        }

        /*
        [HttpGet]
        public IActionResult CreateState1()
        {
           
            //CityModel cityData = cityDataAccess.GetCityData(id);
            StateModel stateModel = (StateModel)stateDataAccess.GetAllState();
            //var states = stateDataAccess.GetAllState();
            //ViewBag.States = new SelectList(states, "Id", "StateName");
            return View(stateModel);
        }
        */
    }
}
