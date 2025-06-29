using Microsoft.EntityFrameworkCore;
using Shoper.Domain.Entities;
using Shoper.Persistence.Context;
using ShoperApplication.Dtos.CityDtos;
using ShoperApplication.Dtos.TownDtos;
using ShoperApplication.Interfaces.IOrderRepository;

namespace Shoper.Persistence.Repositories.OrderRepository;

public class OrderRepository: IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<City>> GetCities()
    {
        var cities = await _context.Citys.ToListAsync();
        return cities;
    }

    public async Task<List<Town>> GetTowns(int cityId)
    {
        var towns=await _context.Towns.Where(x=> x.CityId == cityId).ToListAsync();
        return towns;
    }
}