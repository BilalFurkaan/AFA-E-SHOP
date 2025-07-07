using Shoper.Domain.Entities;
using ShoperApplication.Dtos.HelpDtos;
using ShoperApplication.Interfaces;

namespace ShoperApplication.Usecasess.HelpServices;

public class HelpService:IHelpService
{
    private IRepository<Help> _helpRepository;

    public HelpService(IRepository<Help> helpRepository)
    {
        _helpRepository = helpRepository;
    }

    public async Task<List<ResultHelpDto>> GetAllAsyncHelps()
    {
        var values= await _helpRepository.GetAllAsync();
        return values.Select(x => new ResultHelpDto
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            CreatedDate = x.CreatedDate,
            Subject = x.Subject,
            Message = x.Message,
            Status = x.Status
            
        }).ToList();
    }

    public async Task<GetByIdHelpDto> GetByIdHelpAsync(int id)
    {
        var value= await _helpRepository.GetByIdAsync(id);
        var newHelp = new GetByIdHelpDto
        {
            Name = value.Name,
            Email = value.Email,
            CreatedDate = value.CreatedDate,
            Subject = value.Subject,
            Message = value.Message,
            Status = value.Status
        };
        return newHelp;
    }

    public async Task CreateHelpAsync(CreateHelpDto dto)
    {
        var help = new Help()
        {
            Name = dto.Name,
            Email = dto.Email,
            CreatedDate = DateTime.UtcNow,
            Subject = dto.Subject,
            Message = dto.Message,
            Status = dto.Status
        };
        await _helpRepository.CreateAsync(help);
    }

    public async Task UpdateHelpAsync(UpdateHelpDto dto)
    {
        var help = await _helpRepository.GetByIdAsync(dto.Id);
        help.Name = dto.Name;
        help.Email = dto.Email;
        help.CreatedDate = DateTime.UtcNow;
        help.Subject = dto.Subject;
        help.Message = dto.Message;
        help.Status = dto.Status;
        await _helpRepository.UpdateAsync(help);
    }

    public async Task DeleteHelpAsync(int id)
    {
       var help = await _helpRepository.GetByIdAsync(id);
       await _helpRepository.DeleteAsync(help);
    }
}