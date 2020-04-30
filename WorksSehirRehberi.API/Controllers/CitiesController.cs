using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorksSehirRehberi.API.Data;
using WorksSehirRehberi.API.Dtos;
using WorksSehirRehberi.API.Models;

namespace WorksSehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private AppRepository<City> rep = new AppRepository<City>(new DataContext());

        public ActionResult GetCities()
        {
            /*DTO*/
            
            //var cities = rep.Queryable().Include(x => x.Photos)
            //    .Select(x=> new CityForListDto{Description = x.Description, Name = x.Name,Id = x.Id}).ToList();
            var cities = rep.GetList();
            return Ok(cities);
        }

    }
}