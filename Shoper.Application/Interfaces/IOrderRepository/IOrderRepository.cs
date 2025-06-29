using Shoper.Domain.Entities;
using ShoperApplication.Dtos.CityDtos;
using ShoperApplication.Dtos.ProductDtos;
using ShoperApplication.Dtos.TownDtos;

namespace ShoperApplication.Interfaces.IOrderRepository;

public interface IOrderRepository
{
    Task<List<City>> GetCities();
    Task<List<Town>> GetTowns(int cityId);
}