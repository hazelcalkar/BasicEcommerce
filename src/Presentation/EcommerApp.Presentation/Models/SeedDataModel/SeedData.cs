﻿using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Enums;
using EcommerceApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;



namespace EcommerApp.MVC.Models.SeedDataModel
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<EcommerceAppDbContext>();
            dbContext.Database.Migrate();
            if (dbContext.Categories.Count() == 0)
            {
                dbContext.Categories.Add(new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Home Appliances",
                    CreateDate = DateTime.Now,
                    Status = Status.Active
                });
                dbContext.Categories.Add(new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Eloctronics",
                    CreateDate = DateTime.Now,
                    Status = Status.Active
                });
                dbContext.Categories.Add(new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Textile",
                    CreateDate = DateTime.Now,
                    Status = Status.Active
                });
            }

            if (dbContext.Employees.Count() == 0)
            {
                dbContext.Employees.Add(new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = "Hazel",
                    Surname = "Çalkar",
                    EmailAddress = "hazel.calkar@bilgeadamboost.com",
                    Status = Status.Active,
                    Password = "1234",
                    CreateDate = DateTime.Now,
                    Roles = Roles.Admin,
                    BirthDate= new DateTime(1998, 05, 08)
                });



            }
            dbContext.SaveChanges();
        }
    }
}