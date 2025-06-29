namespace ShoperApplication.Dtos.TownDtos;

public class GetByIdTownDto
{
    public int Id { get; set; }
    public int TownId { get; set; }
    public int CityId { get; set; }
    public string TownName { get; set; }
}