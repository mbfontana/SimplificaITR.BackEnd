using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplificaITR.BackEnd.Data.Dtos.Cities;
using SimplificaITR.BackEnd.Models;
using SimplificaITR.BackEnd.Repository;
using SimplificaITR.BackEnd.Services;

namespace SimplificaITR.BackEnd.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<List<GetAllCitiesDto>> GetAllCities()
        {
            return await _cityRepository.GetAllAsync();
        }
    }
}
