using System.ComponentModel.DataAnnotations;

namespace HorsesApi.Models;

public class HorseName
{
    [Key]
    public long HorseId { get; set; } 
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}