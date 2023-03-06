using Microsoft.EntityFrameworkCore;
using SimplificaITR.BackEnd.Data;
using SimplificaITR.BackEnd.Data.Dtos.Cities;
using SimplificaITR.BackEnd.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimplificaITR.BackEnd.Repository
{
    public interface ICityRepository
    {
        Task<List<GetAllCitiesDto>> GetAllAsync();
        City GetById(int id);
        bool Add(City user);
        bool Save();
        bool Update(City user);
        bool Delete(City user);
    }
    public class CityRepository : ICityRepository
    {
        private SimplificaITRContext _context;

        public CityRepository(SimplificaITRContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllCitiesDto>> GetAllAsync()
        {
            var query = await (from ct in _context.Cities
                               join cd in _context.Conditions on ct.Id equals cd.CityId
                               select new GetAllCitiesQueryDto
                               {
                                   Id = ct.Id,
                                   Name = ct.Name,
                                   State = ct.State,
                                   Font = ct.Font,
                                   Type = cd.Type,
                                   Value = cd.Value
                               }).ToListAsync();

            var ids = (from e in query select e.Id).Distinct().ToList();

            List<GetAllCitiesDto> cityList = new List<GetAllCitiesDto>();

            for (int i = 0; i < ids.Count; i++)
            {
                GetAllCitiesDto cityDto = new GetAllCitiesDto();

                var cities = (from e in query where e.Id == ids[i] select e).ToList();

                cityDto.Id = cities.ElementAt(0).Id;
                cityDto.Name = cities.ElementAt(0).Name;
                cityDto.State = cities.ElementAt(0).State;
                cityDto.AptidaoBoa = cities.ElementAt(0).Value;
                cityDto.AptidaoRegular = cities.ElementAt(1).Value;
                cityDto.AptidaoRestrita = cities.ElementAt(2).Value;
                cityDto.PastagemPlantada = cities.ElementAt(3).Value;
                cityDto.Silvicultura = cities.ElementAt(4).Value;
                cityDto.Preservacao = cities.ElementAt(5).Value;
                cityDto.Font = cities.ElementAt(0).Font;

                cityList.Add(cityDto);
            }

            return cityList;
        }

        public City GetById(int id)
        {
            return _context.Cities.FirstOrDefault(city => city.Id == id);
        }


        public bool Add(City city)
        {
            _context.Add(city);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(City city)
        {
            _context.Update(city);
            return Save();
        }

        public bool Delete(City city)
        {
            _context.Remove(city);
            return Save();
        }
    }
}
