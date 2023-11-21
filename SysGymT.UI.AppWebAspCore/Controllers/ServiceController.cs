using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysGymT.EntidadesDeNegocio;
using SysGymT.LogicaDeNegocio;

namespace SysGymT.UI.AppWebAspCore.Controllers
{
    public class ServiceController : Controller
    {
        ServiceBL serviceBL = new ServiceBL();

        // GET: RolController
        public async Task<IActionResult> Index(Service pService = null)
        {
            if (pService == null)
                pService = new Service();
            if (pService.Top_Aux == 0)
                pService.Top_Aux = 10;
            else if (pService.Top_Aux == -1)
                pService.Top_Aux = 0;
            var services = await serviceBL.SearchAsync(pService);
            ViewBag.Top = pService.Top_Aux;
            return View(services);
        }

        // GET: RolController/Details/5
        public async Task<IActionResult> Details(int id_Service)
        {
            var service = await serviceBL.GetByIdAsync(new Service { Id_Service = id_Service });
            return View(service);
        }

        // GET: RolController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: RolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service pService)
        {
            try
            {
                int result = await serviceBL.CreateAsync(pService);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pService);
            }
        }

        // GET: RolController/Edit/5
        public async Task<IActionResult> Edit(Service pService)
        {
            var service = await serviceBL.GetByIdAsync(pService);
            ViewBag.Error = "";
            return View(service);
        }

        // POST: RolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Service pService)
        {
            try
            {
                int result = await serviceBL.ModifyAsync(pService);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pService);
            }
        }

        // GET: RolController/Delete/5
        public async Task<IActionResult> Delete(Service pService)
        {
            ViewBag.Error = "";
            var service = await serviceBL.GetByIdAsync(pService);
            return View(service);
        }

        // POST: RolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Service pService)
        {
            try
            {
                int result = await serviceBL.DeleteAsync(pService);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pService);
            }
        }
    }
}
