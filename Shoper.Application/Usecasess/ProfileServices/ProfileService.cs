using Shoper.Domain.Entities;
using ShoperApplication.Dtos.OrderDtos;
using ShoperApplication.Dtos.ProfileDtos;
using ShoperApplication.Interfaces;

namespace ShoperApplication.Usecasess.ProfileServices;

public class ProfileService: IProfileService
{
    private readonly IRepository<Customer> _repository;
    

    public ProfileService(IRepository<Customer> repository)
    {
        _repository = repository;
    }

    public async Task<GetByIdProfileDto> GetByProfileIdAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);
        if (customer == null)
        {
            throw new KeyNotFoundException("Customer not found");
        }

        return new GetByIdProfileDto
        {
            CustomerId = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber
        };
    }
    
    public async Task UpdateProfileAsync(UpdateProfileDto dto)
    {
        var customer = await _repository.GetByIdAsync(dto.CustomerId);
        if (customer == null)
        {
            throw new KeyNotFoundException("Customer not found");
        }
        customer.FirstName = dto.FirstName;
        customer.LastName = dto.LastName;
        customer.Email = dto.Email;
        customer.PhoneNumber = dto.PhoneNumber;
        await _repository.UpdateAsync(customer);
    }
}