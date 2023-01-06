using EcommerceApp.Application.Models.DTOs;
using EcommerceApp.Application.Services.AdminService;
using Microsoft.AspNetCore.Mvc;

namespace EcommerApp.MVC.Areas.Admin.Controllers
{
    public class ManagerController:Controller
    {
        private readonly IAdminService _adminService;
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddManager()

        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> AddManager(AddManagerDTO addManagerDTO)
        {
            await _adminService.CreateManager(addManagerDTO);
            return View(nameof(ListOfManagers));
        }
        public async Task<IActionResult> ListOfManagers(AddManagerDTO addManagerDTO)
        {
            var managers = await _adminService.GetManagers();
            return View(managers);
        }


    }
}
