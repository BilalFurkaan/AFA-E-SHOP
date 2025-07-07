namespace ShoperApplication.Dtos.SubscriberDtos;

public class GetByIdSubscriberDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime SubscriberDate { get; set; }
}