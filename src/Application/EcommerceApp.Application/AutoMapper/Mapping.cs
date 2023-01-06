using AutoMapper;
using EcommerceApp.Application.Models.DTOs;
using EcommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Application.AutoMapper
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            //Eşleştirme işlemleri gerçekleştirilecektir. 

            //hangi türden veri gelirse diğerine otomatik çevir.
            //Örnek: CreateMap<T,TResult>().ReverseMap();

            CreateMap<Employee, AddManagerDTO>().ReverseMap();
        }
    }
}
