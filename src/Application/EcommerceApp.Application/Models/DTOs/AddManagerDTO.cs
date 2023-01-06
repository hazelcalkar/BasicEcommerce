using EcommerceApp.Application.Extensions;
using EcommerceApp.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Application.Models.DTOs
{
    public class AddManagerDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage ="Can not be empty")]
        [MaxLength(25,ErrorMessage ="25 karakterden fazla giremezsiniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Can not be empty")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla giremezsiniz.")]
        public string Surname { get; set; }
        public DateTime CreateDate => DateTime.Now;

        [BirthDateExtension(ErrorMessage = "the age of the employee must be over 18")]
        public DateTime BirthDate { get; set; }
        public Status Status => Status.Active;

        public Roles Role => Roles.Manager;
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public string? ImagePath { get; set; }

        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }
    }
}
