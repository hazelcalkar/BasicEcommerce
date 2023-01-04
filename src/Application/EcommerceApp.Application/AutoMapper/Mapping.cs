using AutoMapper;
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
        }
    }
}
