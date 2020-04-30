using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private DataContext _context;
        private IAppRepository rep;
        private IMapper _mapper;

        public CitiesController(IAppRepository _rep,IMapper mapper)
        {
            _mapper = mapper;
            rep = _rep;
        }

        public ActionResult GetCities()
        {
            /*DTO*/
            
            //var cities = rep.Queryable().Include(x => x.Photos)
            //    .Select(x=> new CityForListDto{Description = x.Description, Name = x.Name,Id = x.Id}).ToList();
            var cities = rep.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(citiesToReturn);
        }


        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody] City city)
        {
            rep.Add(city);
            rep.SaveAll();
            return Ok(city);
        }


        [HttpGet]
        [Route("detail")]
        public ActionResult GetCityById(int id)
        {
            var city = rep.GetCityById(id);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);
            return Ok(cityToReturn);
        }

    }
}