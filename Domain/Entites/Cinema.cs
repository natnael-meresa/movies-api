using Domain.Commmon;

namespace Domain.Entities;
public class Cinema : BaseEntity
{
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? PhoneNumber { get; set; }
}