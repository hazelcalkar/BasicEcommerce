using AutoMapper;
using EcommerceApp.Application.Models.DTOs;
using EcommerceApp.Application.Models.VMs;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Enums;
using EcommerceApp.Domain.Repositories;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Application.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepo _employeeRepo;

        public AdminService(IMapper mapper, IEmployeeRepo employeeRepo) 
        { 
            _mapper= mapper;
            _employeeRepo= employeeRepo;
        }

        public async Task CreateManager(AddManagerDTO addManagerDTO)
        {
            var addEmployee = _mapper.Map<Employee>(addManagerDTO);

            if (addEmployee.UploadPath !=null)
            {
                using var image = Image.Load(addManagerDTO.UploadPath.OpenReadStream());//dosya yolunu tuttuk
                image.Mutate(x => x.Resize(600, 560));//resim boyutu ayarladık
                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.png");

                addEmployee.ImagePath = ($"/images/{guid}.png");
                await _employeeRepo.Create(addEmployee);

            }
            else 
            {
                addEmployee.ImagePath = ($"/images/MicrosoftTeams-image (1).png");
                await _employeeRepo.Create(addEmployee);
            }

            
        }

        public async Task<List<ListOfManagerVM>> GetManagers()
        {
            var managers = await _employeeRepo.GetFilteredList(
                select : x=> new ListOfManagerVM
                { 
                    Id= x.Id,
                    Name= x.Name,
                    Surname=x.Surname,
                    Roles= x.Roles
                
                },
                 where: x => (x.Status == Status.Active && x.Roles == Roles.Manager),
                orderBy: x => x.OrderBy(x => x.Name));
                return managers;
                
        }
    }
}
